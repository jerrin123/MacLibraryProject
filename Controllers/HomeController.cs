using MacLibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MacLibraryProject.Controllers
{
    public class HomeController : Controller
    {
        private LibraryDbEntities db = new LibraryDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Items(int? id)
        {
            ItemModel o = new ItemModel();

            o.cat = db.Categories.ToList();


            if (id == null)
            {
                o.it = db.Items.ToList();
            }
            else
            {
                o.it = db.Items.Where(z => z.cat_fid == id).ToList();
            }

            return View(o);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Admin()
        {
            

            return View();
        }
    }
}