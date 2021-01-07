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
using Chess20.Models.Entities;

namespace Chess20.Controllers
{
    public class PuzzlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlayPuzzle
        [Authorize(Roles = RoleName.Premium + "," + RoleName.Admin)]
        public ActionResult PlayPuzzle()
        {
            return View();
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Index()
        {
            return View(db.Puzzles.ToList());
        }

        // GET: Puzzles/Details/5
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puzzle puzzle = db.Puzzles.Find(id);
            if (puzzle == null)
            {
                return HttpNotFound();
            }
            return View(puzzle);
        }

        // GET: Puzzles/Create
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puzzles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create([Bind(Include = "PuzzleId,Moves,StartingPosition,Elo")] Puzzle puzzle)
        {
            if (ModelState.IsValid)
            {
                db.Puzzles.Add(puzzle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(puzzle);
        }

        // GET: Puzzles/Edit/5
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puzzle puzzle = db.Puzzles.Find(id);
            if (puzzle == null)
            {
                return HttpNotFound();
            }
            return View(puzzle);
        }

        // POST: Puzzles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit([Bind(Include = "PuzzleId,Moves,StartingPosition,Elo")] Puzzle puzzle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puzzle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puzzle);
        }

        // GET: Puzzles/Delete/5
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puzzle puzzle = db.Puzzles.Find(id);
            if (puzzle == null)
            {
                return HttpNotFound();
            }
            return View(puzzle);
        }

        // POST: Puzzles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            Puzzle puzzle = db.Puzzles.Find(id);
            db.Puzzles.Remove(puzzle);
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