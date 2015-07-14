using System;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SquareRouteProject.Domain.Entities;

namespace SquareRouteProject.Presentation.Identity
{
    public class IdentityUser : IUser<Guid>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid();
        }

        public IdentityUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int RoleType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageFile { get; set; }
        public int MobileDeviceId { get; set; }
        public int RouteId { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }

        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }

        public virtual ICollection<AccessCode> AccessCodes { get; set; }
        public virtual ICollection<Route> Routes { get; set; }

     

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser, Guid> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}