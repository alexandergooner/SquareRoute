using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure.Configuration;
using System.Data.Entity;

namespace SquareRouteProject.Infastructure
{
    internal class ApplicationDbContext : DbContext
    {
        internal ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        internal IDbSet<User> Users { get; set; }
        internal IDbSet<Role> Roles { get; set; }
        internal IDbSet<ExternalLogin> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<UserConfiguration>(new UserConfiguration());
            modelBuilder.Configurations.Add<RoleConfiguration>(new RoleConfiguration());
            modelBuilder.Configurations.Add<ExternalLoginConfiguration>(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add<ClaimConfiguration>(new ClaimConfiguration());
        }
    }
}
