﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Chess20.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chess20.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManager;
        //GET: ApplicationUsers
        public ApplicationUsersController()
        {
             userManager= new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }
        public ActionResult Index()
        {
            //var r = Roles.GetRolesForUser();
            return View(db.Users.ToList());
        }
        // GET: ApplicationUsers/IndexByRole/Role
        //[Route("ApplicationUsers/IndexByRole/{role}")]
        public ActionResult IndexByRole(string id = "User")
        {
            //TODO: add try catch
            var roleFromDb = db.Roles.Where(r => r.Name == id).FirstOrDefault();
            if (roleFromDb == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roleId = roleFromDb.Id;
            List<ApplicationUser> filteredUsers = db.Users
                .Where(u => u.Roles
                .Any(r => r.RoleId == roleId))
                .ToList();
            return View(filteredUsers);
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = (ApplicationUser)db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Name")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = (ApplicationUser)db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            string role = "User";// db.Roles.Where(r => r. == id).FirstOrDefault();


            EditUserViewModel user = new EditUserViewModel()
            {
                Id=applicationUser.Id,
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                Role = role
            };
            return View(user);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Exclude = "Score", Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Name,Roles")] ApplicationUser applicationUser)
        public ActionResult Edit(EditUserViewModel editUserViewModel)
        //public ActionResult Edit(ApplicationUser applicationUser)

        {
            //applicationUser.Score = db.Scores.Where(s => s.ApplicationUser == applicationUser).FirstOrDefault();
            var applicationUser = db.Users.Find(editUserViewModel.Id);
            //TODO check null
            if (ModelState.IsValid)
            {
                applicationUser.UserName = editUserViewModel.UserName;
                applicationUser.Email = editUserViewModel.Email;
                applicationUser.Score = applicationUser.Score;
                //db.Entry(applicationUser).Property("Score").IsModified = false;
                userManager.RemoveFromRoles(applicationUser.Id, userManager.GetRoles(applicationUser.Id).ToArray());
                userManager.AddToRole(applicationUser.Id, editUserViewModel.Role);
                //db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = (ApplicationUser)db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = (ApplicationUser)db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
