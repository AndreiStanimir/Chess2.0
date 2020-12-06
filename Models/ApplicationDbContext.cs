using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chess20.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("ChessDBConnectionString")
        {
            Database.SetInitializer(new ChessDBInitializer());
        }

        public DbSet<ApplicationUser> UsersData { get; set; } //useless
        public DbSet<Score> Scores { get; set; }
        public DbSet<Gamemode> Gamemodes { get; set; }
        public DbSet<Game> Games { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}