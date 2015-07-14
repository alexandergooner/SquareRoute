using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Domain.Entities
{
    public class AccessCode
    {
        [Key]
        public int AccessCodeId { get; set; }
        public string AccessCodeValue { get; set; }
        public int RouteId { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}