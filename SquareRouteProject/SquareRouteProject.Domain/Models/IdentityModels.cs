using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SquareRouteProject.Infastructure.Models;
using SquareRouteProject.Domain.Models;


namespace SquareRouteProject.Domain.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public class MyUserInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ImageUrl { get; set; }
            public Role UserType { get; set; }
            public int MobileDeviceId { get; set; }
            ICollection<AccessCode> AccesCodes { get; set; }
            [ForeignKey("RouteId")]
            ICollection<Route> Routes { get; set; }
            public int RouteId { get; set; }
            public Image Image { get; set; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

    


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SquareRouteProject.Presentation.Models.ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MyUserInfo> MyUserInfo { get; set; }
    }
}