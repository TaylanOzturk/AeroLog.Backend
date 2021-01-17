using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AeroLog.Backend.Models
{
    public class Flight 
    {
        public Flight()
        {
            this.Users = new HashSet<User>();
        }
        public int FlightID { get; set; }
        public string FlightCode { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Departure { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Arrival { get; set; }
        public string UserID { get; set; }
        public ICollection<User> Users { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }

    }
}