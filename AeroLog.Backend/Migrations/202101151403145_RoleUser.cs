namespace AeroLog.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.User_UserID })
                .ForeignKey("dbo.Roles", t => t.Role_RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Role_RoleID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleID", "dbo.Roles");
            DropIndex("dbo.RoleUsers", new[] { "User_UserID" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleID" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Roles");
        }
    }
}
