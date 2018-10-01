using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballFixtures;

namespace FootballFixtures.Controllers
{
    public class PlayerFixturesController : Controller
    {
        private FixturesDB db = new FixturesDB();

        // GET: PlayerFixtures
        public ActionResult Index()
        {
            var playerFixtures = db.PlayerFixtures.Include(p => p.Fixture).Include(p => p.Player);
            return View(playerFixtures.ToList());
        }

        // GET: PlayerFixtures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerFixture playerFixture = db.PlayerFixtures.Find(id);
            if (playerFixture == null)
            {
                return HttpNotFound();
            }
            return View(playerFixture);
        }

        // GET: PlayerFixtures/Create
        public ActionResult Create()
        {
            ViewBag.FixtureID = new SelectList(db.Fixtures, "FixtureID", "FixtureID");
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName");
            return View();
        }

        // POST: PlayerFixtures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerFixturesID,FixtureID,TeamID,PlayerID,GoalsScored,YellowCards,RedCards,Assists")] PlayerFixture playerFixture)
        {
            if (ModelState.IsValid)
            {
                db.PlayerFixtures.Add(playerFixture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FixtureID = new SelectList(db.Fixtures, "FixtureID", "FixtureID", playerFixture.FixtureID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", playerFixture.PlayerID);
            return View(playerFixture);
        }

        // GET: PlayerFixtures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerFixture playerFixture = db.PlayerFixtures.Find(id);
            if (playerFixture == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixtureID = new SelectList(db.Fixtures, "FixtureID", "FixtureID", playerFixture.FixtureID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", playerFixture.PlayerID);
            return View(playerFixture);
        }

        // POST: PlayerFixtures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerFixturesID,FixtureID,TeamID,PlayerID,GoalsScored,YellowCards,RedCards,Assists")] PlayerFixture playerFixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerFixture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixtureID = new SelectList(db.Fixtures, "FixtureID", "FixtureID", playerFixture.FixtureID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", playerFixture.PlayerID);
            return View(playerFixture);
        }

        // GET: PlayerFixtures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerFixture playerFixture = db.PlayerFixtures.Find(id);
            if (playerFixture == null)
            {
                return HttpNotFound();
            }
            return View(playerFixture);
        }

        // POST: PlayerFixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerFixture playerFixture = db.PlayerFixtures.Find(id);
            db.PlayerFixtures.Remove(playerFixture);
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
