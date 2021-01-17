using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
       [Required]
        [DataType(DataType.EmailAddress)]
       public string UserEmail { get; set; }
       [Required]
       [DataType(DataType.Password)]
       public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
       public string UserPhone { get; set; }
       public string UserAdres { get; set; }
        
       public int? CompanyID { get; set; }
       public int? OccupationID { get; set; }
      
        public int RoleID { get; set; }
       public ICollection<Flight> Flights { get; set; }
       public virtual Company Company { get; set; }
       public virtual Occupation Occupation { get; set; } 
        public virtual ICollection<Role> Roles { get; set; }


    }
}