using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vietmap.APIs.Demo.Controls
{
    public enum MapTools
    {
        None,
        SelectRect
    }

    public class RectSelectedArg2
    {
        public double Lon1 { get; set; }
        public double Lat1 { get; set; }
        public double Lon2 { get; set; }
        public double Lat2 { get; set; }
    }

    public class GMapControlExt : GMapControl
    {
        private MapTools _MapTool = MapTools.None;
        public event EventHandler<RectSelectedArg2> RectSelected;
        public MapTools MapTool
        {
            get
            {
                return _MapTool;
            }
            set
            {
                _MapTool = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_mouseDownX != null && _mouseDownY != null)
            {
                var point = PointToClient(MousePosition);
                //... your other stuff
                Rectangle rect = new Rectangle(Math.Min(_mouseDownX.Value, point.X), Math.Min(_mouseDownY.Value, point.Y), Math.Abs(_mouseDownX.Value - point.X), Math.Abs(_mouseDownY.Value - point.Y));
                e.Graphics.DrawRectangle(new Pen(Color.Red, 2.0f), rect);
            }
        }

        int? _mouseDownX;
        int? _mouseDownY;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (MapTool == MapTools.SelectRect)
            {
                _mouseDownX = e.Location.X;
                _mouseDownY = e.Location.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (MapTool == MapTools.SelectRect)
            {
                if (RectSelected != null && _mouseDownX.HasValue && _mouseDownY.HasValue)
                {
                    var latlng1 = FromLocalToLatLng(_mouseDownX.Value, _mouseDownY.Value);
                    var latlng2 = FromLocalToLatLng(e.X, e.Y);
                    RectSelected(this, new RectSelectedArg2 { Lat1 = latlng1.Lat, Lon1 = latlng1.Lng, Lat2 = latlng2.Lat, Lon2 = latlng2.Lng });
                }
                _mouseDownX = null;
                _mouseDownY = null;
                MapTool = MapTools.None;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (MapTool == MapTools.None)
            {
                base.OnMouseMove(e);
            }
            else if (MapTool == MapTools.SelectRect)
            {
                Invalidate(false);
            }
        }
    }
}
