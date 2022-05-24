using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vietmap.APIs.Demo.Controls;
using Vietmap.APIs.Demo.Models;

namespace Vietmap.APIs.Demo
{
    public partial class Form1 : Form
    {
        GMapControlExt _MapControl;
        GMap.NET.WindowsForms.GMapOverlay _FullLayer = new GMap.NET.WindowsForms.GMapOverlay { Id = Guid.NewGuid().ToString() };
        GMap.NET.WindowsForms.GMapOverlay _FullLayer_Routing = new GMap.NET.WindowsForms.GMapOverlay { Id = Guid.NewGuid().ToString() };
        bool _start = false;
        bool _end = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var maptile = ConfigurationManager.AppSettings.Get("tile-map");
            CustomMapProvider.Instance.CustomServerUrl = maptile;
            _MapControl = new GMapControlExt();
            _MapControl.MapProvider = CustomMapProvider.Instance;
            _MapControl.MapProvider.MaxZoom = 20;
            _MapControl.MapProvider.BypassCache = true;
            _MapControl.Position = new PointLatLng(10.759340, 106.675348);
            _MapControl.MinZoom = 2;
            _MapControl.MaxZoom = 20;
            _MapControl.Zoom = 15;
            _MapControl.InvertedMouseWheelZooming = false;
            _MapControl.DragButton = MouseButtons.Left;

            _MapControl.Overlays.Add(_FullLayer);
            _MapControl.Overlays.Add(_FullLayer_Routing);
            _MapControl.Dock = DockStyle.Fill;
            
            _MapControl.DoubleClick += _MapControl_DoubleClick;
            splitContainer1.Panel2.Controls.Add(_MapControl);
        }
        private void _MapControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_start)
                {
                    var me = (e as MouseEventArgs);
                    var lonlat = _MapControl.FromLocalToLatLng(me.X, me.Y);
                    textBox_Start.Text = $"{lonlat.Lng.ToString("N6")} {lonlat.Lat.ToString("N6")}";
                    _start = false;
                }
                if (_end)
                {
                    var me = (e as MouseEventArgs);
                    var lonlat = _MapControl.FromLocalToLatLng(me.X, me.Y);
                    textBox_End.Text = $"{lonlat.Lng.ToString("N6")} {lonlat.Lat.ToString("N6")}";
                    _end = false;
                    if(!string.IsNullOrEmpty(textBox_Start.Text) && !string.IsNullOrEmpty(textBox_End.Text))
                        Routing();
                }
            }
            catch { }
        }

        private void button_ChooseStartPoint_Click(object sender, EventArgs e)
        {
            _start = true;
        }

        private void button_ChooseEndPoint_Click(object sender, EventArgs e)
        {
            _end = true;
        }
        private void Routing()
        {
            var urlapi_vm = ConfigurationManager.AppSettings.Get("api-routing");
            var coords = new Coordinate();
            var startsplit = textBox_Start.Text.Split(' ');
            var endsplit = textBox_End.Text.Split(' ');
            urlapi_vm = urlapi_vm.Replace("{long_s}", startsplit[0]).Replace("{lat_s}", startsplit[1]);
            urlapi_vm = urlapi_vm.Replace("{long_e}", endsplit[0]).Replace("{lat_e}", endsplit[1]);
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(urlapi_vm);
            StreamReader a = new StreamReader(stream);
            var res = JsonConvert.DeserializeObject<VMRoutingModel>(
                a.ReadToEnd());
            _FullLayer.Routes.Clear();
            _FullLayer_Routing.Markers.Clear();

            if (res != null)
            {
                var paths = res.paths;
                if (paths.Count() > 0)
                {   
                    {
                        var geometry = PolylineEncode.Decode(paths[0].points, poliline6: false).ToArray();                 
                        _FullLayer_Routing.Markers.Add(new GMarkerGoogle(new PointLatLng(geometry[0].Latitude, geometry[0].Longitude), GMarkerGoogleType.lightblue_pushpin));
                        _MapControl.Position = new PointLatLng((geometry[0].Latitude + geometry.Last().Latitude) / 2, (geometry[0].Longitude + geometry.Last().Longitude) / 2);
                        var StepRoute = new GMapRoute(geometry.Select(g => new PointLatLng(g.Latitude, g.Longitude)), paths[0].snapped_waypoints);
                        StepRoute.Stroke = new Pen(Color.Red, 4.0f);
                        _FullLayer.Routes.Add(StepRoute);
                    }
                }
                _FullLayer_Routing.Markers.Add(new GMarkerGoogle(new PointLatLng(_FullLayer.Routes[0].Points.First().Lat, _FullLayer.Routes[0].Points.First().Lng), GMarkerGoogleType.green_pushpin));
                _FullLayer_Routing.Markers.Add(new GMarkerGoogle(new PointLatLng(_FullLayer.Routes.Last().Points.Last().Lat, _FullLayer.Routes.Last().Points.Last().Lng), GMarkerGoogleType.red_pushpin));
            }
        }
    }
}
