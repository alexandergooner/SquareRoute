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

        public virtual ICollection<AccessCodeUser> Users { get; set; }


    }
}