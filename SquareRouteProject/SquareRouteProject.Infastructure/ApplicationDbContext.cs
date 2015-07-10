using Microsoft.AspNet.Identity.EntityFramework;
using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure.Configuration;
using SquareRouteProject.Presentation.Models.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SquareRouteProject.Infastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : this("Data Source=(LocalDB)\\mssqllocaldb;Initial Catalog=SquareRouteProject;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {

        }
        public ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public IDbSet<User> Users { get; set; }
        internal IDbSet<Role> Roles { get; set; }
        internal IDbSet<ExternalLogin> Logins { get; set; }
        public IDbSet<Route> Routes { get; set; }
        public IDbSet<AccessCode> AccessCodes { get; set; }
        public IDbSet<BusStop> BusStop { get; set; }
        public IDbSet<District> District { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());

            modelBuilder.Entity<Route>()
                .HasMany<User>(u => u.Users).WithMany(u => u.Routes);
       

         
        }
    }
}
