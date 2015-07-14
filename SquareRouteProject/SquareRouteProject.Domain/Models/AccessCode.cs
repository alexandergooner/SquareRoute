using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Domain.Models
{
    public class AccessCode

    {

        public int AccessCodeId { get; set; }
        public string AccessCode { get; set; }
        public virtual ICollection<ApplicationUser> User { get; set; }
        public int RouteId { get; set; }
        [ForignKey("RouteId")]
        public virtual Route Route { get; set; }
    }
}