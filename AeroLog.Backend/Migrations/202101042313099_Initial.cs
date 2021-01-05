namespace AeroLog.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.Flights", "Vehicle_VehicleID", "dbo.Vehicles");
            DropIndex("dbo.Flights", new[] { "Vehicle_VehicleID" });
            DropIndex("dbo.Users", new[] { "Flight_FlightID" });
            RenameColumn(table: "dbo.Flights", name: "Vehicle_VehicleID", newName: "VehicleID");
            CreateTable(
                "dbo.UserFlights",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Flight_FlightID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Flight_FlightID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Flight_FlightID);
            
            AlterColumn("dbo.Flights", "VehicleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Flights", "VehicleID");
            AddForeignKey("dbo.Flights", "VehicleID", "dbo.Vehicles", "VehicleID", cascadeDelete: true);
            DropColumn("dbo.Users", "Flight_FlightID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Flight_FlightID", c => c.Int());
            DropForeignKey("dbo.Flights", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.UserFlights", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.UserFlights", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserFlights", new[] { "Flight_FlightID" });
            DropIndex("dbo.UserFlights", new[] { "User_UserID" });
            DropIndex("dbo.Flights", new[] { "VehicleID" });
            AlterColumn("dbo.Flights", "VehicleID", c => c.Int());
            DropTable("dbo.UserFlights");
            RenameColumn(table: "dbo.Flights", name: "VehicleID", newName: "Vehicle_VehicleID");
            CreateIndex("dbo.Users", "Flight_FlightID");
            CreateIndex("dbo.Flights", "Vehicle_VehicleID");
            AddForeignKey("dbo.Flights", "Vehicle_VehicleID", "dbo.Vehicles", "VehicleID");
            AddForeignKey("dbo.Users", "Flight_FlightID", "dbo.Flights", "FlightID");
        }
    }
}
