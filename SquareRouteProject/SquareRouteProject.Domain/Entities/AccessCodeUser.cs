using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Domain.Entities
{
    public class AccessCodeUser
    {
        [Key]
        public int AccessCodeUserId { get; set; }
        [ForeignKey("User")]
        [InverseProperty("AccessCodes")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("AccessCode")]
        [InverseProperty("Users")]
        public int AccessCodeId { get; set; }
        public virtual AccessCode AccessCode { get; set; }
    }
}
