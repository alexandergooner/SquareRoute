using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Domain.Models

{
    public class BusStop
    {

        public int BusStopId { get; set; }
        
        public string Location { get; set; }
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}