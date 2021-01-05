namespace AeroLog.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        AirportID = c.Int(nullable: false, identity: true),
                        AirportName = c.String(),
                        IATA = c.String(),
                        ICAO = c.String(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.AirportID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        FlightCode = c.String(),
                        Departure = c.DateTime(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                        ArrivalAirport_AirportID = c.Int(),
                        DepartureAirport_AirportID = c.Int(),
                        Vehicle_VehicleID = c.Int(),
                        Airport_AirportID = c.Int(),
                    })
                .PrimaryKey(t => t.FlightID)
                .ForeignKey("dbo.Airports", t => t.ArrivalAirport_AirportID)
                .ForeignKey("dbo.Airports", t => t.DepartureAirport_AirportID)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_VehicleID)
                .ForeignKey("dbo.Airports", t => t.Airport_AirportID)
                .Index(t => t.ArrivalAirport_AirportID)
                .Index(t => t.DepartureAirport_AirportID)
                .Index(t => t.Vehicle_VehicleID)
                .Index(t => t.Airport_AirportID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserSurname = c.String(),
                        UserEmail = c.String(),
                        UserPhone = c.String(),
                        UserAdres = c.String(),
                        CompanyID = c.Int(nullable: false),
                        OccupationID = c.Int(nullable: false),
                        Flight_FlightID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.Occupations", t => t.OccupationID, cascadeDelete: true)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightID)
                .Index(t => t.CompanyID)
                .Index(t => t.OccupationID)
                .Index(t => t.Flight_FlightID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyPhone = c.Int(nullable: false),
                        CompanyEmail = c.String(),
                        CompanyWebsite = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        OccupationID = c.Int(nullable: false, identity: true),
                        OccupationName = c.String(),
                    })
                .PrimaryKey(t => t.OccupationID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        VehicleName = c.String(),
                        VehicleCode = c.String(),
                    })
                .PrimaryKey(t => t.VehicleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "Airport_AirportID", "dbo.Airports");
            DropForeignKey("dbo.Flights", "Vehicle_VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Users", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.Users", "OccupationID", "dbo.Occupations");
            DropForeignKey("dbo.Users", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Flights", "DepartureAirport_AirportID", "dbo.Airports");
            DropForeignKey("dbo.Flights", "ArrivalAirport_AirportID", "dbo.Airports");
            DropIndex("dbo.Users", new[] { "Flight_FlightID" });
            DropIndex("dbo.Users", new[] { "OccupationID" });
            DropIndex("dbo.Users", new[] { "CompanyID" });
            DropIndex("dbo.Flights", new[] { "Airport_AirportID" });
            DropIndex("dbo.Flights", new[] { "Vehicle_VehicleID" });
            DropIndex("dbo.Flights", new[] { "DepartureAirport_AirportID" });
            DropIndex("dbo.Flights", new[] { "ArrivalAirport_AirportID" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Occupations");
            DropTable("dbo.Companies");
            DropTable("dbo.Users");
            DropTable("dbo.Flights");
            DropTable("dbo.Airports");
        }
    }
}
