using Chess20.Common;
using Chess20.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            User admin = new User
            {
                Email = "admin@chess.com",
                Password = "123",
                Name = "admin",
                Role = Roles.Admin,
                Score = score1
            };

            User player = new User
            {
                Email = "player@chess.com",
                Password = "123",
                Name = "player",
                Role = Roles.User,
                Score = score2
            };
            List<User> users = new List<User>();
            users.Add(admin);
            users.Add(player);

            context.UsersData.AddRange(users);
            Gamemode gamemode = new Gamemode
            {
                //GamemodeId = 0,
                Name = "Classic",
                Time = 10 * 60,
                Increment = 5
            };
            context.Gamemodes.Add(gamemode);

            Game game = new Game
            {
                Moves = "e4e5",
                Player1 = admin,
                Player2 = player,
                Winner = Winner.Draw
            };
            context.Games.Add(game);


            context.SaveChanges();
            base.Seed(context);
        }
    }
}