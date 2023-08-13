using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MacLibraryProject.Models;

namespace MacLibraryProject.Controllers
{
    public class carrersController : Controller
    {
        private LibraryDbEntities db = new LibraryDbEntities();

        // GET: carrers
        public ActionResult Index()
        {
            return View(db.carrers.ToList());
        }

        // GET: carrers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrer carrer = db.carrers.Find(id);
            if (carrer == null)
            {
                return HttpNotFound();
            }
            return View(carrer);
        }

        // GET: carrers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: carrers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carrer_id,carrer_name,carrer_position,carrer_qualification,carrer_desc")] carrer carrer)
        {
            if (ModelState.IsValid)
            {
                db.carrers.Add(carrer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrer);
        }

        // GET: carrers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrer carrer = db.carrers.Find(id);
            if (carrer == null)
            {
                return HttpNotFound();
            }
            return View(carrer);
        }

        // POST: carrers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carrer_id,carrer_name,carrer_position,carrer_qualification,carrer_desc")] carrer carrer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrer);
        }

        // GET: carrers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrer carrer = db.carrers.Find(id);
            if (carrer == null)
            {
                return HttpNotFound();
            }
            return View(carrer);
        }

        // POST: carrers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carrer carrer = db.carrers.Find(id);
            db.carrers.Remove(carrer);
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
