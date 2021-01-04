using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroLog.Backend.Models
{
    public class Occupation
    {
        public Occupation()
        {
            this.Users = new HashSet<User>();
        }
        public int OccupationID { get; set; }
        public string OccupationName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}