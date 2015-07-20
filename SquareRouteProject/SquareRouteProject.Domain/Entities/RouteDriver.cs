using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Domain.Entities
{
    public class RouteDriver
    {
        [Key]
        public int RouteDriverId { get; set; }        
        public int RouteId { get; set; }        
        public Guid UserId { get; set; }
        public string MobileDeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        

        public virtual Route Route { get; set; }
        public virtual User User { get; set; }
    }
}
