using Chess20.Models;
using System;
using Chess20.Models.Entities;

namespace Chess20.Factories
{
    public class UserFactory
    {
        public static ApplicationUser GetAdmin()
        {
            return new ApplicationUser
            {
                Id = Guid.NewGuid().ToString("D"),
                UserName = "admin",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Email = "admin@chess.com",
                Score = new Score()
            };
        }

        public static ApplicationUser GetPlayer()
        {
            return new ApplicationUser
            {
                UserName = "user",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Email = "player@chess.com",
                Score = new Score()
            };
        }

        public static ApplicationUser GetPremium()
        {
            return new ApplicationUser
            {
                UserName = "premium",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Email = "premium@chess.com",
                Score = new Score()
            };
        }
    }
}