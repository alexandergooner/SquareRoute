namespace SquareRouteProject.Infastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessCodes",
                c => new
                    {
                        AccessCodeId = c.Int(nullable: false, identity: true),
                        AccessCodeName = c.String(),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessCodeId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        RouteNum = c.Int(nullable: false),
                        AccessCodeId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        District_DistrictId = c.Int(),
                        AccessCode_AccessCodeId = c.Int(),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.AccessCodes", t => t.AccessCodeId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.District_DistrictId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.AccessCodes", t => t.AccessCode_AccessCodeId)
                .Index(t => t.AccessCodeId)
                .Index(t => t.DistrictId)
                .Index(t => t.District_DistrictId)
                .Index(t => t.AccessCode_AccessCodeId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: false)
                .Index(t => t.RouteId);
            
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
                        Route_RouteId = c.Int(nullable: false),
                        User_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Route_RouteId, t.User_UserId })
                .ForeignKey("dbo.Routes", t => t.Route_RouteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Route_RouteId)
                .Index(t => t.User_UserId);
            
            AddColumn("dbo.User", "AccessCode_AccessCodeId", c => c.Int());
            CreateIndex("dbo.User", "AccessCode_AccessCodeId");
            AddForeignKey("dbo.User", "AccessCode_AccessCodeId", "dbo.AccessCodes", "AccessCodeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusStops", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.User", "AccessCode_AccessCodeId", "dbo.AccessCodes");
            DropForeignKey("dbo.Routes", "AccessCode_AccessCodeId", "dbo.AccessCodes");
            DropForeignKey("dbo.AccessCodes", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.RouteUsers", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RouteUsers", "Route_RouteId", "dbo.Routes");
            DropForeignKey("dbo.Routes", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Routes", "District_DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Routes", "AccessCodeId", "dbo.AccessCodes");
            DropIndex("dbo.RouteUsers", new[] { "User_UserId" });
            DropIndex("dbo.RouteUsers", new[] { "Route_RouteId" });
            DropIndex("dbo.BusStops", new[] { "RouteId" });
            DropIndex("dbo.User", new[] { "AccessCode_AccessCodeId" });
            DropIndex("dbo.Districts", new[] { "RouteId" });
            DropIndex("dbo.Routes", new[] { "AccessCode_AccessCodeId" });
            DropIndex("dbo.Routes", new[] { "District_DistrictId" });
            DropIndex("dbo.Routes", new[] { "DistrictId" });
            DropIndex("dbo.Routes", new[] { "AccessCodeId" });
            DropIndex("dbo.AccessCodes", new[] { "RouteId" });
            DropColumn("dbo.User", "AccessCode_AccessCodeId");
            DropTable("dbo.RouteUsers");
            DropTable("dbo.BusStops");
            DropTable("dbo.Districts");
            DropTable("dbo.Routes");
            DropTable("dbo.AccessCodes");
        }
    }
}
