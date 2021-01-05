using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AeroLog.Backend.Models
{
    public class LogInitializer: DropCreateDatabaseIfModelChanges<AeroLogContext>
    {

        protected override void Seed(AeroLogContext context)
        {
            var users = new List<User>
            {
                new User{UserName="Taylan",UserSurname="Ozturk",UserEmail="taylann95@gmail.com",UserAdres="izmir",UserPhone="5555555555",CompanyID=1,OccupationID=1},
                new User{UserName="Huseyin",UserSurname="Akyuz",UserEmail="huseyin.akyuz13@gmail.com",UserAdres="izmir",UserPhone="5555555556",CompanyID=1,OccupationID=1},
                new User{UserName="Buse",UserSurname="Ozturk",UserEmail="k@gmail.com",UserAdres="ankara",UserPhone="5555555555",CompanyID=1,OccupationID=1},
                new User{UserName="Deniz",UserSurname="Ozturk",UserEmail="pp@gmail.com",UserAdres="izmir",UserPhone="5555555555",CompanyID=2,OccupationID=1},
                new User{UserName="Fatih",UserSurname="Ozturk",UserEmail="jj@gmail.com",UserAdres="izmir",UserPhone="5555555555",CompanyID=3,OccupationID=2},
                new User{UserName="Mehmet",UserSurname="Ozturk",UserEmail="mm@gmail.com",UserAdres="istanbul",UserPhone="5555555555",CompanyID=1,OccupationID=2},
                new User{UserName="Salih",UserSurname="Ozturk",UserEmail="taylann95@gmail.com",UserAdres="izmir",UserPhone="5555555555",CompanyID=1,OccupationID=2},
                new User{UserName="Muge",UserSurname="Ozturk",UserEmail="taylann95@gmail.com",UserAdres="mersin",UserPhone="5555555555",CompanyID=1,OccupationID=2},
                new User{UserName="Rasim",UserSurname="Ozturk",UserEmail="taylann95@gmail.com",UserAdres="frankfurt",UserPhone="5555555555",CompanyID=1,OccupationID=3}
            };
            users.ForEach(s => context.Users.Add(s));
            _ = context.SaveChanges();
        }
    }
}