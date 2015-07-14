namespace SquareRouteProject.Infastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Role", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "Id", c => c.String());
        }
    }
}
