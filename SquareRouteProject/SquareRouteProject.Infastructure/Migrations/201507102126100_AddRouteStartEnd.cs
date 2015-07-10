namespace SquareRouteProject.Infastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRouteStartEnd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "RouteStart", c => c.String());
            AddColumn("dbo.Routes", "RouteEnd", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routes", "RouteEnd");
            DropColumn("dbo.Routes", "RouteStart");
        }
    }
}
