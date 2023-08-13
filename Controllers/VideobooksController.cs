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
    public class VideobooksController : Controller
    {
        private LibraryDbEntities db = new LibraryDbEntities();

        // GET: Videobooks
        public ActionResult Index()
        {
            return View(db.Videobooks.ToList());
        }

        // GET: Videobooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videobook videobook = db.Videobooks.Find(id);
            if (videobook == null)
            {
                return HttpNotFound();
            }
            return View(videobook);
        }

        // GET: Videobooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videobooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Videobook videobook)
        {
           
            if (ModelState.IsValid)
            {

                videobook.Vdo_file.SaveAs(Server.MapPath("~/OutPic/" + videobook.Vdo_file.FileName));
                //product.Prod_Pic = "~/ProPic/" + product.Pro_Pic.FileName;
                if (videobook.Vdo_file.FileName != "")
                {
                    videobook.Video_File = "~/OutPic/" + videobook.Vdo_file.FileName;
                    db.Videobooks.Add(videobook);
                    db.SaveChanges();
                }
                else
                {
                    videobook.Video_File = null;
                }

                return RedirectToAction("Index");
            }



            return View(videobook);
        }

        // GET: Videobooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videobook videobook = db.Videobooks.Find(id);
            if (videobook == null)
            {
            https://localhost:44368/Models/contact.cs
                return HttpNotFound();
            }
            return View(videobook);

        }

        // POST: Videobooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Video_ID,Video_Name,Video_File,Video_Description,Video_Subject")] Videobook videobook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videobook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videobook);
        }

        // GET: Videobooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videobook videobook = db.Videobooks.Find(id);
            if (videobook == null)
            {
                return HttpNotFound();
            }
            return View(videobook);
        }

        // POST: Videobooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Videobook videobook = db.Videobooks.Find(id);
            db.Videobooks.Remove(videobook);
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
