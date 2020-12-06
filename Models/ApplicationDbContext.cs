using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chess20.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ChessDBConnectionString", throwIfV1Schema: false)
        {
            Database.SetInitializer(new ChessDBInitializer());
        }

        public DbSet<User> UsersData { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Gamemode> Gamemodes { get; set; }
        public DbSet<Game> Games { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}