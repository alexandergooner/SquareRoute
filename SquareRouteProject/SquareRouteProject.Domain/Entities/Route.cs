using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Presentation.Models.Data
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }
        public int RouteNum { get; set; }
        public int AccessCodeId { get; set; }


        [ForeignKey("AccessCodeId")]
        public virtual AccessCode AccessCode { get; set; }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        ICollection<BusStop> BusStops { get; set; }
        public virtual ICollection<User> Users { get; set; }



    }
}