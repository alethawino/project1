using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project1.DAL;
using project1.Models;
using System.Diagnostics;

namespace project1.Controllers
{
    public class albumsController : Controller
    {
        private projectContext db = new projectContext();

        // GET: albums
        public ActionResult Index()
        {
            Debug.WriteLine("here");
            return View(db.album.ToList());
        }

        // GET: albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = db.album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        // GET: albums/Create
        public ActionResult Create()
        {
            ViewBag.band = db.bands.ToList();
            return View();
        }

        // POST: albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,names,yearReleased,producer,recodLabel,Price")] album album,int band)
        {
            if (ModelState.IsValid) 

            {
                album.band = db.bands.Find(band);
                db.album.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            
            return View(album);
        }

        // GET: albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = db.album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            // ViewBag.band = db.bands.ToList();
            // ViewBag.albumBands = album.band.ID;
            ViewBag.Band_Id = new SelectList(db.bands, "Id", "Name", album.band.ID);
            return View(album);
        }

        // POST: albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,names,yearReleased,producer,recodLabel,Price,Band_Id")] album album)

        {
            if (ModelState.IsValid)
            {
               // album.band = db.bands.Find(band);
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = db.album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            album album = db.album.Find(id);
            db.album.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search(string AlbumName, string BandName)
        {
            List<album> Albums = db.album.Where(a => a.names.ToUpper().Contains(AlbumName.ToUpper()) && a.band.Name.ToUpper().Contains(BandName.ToUpper())).ToList();
            return View(Albums);
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
