using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroLog.Backend.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.Flights = new HashSet<Flight>();
        }
        public int VehicleID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleCode { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}