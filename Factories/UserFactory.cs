using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chess20.Models;

namespace Chess20.Factories
{
    public class UserFactory
    {
        public static ApplicationUser GetAdmin()
        {
            return new ApplicationUser
            {
                UserName = "Andrei2",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),

                Email = "admin2@chess.com",
                //Password = "123",

                //Role = Roles.ApplicationUser,
                Score = new Score()
            };
        }

        public static ApplicationUser GetPlayer()
        {
            return new ApplicationUser
            {
                UserName = "Andrei1",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),

                Email = "player@chess.com",
                //Password = "123",

                //Role = Roles.ApplicationUser,
                Score = new Score()
            };
        }
    }
}