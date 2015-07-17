using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Domain.Entities
{
     public class School
    {
        [Key]
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string District { get; set; }

        public virtual ICollection<RouteSchool> Routes { get; set; }
    }
}
