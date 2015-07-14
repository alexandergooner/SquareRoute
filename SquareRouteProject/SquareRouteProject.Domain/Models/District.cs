using SquareRouteProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Presentation.Models
{
    public class District
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        virtual ICollection<Route> Routes { get; set; }
        public R
    }
}