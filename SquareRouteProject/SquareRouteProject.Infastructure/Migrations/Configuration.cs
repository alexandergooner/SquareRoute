namespace SquareRouteProject.Infastructure.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SquareRouteProject.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //using Role = Microsoft.AspNet.Identity.EntityFramework.IdentityRole;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            AccessCode accessCode = new AccessCode 
            { 
                AccessCodeValue="ABC"                
            };
            District district = new District 
            { 
                Name = "HISD" 
            };
            Route route = new Route
            {
                RouteNum = 1401,
                RouteStart = "BELLAIRE RD & BUFFALO SPEEDWAY",
                RouteEnd = "WOODSHIRE ST. & STELLA LINK RD.",
                AccessCodeId = 1,
                DistrictId = 1,
            };
            BusStop busStop = new BusStop
            {
                Location = "ALMEDA GENOA RD. & CHISWICK RD.",
                RouteId = 1
            };
            
            context.AccessCodes.AddOrUpdate(accessCode);
            context.SaveChanges();
            context.Districts.AddOrUpdate(district);
            context.SaveChanges();            
            context.Routes.AddOrUpdate(route);
            context.SaveChanges();
            context.BusStops.AddOrUpdate(busStop);
            context.SaveChanges();

            
        }
    }
    
}
