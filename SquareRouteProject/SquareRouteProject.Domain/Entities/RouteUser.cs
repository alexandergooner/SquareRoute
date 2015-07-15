using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Domain.Entities
{
    public class RouteUser
    {
        [Key]
        public int RouteUserId { get; set; }
        [ForeignKey("User")]
        [InverseProperty("Routes")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Route")]
        [InverseProperty("Users")]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}
