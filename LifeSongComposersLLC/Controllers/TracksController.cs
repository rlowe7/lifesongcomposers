using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LifeSongComposersLLC.Models;

namespace LifeSongComposersLLC.Controllers
{
    public class TracksController : Controller
    {
        private LifeSongComposersLLCContext db = new LifeSongComposersLLCContext();

        // GET: Tracks
        public ActionResult Index()
        {
            var tracks = db.Tracks.Include(t => t.Genre);
            return View(tracks.ToList());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Artist,Description,Url,GenreId,CreatedDate,CreatedBy")] Track track, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    if (upload != null && upload.ContentLength > 0)
                    {

                        string fileName = Path.GetFileName(upload.FileName);
                        string path = Path.Combine(Server.MapPath("~/mp3/"), fileName);
                        upload.SaveAs(path);

                        track.Url = "mp3/" + fileName;
                        track.CreatedBy = "admin";
                        track.CreatedDate = DateTime.Now;
                        db.Tracks.Add(track);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "No file chosen or empty file";
                        ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
                        return View(track);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "File upload Failed " + ex.ToString();
                    ViewBag.GenresId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
                    return View(track);
                }

            }

           
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View(track);



        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Artist,Description,Url,GenreId,CreatedDate,CreatedBy")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            return View(track);
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
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
