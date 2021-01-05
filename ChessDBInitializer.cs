using Chess20.Common;
using Chess20.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static Chess20.Factories.UserFactory;

namespace Chess20
{
    public class ChessDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            LOOP://If initialization fails, solve error then try again
            try
            {
                ApplicationUser admin = null;
                ApplicationUser user = null;

                if (!roleManager.RoleExists(RoleName.Admin))
                {
                    // adaugam rolul de administrator
                    admin = AddAdmin(roleManager, userManager);
                }
                if (!roleManager.RoleExists(RoleName.Premium))
                {
                    user = AddPremium(roleManager, userManager);
                }
                if (!roleManager.RoleExists(RoleName.User))
                {
                    AddUser(roleManager, userManager);
                }

                Gamemode gamemode = new Gamemode(10 * 60, 5)
                {
                };
                context.Gamemodes.Add(gamemode);

                Game game = new Game(gamemode)
                {
                    Moves = "e4e5",
                    Player1 = admin,
                    Player2 = user,
                    Winner = Winner.Draw
                };
                context.Games.Add(game);

                try
                {
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
        }

        private static void AddUser(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var role = new IdentityRole
            {
                Name = RoleName.User
            };
            roleManager.Create(role);
            ApplicationUser player = GetPlayer();

            var userCreated = userManager.Create(player, "123123");
            if (userCreated.Succeeded)
            {
                userManager.AddToRole(player.Id, RoleName.User);
            }
        }

        private static ApplicationUser AddPremium(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            ApplicationUser user;
            var role = new IdentityRole();
            role.Name = RoleName.Premium;
            roleManager.Create(role);

            user = GetPremium();

            var premiumUserCreated = userManager.Create<ApplicationUser, string>(user, "123123");
            if (premiumUserCreated.Succeeded)
            {
                userManager.AddToRole(user.Id, RoleName.Premium);
            }

            return user;
        }

        private static ApplicationUser AddAdmin(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            ApplicationUser admin;
            var role = new IdentityRole();
            role.Name = RoleName.Admin;
            roleManager.Create(role);
            // se adauga utilizatorul administrator
            admin = GetAdmin();

            var adminCreated = userManager.Create<ApplicationUser, string>(admin, "123123");
            if (adminCreated.Succeeded)
            {
                userManager.AddToRole(admin.Id, RoleName.Admin);
            }

            return admin;
        }
    }
}