namespace SquareRouteProject.Infastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class freshStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessCodes",
                c => new
                    {
                        AccessCodeId = c.Int(nullable: false, identity: true),
                        AccessCodeValue = c.String(),
                    })
                .PrimaryKey(t => t.AccessCodeId);
            
            CreateTable(
                "dbo.AccessCodeUsers",
                c => new
                    {
                        AccessCodeUserId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        AccessCodeId = c.Int(nullable: false),
                        Route_RouteId = c.Int(),
                    })
                .PrimaryKey(t => t.AccessCodeUserId)
                .ForeignKey("dbo.AccessCodes", t => t.AccessCodeId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.Route_RouteId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AccessCodeId)
                .Index(t => t.Route_RouteId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        RouteNum = c.Int(nullable: false),
                        RouteStart = c.String(),
                        RouteEnd = c.String(),
                        AccessCodeId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.BusStops",
                c => new
                    {
                        BusStopId = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BusStopId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.RouteUsers",
                c => new
                    {
                        RouteUserId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteUserId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RoleType = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        ImageUrl = c.String(),
                        MobileDeviceId = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ExternalLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.AccessCodeUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.AccessCodeUsers", "Route_RouteId", "dbo.Routes");
            DropForeignKey("dbo.RouteUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ExternalLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.Claim", "UserId", "dbo.User");
            DropForeignKey("dbo.RouteUsers", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.BusStops", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.AccessCodeUsers", "AccessCodeId", "dbo.AccessCodes");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.ExternalLogin", new[] { "UserId" });
            DropIndex("dbo.Claim", new[] { "UserId" });
            DropIndex("dbo.RouteUsers", new[] { "RouteId" });
            DropIndex("dbo.RouteUsers", new[] { "UserId" });
            DropIndex("dbo.BusStops", new[] { "RouteId" });
            DropIndex("dbo.Routes", new[] { "DistrictId" });
            DropIndex("dbo.AccessCodeUsers", new[] { "Route_RouteId" });
            DropIndex("dbo.AccessCodeUsers", new[] { "AccessCodeId" });
            DropIndex("dbo.AccessCodeUsers", new[] { "UserId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Districts");
            DropTable("dbo.Role");
            DropTable("dbo.ExternalLogin");
            DropTable("dbo.Claim");
            DropTable("dbo.User");
            DropTable("dbo.RouteUsers");
            DropTable("dbo.BusStops");
            DropTable("dbo.Routes");
            DropTable("dbo.AccessCodeUsers");
            DropTable("dbo.AccessCodes");
        }
    }
}
