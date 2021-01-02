using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chess20.Common;
using Chess20.Models;

namespace Chess20.Controllers
{
    //[Authorize(Roles =RoleName.Admin)]
    public class GamemodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gamemodes
        public ActionResult Index()
        {
            return View(db.Gamemodes.ToList());
        }

        // GET: Gamemodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamemode gamemode = db.Gamemodes.Find(id);
            if (gamemode == null)
            {
                return HttpNotFound();
            }
            return View(gamemode);
        }

        // GET: Gamemodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gamemodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GamemodeId,Name,Time,Increment")] Gamemode gamemode)
        {
            if (ModelState.IsValid)
            {
                db.Gamemodes.Add(gamemode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gamemode);
        }

        // GET: Gamemodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamemode gamemode = db.Gamemodes.Find(id);
            if (gamemode == null)
            {
                return HttpNotFound();
            }
            return View(gamemode);
        }

        // POST: Gamemodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GamemodeId,Name,Time,Increment")] Gamemode gamemode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamemode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gamemode);
        }

        // GET: Gamemodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamemode gamemode = db.Gamemodes.Find(id);
            if (gamemode == null)
            {
                return HttpNotFound();
            }
            return View(gamemode);
        }

        // POST: Gamemodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gamemode gamemode = db.Gamemodes.Find(id);
            db.Gamemodes.Remove(gamemode);
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
