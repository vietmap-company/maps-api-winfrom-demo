using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietmap.APIs.Demo.Models
{
    class Coordinate
    {
        public List<LngLat> coordinates { get; set; } = new List<LngLat>();
    }
    public class LngLat
    {
        public double @long { get; set; }
        public double lat { get; set; }
    }
}
