using Chess20.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management;
using System.Data.Entity;
using Microsoft.SqlServer.Management.Smo;
using Chess20.Common;

[assembly: OwinStartupAttribute(typeof(Chess20.Startup))]

namespace Chess20
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdminAndUserRoles();
        }

        public void CreateAdminAndUserRoles()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));
            // adaugam rolurile pe care le poate avea un utilizator
            // din cadrul aplicatiei
            LOOP://If initialization fails, solve error then try again
            try
            {
                if (!roleManager.RoleExists(RoleName.Admin))
                {
                    // adaugam rolul de administrator
                    var role = new IdentityRole();
                    role.Name = RoleName.Admin;
                    roleManager.Create(role);
                    // se adauga utilizatorul administrator
                    var score = new Score();
                    var user = new ApplicationUser
                    {
                        UserName = "admin@admin.com",
                        Email = "admin@admin.com",
                        Score = score
                    };

                    var adminCreated = userManager.Create<ApplicationUser, string>(user, "Premium2020!");
                    if (adminCreated.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Admin");
                    }
                }
                if (!roleManager.RoleExists(RoleName.Premium))
                {
                    var role = new IdentityRole();
                    role.Name = RoleName.Premium;
                    roleManager.Create(role);
                    //var user = new ApplicationUser
                    //{
                    //    UserName = "premium",
                    //    Email = "premium@admin.com",
                    //    Score = new Score()
                    //};

                    //var premiumUserCreated = userManager.Create<ApplicationUser, string>(user, "Admin2020!");
                    //if (premiumUserCreated.Succeeded)
                    //{
                    //    userManager.AddToRole(user.Id,RoleName.Premium);
                    //}
                }
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060) // nice
                {
                    var dbName = e.Message.Split('\"')[1];
                    Server server = new Server(@"(localdb)\MSSQLLocalDB");
                    var database = new Microsoft.SqlServer.Management.Smo.Database(server, dbName);
                    database.Refresh();
                    server.KillAllProcesses(dbName);
                    database.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                    //database.Alter(TerminationClause.RollbackTransactionsImmediately);
                    goto LOOP;
                }
                else
                    throw;
            }
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                roleManager.Create(role);
                // se adauga utilizatorul
                var score = new Score();
                context.Scores.Add(score);
                var user = new ApplicationUser
                {
                    UserName = "player@chess.com",
                    Email = "player@admin.com",
                    Score = score
                };
                var userCreated = userManager.Create(user, "User");
                if (userCreated.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
            }

            //Seed(ctx);
        }

        //protected void Seed(ApplicationDbContext context)
        //{
        //    var score1 = new Score();
        //    var score2 = new Score();
        //    context.Scores.Add(score1);
        //    context.Scores.Add(score2);
        //    var idAdminRole = context.Roles.FirstOrDefault().Id;
        //    var admin = (ApplicationUser)context.Users.Find(u => u.Roles.Any(r => r.RoleId == idAdminRole)).FirstOrDefault();
        //    var player = new ApplicationUser();
        //    //ApplicationUserManager userManager = new ApplicationUserManager();
        //    //ApplicationUser player = new ApplicationUser
        //    //{
        //    //    UserName = "Andrei",
        //    //    PhoneNumber = "+111111111111",
        //    //    EmailConfirmed = true,
        //    //    PhoneNumberConfirmed = true,
        //    //    SecurityStamp = Guid.NewGuid().ToString("D"),

        //    //    Email = "player@chess.com",
        //    //    //Password = "123",
        //    //    Name = "player",

        //    //    //Role = Roles.ApplicationUser,
        //    //    Score = score2
        //    //};
        //    List<ApplicationUser> users = new List<ApplicationUser>();
        //    users.Add((ApplicationUser)admin);
        //    users.Add((ApplicationUser)player);

        //    context.UsersData.AddRange(users);
        //    Gamemode gamemode = new Gamemode
        //    {
        //        //GamemodeId = 0,
        //        Name = "Classic",
        //        Time = 10 * 60,
        //        Increment = 5
        //    };
        //    context.Gamemodes.Add(gamemode);

        //    Game game = new Game
        //    {
        //        Moves = "e4e5",
        //        Player1 = admin,
        //        Player2 = player,
        //        Winner = Winner.Draw
        //    };
        //    context.Games.Add(game);

        //    context.SaveChanges(); ;
        //}
    }
}