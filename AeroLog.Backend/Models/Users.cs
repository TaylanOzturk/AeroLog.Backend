using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroLog.Backend.Models
{
    public class Users
    {   
        public int ID { get; set; }

    }
    public class UsersDBContext : DbContext
    {

    }
}