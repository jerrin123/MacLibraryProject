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
    public class staffsController : Controller
    {
        private LibraryDbEntities db = new LibraryDbEntities();

        // GET: staffs
        public ActionResult Index()
        {
            return View(db.staffs.ToList());
        }

        // GET: staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(staff a)
        {
            int res = db.staffs.Where(x => x.staff_email == a.staff_email && x.staff_password == a.staff_password).Count();
            if (res == 1)
            {
                return RedirectToAction("Dash", "staffs");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username/Password'); </script>");
                return View();
            }
        }
        public ActionResult Dash()
        {
            return View();
        }

        // GET: staffs/Create
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "staff_id,staff_name,staff_phone,staff_email,staff_password")] staff staff)
        {
            if (ModelState.IsValid)
            {
                db.staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("LogIn");
            }

            return View(staff);
        }

        // GET: staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "staff_id,staff_name,staff_phone,staff_email,staff_password")] staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            staff staff = db.staffs.Find(id);
            db.staffs.Remove(staff);
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
