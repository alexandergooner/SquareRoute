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

            AccessCode accessCode2 = new AccessCode
            {
                AccessCodeValue="123"
            };

            District district = new District 
            { 
                Name = "HISD" 
            };

            Route route = new Route
            {
                RouteNum = 1401,
                RouteStart = "4400 West 18th Street Houston, Texas",
                RouteEnd = "11625 Martindale Rd Houston, TX",
                AccessCodeId = 1,
                DistrictId = 1
            };

            Route route2 = new Route
            {
                RouteNum = 1402,
                RouteStart = "4400 West 18th Street Houston, Texas",
                RouteEnd = "5051 Bellfort St Houston, TX",
                AccessCodeId = 2,
                DistrictId = 1
            };

            BusStop busStop = new BusStop
            {
                Location = "BRUNSWICK CROSSING LN & TEALCREST LN Houston TX",
                RouteId = 1
            };

            BusStop busStop2 = new BusStop
            {
                Location = "BRUNSWICK MEADOWS DR. & BRIGHT BLUFF Houston TX",
                RouteId = 1
            };

            BusStop busStopA = new BusStop
            {
                Location = "WEST OREM DR. & GRANDE MONDE DR",
                RouteId = 2
            };

            BusStop busStopB = new BusStop
            {
                Location = "11764 Imperial Street, Houston, TX ",
                RouteId = 2
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
            context.AccessCodes.AddOrUpdate(accessCode2);
            context.SaveChanges();
            context.Districts.AddOrUpdate(district);
            context.SaveChanges();            
            context.Routes.AddOrUpdate(route);
            context.SaveChanges();
            context.Routes.AddOrUpdate(route2);
            context.SaveChanges();
            context.BusStops.AddOrUpdate(busStop);
            context.SaveChanges();
            context.BusStops.AddOrUpdate(busStop2);
            context.SaveChanges();
            context.BusStops.AddOrUpdate(busStopA);
            context.SaveChanges();
            context.BusStops.AddOrUpdate(busStopB);
            context.SaveChanges();

            if (routeDriver != null) 
            {
                context.RouteDrivers.AddOrUpdate(routeDriver);
                context.SaveChanges();
            }
            
            
        }
    }
    
}
