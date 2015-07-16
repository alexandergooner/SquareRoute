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
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessCodeId);
            
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
                .ForeignKey("dbo.AccessCodes", t => t.AccessCodeId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.AccessCodeId)
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
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
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
                "dbo.UserAccessCodes",
                c => new
                    {
                        User_UserId = c.Guid(nullable: false),
                        AccessCode_AccessCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.AccessCode_AccessCodeId })
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.AccessCodes", t => t.AccessCode_AccessCodeId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.AccessCode_AccessCodeId);
            
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
            
            CreateTable(
                "dbo.RouteUsers",
                c => new
                    {
                        Route_RouteId = c.Int(nullable: false),
                        User_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Route_RouteId, t.User_UserId })
                .ForeignKey("dbo.Routes", t => t.Route_RouteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Route_RouteId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Routes", "AccessCodeId", "dbo.AccessCodes");
            DropForeignKey("dbo.RouteUsers", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RouteUsers", "Route_RouteId", "dbo.Routes");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ExternalLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.Claim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserAccessCodes", "AccessCode_AccessCodeId", "dbo.AccessCodes");
            DropForeignKey("dbo.UserAccessCodes", "User_UserId", "dbo.User");
            DropForeignKey("dbo.BusStops", "RouteId", "dbo.Routes");
            DropIndex("dbo.RouteUsers", new[] { "User_UserId" });
            DropIndex("dbo.RouteUsers", new[] { "Route_RouteId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserAccessCodes", new[] { "AccessCode_AccessCodeId" });
            DropIndex("dbo.UserAccessCodes", new[] { "User_UserId" });
            DropIndex("dbo.ExternalLogin", new[] { "UserId" });
            DropIndex("dbo.Claim", new[] { "UserId" });
            DropIndex("dbo.BusStops", new[] { "RouteId" });
            DropIndex("dbo.Routes", new[] { "DistrictId" });
            DropIndex("dbo.Routes", new[] { "AccessCodeId" });
            DropTable("dbo.RouteUsers");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserAccessCodes");
            DropTable("dbo.Districts");
            DropTable("dbo.Role");
            DropTable("dbo.ExternalLogin");
            DropTable("dbo.Claim");
            DropTable("dbo.User");
            DropTable("dbo.BusStops");
            DropTable("dbo.Routes");
            DropTable("dbo.AccessCodes");
        }
    }
}
