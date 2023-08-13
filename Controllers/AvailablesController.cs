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
    public class AvailablesController : Controller
    {
        private LibraryDbEntities db = new LibraryDbEntities();

        // GET: Availables
        public ActionResult Index()
        {
            var availables = db.Availables.Include(a => a.Item);
            return View(availables.ToList());
        }

        // GET: Availables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Available available = db.Availables.Find(id);
            if (available == null)
            {
                return HttpNotFound();
            }
            return View(available);
        }

        // GET: Availables/Create
        public ActionResult Create()
        {
            ViewBag.Item_fid = new SelectList(db.Items, "item_id", "item_name");
            return View();
        }

        // POST: Availables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Available_Id,Item_Type,Current_Location,Collection,Shelf_Number,Status,Barcode,Item_fid")] Available available)
        {
            if (ModelState.IsValid)
            {
                db.Availables.Add(available);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_fid = new SelectList(db.Items, "item_id", "item_name", available.Item_fid);
            return View(available);
        }

        // GET: Availables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Available available = db.Availables.Find(id);
            if (available == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_fid = new SelectList(db.Items, "item_id", "item_name", available.Item_fid);
            return View(available);
        }

        // POST: Availables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Available_Id,Item_Type,Current_Location,Collection,Shelf_Number,Status,Barcode,Item_fid")] Available available)
        {
            if (ModelState.IsValid)
            {
                db.Entry(available).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_fid = new SelectList(db.Items, "item_id", "item_name", available.Item_fid);
            return View(available);
        }

        // GET: Availables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Available available = db.Availables.Find(id);
            if (available == null)
            {
                return HttpNotFound();
            }
            return View(available);
        }

        // POST: Availables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Available available = db.Availables.Find(id);
            db.Availables.Remove(available);
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
