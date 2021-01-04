using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroLog.Backend.Models
{
    public class Flight 
    {
        public int FlightID { get; set; }
        public string FlightCode { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public List<User> Users { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}