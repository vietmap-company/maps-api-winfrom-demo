using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietmap.APIs.Demo.Models
{
    public class PolylineEncode
    { /// <summary>
      /// Decode google style polyline coordinates.
      /// </summary>
      /// <param name="encodedPoints"></param>
      /// <returns></returns>
        public static IEnumerable<CoordinateEntity> Decode(string encodedPoints, bool poliline6 = false)
        {
            if (string.IsNullOrEmpty(encodedPoints))
                throw new ArgumentNullException("encodedPoints");

            char[] polylineChars = encodedPoints.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            while (index < polylineChars.Length)
            {
                // calculate next latitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5bits = (int)polylineChars[index++] - 63;
                    sum |= (next5bits & 31) << shifter;
                    shifter += 5;
                } while (next5bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                //calculate next longitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5bits = (int)polylineChars[index++] - 63;
                    sum |= (next5bits & 31) << shifter;
                    shifter += 5;
                } while (next5bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && next5bits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                if (poliline6)
                {
                    yield return new CoordinateEntity
                    {
                        Latitude = Convert.ToDouble(currentLat) / 1E6,
                        Longitude = Convert.ToDouble(currentLng) / 1E6
                    };
                }
                else
                {
                    yield return new CoordinateEntity
                    {
                        Latitude = Convert.ToDouble(currentLat) / 1E5,
                        Longitude = Convert.ToDouble(currentLng) / 1E5
                    };
                }

            }
        }
       
    }
    public class CoordinateEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
