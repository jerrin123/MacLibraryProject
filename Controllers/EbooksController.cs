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
    public class EbooksController : Controller
    {
        private LibraryDbEntities db = new LibraryDbEntities();

        // GET: Ebooks
        public ActionResult Index()
        {
            return View(db.Ebooks.ToList());
        }

        // GET: Ebooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = db.Ebooks.Find(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            return View(ebook);
        }

        // GET: Ebooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ebooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Ebook ebook)
        {
            if (ModelState.IsValid)
            {

                ebook.Eb_File.SaveAs(Server.MapPath("~/Book/" + ebook.Eb_File.FileName));
                //product.Prod_Pic = "~/ProPic/" + product.Pro_Pic.FileName;
                if (ebook.Eb_File.FileName != "")
                {
                    ebook.Ebook_Pdf = "~/Book/" + ebook.Eb_File.FileName;
                    db.Ebooks.Add(ebook);
                    db.SaveChanges();
                }
                else
                {
                    ebook.Ebook_Pdf = null;
                }

                return RedirectToAction("Index");
            }

            return View(ebook);
        }

        // GET: Ebooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = db.Ebooks.Find(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            return View(ebook);
        }

        // POST: Ebooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ebook_Id,Ebook_Name,Ebook_Decription,Ebook_Pdf,Ebook_Author")] Ebook ebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ebook);
        }

        // GET: Ebooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = db.Ebooks.Find(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            return View(ebook);
        }

        // POST: Ebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ebook ebook = db.Ebooks.Find(id);
            db.Ebooks.Remove(ebook);
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
