namespace AeroLog.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alwnll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Users", "OccupationID", "dbo.Occupations");
            DropIndex("dbo.Users", new[] { "CompanyID" });
            DropIndex("dbo.Users", new[] { "OccupationID" });
            AlterColumn("dbo.Users", "CompanyID", c => c.Int());
            AlterColumn("dbo.Users", "OccupationID", c => c.Int());
            CreateIndex("dbo.Users", "CompanyID");
            CreateIndex("dbo.Users", "OccupationID");
            AddForeignKey("dbo.Users", "CompanyID", "dbo.Companies", "CompanyID");
            AddForeignKey("dbo.Users", "OccupationID", "dbo.Occupations", "OccupationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "OccupationID", "dbo.Occupations");
            DropForeignKey("dbo.Users", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "OccupationID" });
            DropIndex("dbo.Users", new[] { "CompanyID" });
            AlterColumn("dbo.Users", "OccupationID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "CompanyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "OccupationID");
            CreateIndex("dbo.Users", "CompanyID");
            AddForeignKey("dbo.Users", "OccupationID", "dbo.Occupations", "OccupationID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
    }
}
