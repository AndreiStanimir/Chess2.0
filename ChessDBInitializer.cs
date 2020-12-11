using Chess20.Common;
using Chess20.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Chess20
{
    public class ChessDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var score1 = new Score();
            var score2 = new Score();
            context.Scores.Add(score1);
            context.Scores.Add(score2);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //ApplicationUserManager userManager = new ApplicationUserManager();
            ApplicationUser admin = new ApplicationUser
            {
                UserName = "Andrei2",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),

                Email = "admin2@chess.com",
                //Password = "123",

                //Role = Roles.ApplicationUser,
                Score = score1
            };
            ApplicationUser player = new ApplicationUser
            {
                UserName = "Andrei1",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),

                Email = "player@chess.com",
                //Password = "123",

                //Role = Roles.ApplicationUser,
                Score = score2
            };
            userManager.Create(player);
            userManager.Create(admin);
            //List<ApplicationUser> users = new List<ApplicationUser>();
            //users.Add((ApplicationUser)admin);
            //users.Add((ApplicationUser)player);
            //context.UsersData.AddRange(users);

            Gamemode gamemode = new Gamemode
            {
                //GamemodeId = 0,
                Name = "Classic",
                Time = 10 * 60,
                Increment = 5
            };
            context.Gamemodes.Add(gamemode);

            Game game = new Game(gamemode)
            {
                Moves = "e4e5",
                Player1 = admin,
                Player2 = player,
                Winner = Winner.Draw
            };
            context.Games.Add(game);

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            base.Seed(context);
        }
    }
}