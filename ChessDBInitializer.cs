using Chess20.Common;
using Chess20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chess20
{
    public class ChessDBInitializer : DropCreateDatabaseAlways<ChessDbContext>
    {
        protected override void Seed(ChessDbContext context)
        {

            User admin = new User
            {
                UserId = 0,
                Email = "admin@chess.com",
                Password = "123",
                Name = "admin",
                Role = Roles.Admin,
                Score = new Score()
            };
            User player = new User
            {
                UserId = 1,
                Email = "player@chess.com",
                Password = "123",
                Name = "player",
                Role = Roles.User,
                Score = new Score()
            };
            List<User> users = new List<User>();
            users.Add(admin);
            users.Add(player);
            context.Users.AddRange(users);

            Gamemode gamemode = new Gamemode
            {
                GamemodeId = 0,
                Name = "Classic",
                Time = 10 * 60,
                Increment = 5
            };
            context.Gamemodes.Add(gamemode);

            Game game = new Game
            {
                GameId = 0,
                Moves = "e4e5",
                //Player1 = admin,
                //Player2 = player,
                Winner = Winner.Draw
            };
            context.Games.Add(game);
            context.Scores.Add(new Score());

            context.SaveChanges();
            base.Seed(context);
        }
    }
}