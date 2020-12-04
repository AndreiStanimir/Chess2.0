using Chess20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chess20
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext() : base("ChessDBConnectionString")
        {
            Database.SetInitializer(new ChessDBInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores{ get; set; }
        public DbSet<Gamemode> Gamemodes { get; set; }
        public DbSet<Game> Games { get; set; }


    }
}