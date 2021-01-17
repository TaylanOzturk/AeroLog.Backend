namespace AeroLog.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "UserName", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Users", "FlightCode", c => c.String());
            AlterColumn("dbo.Users", "UserEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserEmail", c => c.String());
            DropColumn("dbo.Users", "FlightCode");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Flights", "UserName");
        }
    }
}
