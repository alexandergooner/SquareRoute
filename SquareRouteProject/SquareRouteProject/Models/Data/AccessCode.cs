using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Presentation.Models.Data
{
    public class AccessCode
    {
        [Key]
        public int AccessCodeId { get; set; }
        public string AccessCodeName { get; set; }

        public int RouteId { get; set; }
        [ForeignKey("RouteId")]

        public virtual Route Route { get; set; }


    }
}