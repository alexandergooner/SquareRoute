using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Domain.Entities
{
    public class BusStop
    {
        public int BusStopId { get; set; }
        public string Location { get; set; }
        public int RouteId { get; set; }

        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }
    }
}