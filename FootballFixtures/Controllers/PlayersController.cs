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
    public class PlayersController : Controller
    {
        private FixturesDB db = new FixturesDB();

        // GET: Players
        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Injury).Include(p => p.Nationality).Include(p => p.Position).Include(p => p.Team);
            return View(players.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.InjuryID = new SelectList(db.Injuries, "InjuryID", "InjuryDescription");
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "Nationality1");
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "PositionName");
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,TeamID,PlayerName,PlayerSquadNumber,PositionID,InjuryID,NationalityID")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InjuryID = new SelectList(db.Injuries, "InjuryID", "InjuryDescription", player.InjuryID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "Nationality1", player.NationalityID);
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "PositionName", player.PositionID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", player.TeamID);
            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.InjuryID = new SelectList(db.Injuries, "InjuryID", "InjuryDescription", player.InjuryID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "Nationality1", player.NationalityID);
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "PositionName", player.PositionID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", player.TeamID);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,TeamID,PlayerName,PlayerSquadNumber,PositionID,InjuryID,NationalityID")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InjuryID = new SelectList(db.Injuries, "InjuryID", "InjuryDescription", player.InjuryID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "Nationality1", player.NationalityID);
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "PositionName", player.PositionID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", player.TeamID);
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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
