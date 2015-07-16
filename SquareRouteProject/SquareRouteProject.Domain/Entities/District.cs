using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Domain.Entities
{
    public class District
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}