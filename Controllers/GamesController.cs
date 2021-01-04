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
    //[Authorize(Roles = RoleName.Admin)]
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {

            List<SelectListItem> users = db.Users
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                })
                .ToList();
            List<SelectListItem> gamemodes = db.Gamemodes.Select(g => new SelectListItem
            {
                Value = g.GamemodeId.ToString(),
                Text = g.Name
            }).ToList();
            ViewBag.Users = users;
            ViewBag.Gamemodes = gamemodes;
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Player1Id,Player2Id,GamemodeId,Moves,Winner")] GameCreateViewModel gameCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var player1 = db.Users.Find(gameCreateViewModel.Player1Id);
                var player2 = db.Users.Find(gameCreateViewModel.Player2Id);
                var gamemode = db.Gamemodes.Find(gameCreateViewModel.GamemodeId);

                if (gamemode == null)
                    gamemode = new Gamemode(1, 0);

                Game game = new Game(gamemode)
                {
                    GameId = gameCreateViewModel.GameId,
                    Player1 = player1,
                    Player2 = player2,
                    Moves = gameCreateViewModel.Moves,
                    Winner = gameCreateViewModel.Winner,
                    //Timer1=gameCreateViewModel.Timer1,
                    //Timer2= gameCreateViewModel.Timer2,
                    

                };
                
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameCreateViewModel);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Timer1,Timer2,Moves,Winner")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
