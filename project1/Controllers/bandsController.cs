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

namespace project1.Controllers
{
    public class bandsController : Controller
    {
        private projectContext db = new projectContext();

        // GET: bands
        public ActionResult Index()
        {
            return View(db.bands.ToList());
        }

        // GET: bands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bands bands = db.bands.Find(id);
            if (bands == null)
            {
                return HttpNotFound();
            }
            return View(bands);
        }

        // GET: bands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,genre")] bands bands)
        {
            if (ModelState.IsValid)
            {
                db.bands.Add(bands);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bands);
        }

        // GET: bands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bands bands = db.bands.Find(id);
            if (bands == null)
            {
                return HttpNotFound();
            }
            return View(bands);
        }

        // POST: bands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,genre")] bands bands)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bands).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bands);
        }

        // GET: bands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bands bands = db.bands.Find(id);
            if (bands == null)
            {
                return HttpNotFound();
            }
            return View(bands);
        }

        // POST: bands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bands bands = db.bands.Find(id);
            db.bands.Remove(bands);
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
