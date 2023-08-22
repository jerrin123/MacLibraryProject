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
    public class DbooksController : Controller
    {
        private LibraryDbEntities db = new LibraryDbEntities();

        // GET: Dbooks
        public ActionResult Index()
        {
            return View(db.Dbooks.ToList());
        }

        // GET: Dbooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dbook dbook = db.Dbooks.Find(id);
            if (dbook == null)
            {
                return HttpNotFound();
            }
            return View(dbook);
        }

        // GET: Dbooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dbooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Dbook dbook)
        {
            if (ModelState.IsValid)
            {

                dbook.Ebk_file.SaveAs(Server.MapPath("~/Book/" + dbook.Ebk_file.FileName));
                //product.Prod_Pic = "~/ProPic/" + product.Pro_Pic.FileName;
                if (dbook.Ebk_file.FileName != "")
                {
                    dbook.Ebook_Pdf = "~/Book/" + dbook.Ebk_file.FileName;
                    db.Dbooks.Add(dbook);
                    db.SaveChanges();
                }
                else
                {
                    dbook.Ebook_Pdf = null;
                }

                return RedirectToAction("Index");
            }

            return View(dbook);
        }

        // GET: Dbooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dbook dbook = db.Dbooks.Find(id);
            if (dbook == null)
            {
                return HttpNotFound();
            }
            return View(dbook);
        }

        // POST: Dbooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ebooks_Id,Ebook_Name,Ebook_Decription,Ebook_Pdf,Ebook_Author")] Dbook dbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbook);
        }

        // GET: Dbooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dbook dbook = db.Dbooks.Find(id);
            if (dbook == null)
            {
                return HttpNotFound();
            }
            return View(dbook);
        }

        // POST: Dbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dbook dbook = db.Dbooks.Find(id);
            db.Dbooks.Remove(dbook);
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
