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
    public class FixturesController : Controller
    {
        private FixturesDB db = new FixturesDB();

        // GET: Fixtures
        public ActionResult Index()
        {
            var fixtures = db.Fixtures.Include(f => f.Competition).Include(f => f.Referee);
            return View(fixtures.ToList());
        }

        // GET: Fixtures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // GET: Fixtures/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "CompetitionName");
            ViewBag.RefereeID = new SelectList(db.Referees, "RefereeID", "RefereeName");
            return View();
        }

        // POST: Fixtures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FixtureID,Gameweek,DatePlayed,TimePlayed,HomeTeamID,HTGoals,ATGoals,AwayTeamID,CompetitionID,RefereeID")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Fixtures.Add(fixture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "CompetitionName", fixture.CompetitionID);
            ViewBag.RefereeID = new SelectList(db.Referees, "RefereeID", "RefereeName", fixture.RefereeID);
            return View(fixture);
        }

        // GET: Fixtures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "CompetitionName", fixture.CompetitionID);
            ViewBag.RefereeID = new SelectList(db.Referees, "RefereeID", "RefereeName", fixture.RefereeID);
            return View(fixture);
        }

        // POST: Fixtures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FixtureID,Gameweek,DatePlayed,TimePlayed,HomeTeamID,HTGoals,ATGoals,AwayTeamID,CompetitionID,RefereeID")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "CompetitionName", fixture.CompetitionID);
            ViewBag.RefereeID = new SelectList(db.Referees, "RefereeID", "RefereeName", fixture.RefereeID);
            return View(fixture);
        }

        // GET: Fixtures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = db.Fixtures.Find(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // POST: Fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fixture fixture = db.Fixtures.Find(id);
            db.Fixtures.Remove(fixture);
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
