using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace SquareRouteProject.Domain.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }
        public int RouteNum { get; set; }
        [ForeignKey("AccessCode")]
        public int AccessCodeId { get; set; }
        public virtual AccessCode AccessCode { get; set; }
        public int  DistrictId { get; set; }
        ICollection<BusStop> BusStops { get; set; }
        ICollection<ApplicationUser> Users { get; set; }

    }
}