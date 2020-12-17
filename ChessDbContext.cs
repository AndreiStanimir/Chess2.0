using System.Data.Entity;

namespace Chess20
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext() : base("ChessDBConnectionString")
        {
            //Database.SetInitializer(new ChessDBInitializer());
        }

        public System.Data.Entity.DbSet<Chess20.Models.Game> Games { get; set; }

        public System.Data.Entity.DbSet<Chess20.Models.Gamemode> Gamemodes { get; set; }
    }
}