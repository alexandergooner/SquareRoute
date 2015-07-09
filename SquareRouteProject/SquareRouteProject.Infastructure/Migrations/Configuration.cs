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
            //UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(context);
            //UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);

            //RoleStore<Role> roleStore = new RoleStore<Role>(context);
            //RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

            //if (!roleManager.RoleExists("Admin"))
            //{
            //    roleManager.Create(new Role { Name = "Admin" });
            //}
            //if (!roleManager.RoleExists("User"))
            //{
            //    roleManager.Create(new Role { Name = "User" });
            //}

            //IdentityUser alex = userManager.FindByName("alexander.voltaire@gmail.com");
            //if (alex == null)
            //{
            //    alex = new IdentityUser
            //    {
            //        UserName = "alexander.voltaire@gmail.com",
            //        Email = "alexander.voltaire@gmail.com"
            //    };

            //    userManager.Create(alex, "123456");
            //    userManager.AddToRole(alex.Id, "Admin");

            //    alex = userManager.FindByName("alexander.voltaire@gmail.com");
            //}                          
            
        }
    }
    
}
