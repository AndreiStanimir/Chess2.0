using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chess20.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ChessDBConnectionString")
        {
            Database.SetInitializer(new ChessDBInitializer());
        }

        //public  DbSet<ApplicationUser> UsersData { get; set; } //useless
        public DbSet<Score> Scores { get; set; }
        public DbSet<Gamemode> Gamemodes { get; set; }
        public DbSet<Game> Games { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        //public System.Data.Entity.DbSet<Chess20.Models.ApplicationUser> ApplicationUsers { get; set; }
        //        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //        {
        //            //base.OnModelCreating(modelBuilder);
        //            modelBuilder.Entity<TUserRole>()
        //            .HasKey(r => new {r.UserId, r.RoleId})
        //            .ToTable("AspNetUserRoles");

        //modelBuilder.Entity<TUserLogin>()
        //            .HasKey(l => new {l.LoginProvider, l.ProviderKey, l.UserId})
        //            .ToTable("AspNetUserLogins");
        //        }
    }
}