using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Domain.Entities
{
    public class RouteSchool
    {
        public int RouteSchoolId { get; set; }
        [ForeignKey("Route")]
        [InverseProperty("Schools")]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        [ForeignKey("School")]
        [InverseProperty("Routes")]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }           

    }
}
