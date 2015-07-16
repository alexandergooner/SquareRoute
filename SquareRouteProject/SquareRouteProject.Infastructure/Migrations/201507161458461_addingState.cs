namespace SquareRouteProject.Infastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "State");
        }
    }
}
