using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietmap.APIs.Demo.Models
{
    public class VMRoutingModel
    {
        public string license { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public List<Path> paths { get; set; } = new List<Path>();
    }
    public class Path
    {
        public double distance { get; set; }
        public double weight { get; set; }
        public int time { get; set; }
        public int transfers { get; set; }
        public bool points_encoded { get; set; }
        public double[] bbox { get; set; }
        public string points { get; set; }
        //public int MyProperty { get; set; }
        //instructions

        public string snapped_waypoints { get; set; }

    }
}
