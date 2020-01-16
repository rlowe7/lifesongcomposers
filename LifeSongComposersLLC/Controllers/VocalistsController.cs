using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LifeSongComposersLLC.Models;

namespace LifeSongComposersLLC.Controllers
{
    public class VocalistsController : Controller
    {
        private LifeSongComposersLLCContext db = new LifeSongComposersLLCContext();

        // GET: Vocalists
        public ActionResult Index()
        {
            return View(db.Vocalists.ToList());
        }
        //pull over track id to show on UI
        public ActionResult Index(int Id)
        {
            Track track = db.Tracks.Find(Id);
            TrackVocalistViewModel trackVocalist = new TrackVocalistViewModel();
            

            return View(db.Vocalists.ToList());
        }

        // GET: Vocalists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocalist vocalist = db.Vocalists.Find(id);
            if (vocalist == null)
            {
                return HttpNotFound();
            }
            return View(vocalist);
        }

        // GET: Vocalists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vocalists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VocalistId,FirstName,LastName,Description,CreatedDate,CreatedBy")] Vocalist vocalist)
        {
            if (ModelState.IsValid)
            {
                db.Vocalists.Add(vocalist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vocalist);
        }

        // GET: Vocalists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocalist vocalist = db.Vocalists.Find(id);
            if (vocalist == null)
            {
                return HttpNotFound();
            }
            return View(vocalist);
        }

        // POST: Vocalists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VocalistId,FirstName,LastName,Description,CreatedDate,CreatedBy")] Vocalist vocalist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vocalist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vocalist);
        }

        // GET: Vocalists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocalist vocalist = db.Vocalists.Find(id);
            if (vocalist == null)
            {
                return HttpNotFound();
            }
            return View(vocalist);
        }

        // POST: Vocalists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vocalist vocalist = db.Vocalists.Find(id);
            db.Vocalists.Remove(vocalist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult VocalistTrack(int id)
        {
            Track track = db.Tracks.Find(id);

            return View();
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
