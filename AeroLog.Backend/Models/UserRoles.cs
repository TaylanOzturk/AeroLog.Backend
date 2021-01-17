using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroLog.Backend.Models
{
    public class UserRoles
    {
        public int UserRolesID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}