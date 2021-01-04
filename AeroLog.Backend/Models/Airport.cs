using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroLog.Backend.Models
{
    public class Airport
    {
        public Airport()
        {
            this.Flights = new HashSet<Flight>();
        }
        public int AirportID { get; set; }
        public string AirportName { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}