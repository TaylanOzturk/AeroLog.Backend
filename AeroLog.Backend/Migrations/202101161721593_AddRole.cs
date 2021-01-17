namespace AeroLog.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "UserID", c => c.String());
            AddColumn("dbo.Users", "RoleID", c => c.Int(nullable: false));
            DropColumn("dbo.Flights", "UserName");
            DropColumn("dbo.Users", "FlightCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FlightCode", c => c.String());
            AddColumn("dbo.Flights", "UserName", c => c.String());
            DropColumn("dbo.Users", "RoleID");
            DropColumn("dbo.Flights", "UserID");
        }
    }
}
