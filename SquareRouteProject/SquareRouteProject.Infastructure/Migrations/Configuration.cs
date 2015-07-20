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
                RouteStart = "ALMEDA GENOA RD. & CHISWICK RD.",
                RouteEnd = "ALMEDA GENOA RD. & CHISWICK RD.",
                AccessCodeId = 1,
                DistrictId = 1,
            };
            BusStop busStop = new BusStop
            {
                Location = "ALMEDA GENOA RD. & CHISWICK RD.",
                RouteId = 1
            };

            RouteDriver routeDriver = null;
            if (context.Users.ToList().Count > 0) 
            {
                Guid result = context.Users.Where(x => x.UserName == "alexander.voltaire@gmail.com").Select(x => x.UserId).FirstOrDefault();
                if (result != null) 
                {
                    routeDriver = new RouteDriver
                    {
                        UserId = result,
                        Latitude = 0,
                        Longitude = 0,
                        MobileDeviceId = "6e631e8abc44a5ad",
                        RouteId = 1,

                    }; 
                }

            }
            
            //Guid.TryParse("0f08a254-4c07-4ef4-9557-0ab13cc6392b", out result);                       
            
            context.AccessCodes.AddOrUpdate(accessCode);
            context.SaveChanges();
            context.Districts.AddOrUpdate(district);
            context.SaveChanges();            
            context.Routes.AddOrUpdate(route);
            context.SaveChanges();
            context.BusStops.AddOrUpdate(busStop);
            context.SaveChanges();

            if (routeDriver != null) 
            {
                context.RouteDrivers.AddOrUpdate(routeDriver);
                context.SaveChanges();
            }
            
            
        }
    }
    
}
