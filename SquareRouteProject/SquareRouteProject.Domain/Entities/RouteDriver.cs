using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Domain.Entities
{
    public class RouteDriver
    {
        [Key]
        public int RouteDriverId { get; set; }
        public int RouteId { get; set; }
        [ForeignKey("RouteId")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual Route Route { get; set; }
        public virtual User User { get; set; }
    }
}
