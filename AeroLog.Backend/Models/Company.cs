using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroLog.Backend.Models
{
    public class Company
    {
        public Company()
        {
            this.Users = new HashSet<User>();
        }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}