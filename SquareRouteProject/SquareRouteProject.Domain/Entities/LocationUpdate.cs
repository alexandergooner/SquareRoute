using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Domain.Entities
{
    public class LocationUpdate
    {
        public string MobileDeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
