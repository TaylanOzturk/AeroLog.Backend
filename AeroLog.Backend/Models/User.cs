using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroLog.Backend.Models
{
    public class User 
    {
        public User()
        {
            this.Flights = new HashSet<Flight>();
        }
       public int UserID { get; set; }
       public string UserName { get; set; }
       public string UserSurname { get; set; }
       public string UserEmail { get; set; }
       public string UserPhone { get; set; }
       public string UserAdres { get; set; }
       public int CompanyID { get; set; }
       public int OccupationID { get; set; }
       public ICollection<Flight> Flights { get; set; }
       public virtual Company Company { get; set; }
       public virtual Occupation Occupation { get; set; } 


    }
}