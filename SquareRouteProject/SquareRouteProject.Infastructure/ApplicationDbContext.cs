using Microsoft.AspNet.Identity.EntityFramework;
using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SquareRouteProject.Infastructure
{
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext()
            : this(ConnectionInfo.connectionString)
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
        public IDbSet<BusStop> BusStops { get; set; }
        public IDbSet<District> Districts { get; set; }
        public IDbSet<RouteUser> RouteUsers { get; set; }
        public IDbSet<AccessCodeUser> AccessCodeUsers { get; set; }
        public IDbSet<RouteDriver> RouteDrivers { get; set; }
        public IDbSet<School> Schools { get; set; }
        public IDbSet<RouteSchool> RouteSchools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());           
       

         
        }
    }
}
