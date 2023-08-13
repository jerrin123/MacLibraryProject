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
    public class AudioTablesController : Controller
    {
        private LibraryDbEntities db = new LibraryDbEntities();

        // GET: AudioTables
        public ActionResult Index()
        {
            return View(db.AudioTables.ToList());
        }

        // GET: AudioTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTable audioTable = db.AudioTables.Find(id);
            if (audioTable == null)
            {
                return HttpNotFound();
            }
            return View(audioTable);
        }

        // GET: AudioTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AudioTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( AudioTable audioTable)
        {
            if (ModelState.IsValid)
            {

                audioTable.Ado_file.SaveAs(Server.MapPath("~/Audio/" + audioTable.Ado_file.FileName));
                //product.Prod_Pic = "~/ProPic/" + product.Pro_Pic.FileName;
                if (audioTable.Ado_file.FileName != "")
                {
                    audioTable.Audio_File = "~/Audio/" + audioTable.Ado_file.FileName;
                    db.AudioTables.Add(audioTable);
                    db.SaveChanges();
                }
                else
                {
                    audioTable.Audio_File = null;
                }

                return RedirectToAction("Index");
            }


            return View(audioTable);
        }

        // GET: AudioTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTable audioTable = db.AudioTables.Find(id);
            if (audioTable == null)
            {
                return HttpNotFound();
            }
            return View(audioTable);
        }

        // POST: AudioTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Audio_id,Audio_Name,Audio_Description,Audio_Subject,Audio_File")] AudioTable audioTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audioTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audioTable);
        }

        // GET: AudioTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTable audioTable = db.AudioTables.Find(id);
            if (audioTable == null)
            {
                return HttpNotFound();
            }
            return View(audioTable);
        }

        // POST: AudioTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AudioTable audioTable = db.AudioTables.Find(id);
            db.AudioTables.Remove(audioTable);
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
