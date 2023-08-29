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
        public ActionResult repo()
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
        public ActionResult Guidlines()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Reviewpage()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Audiohome()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Videohome()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Ebookhome()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Questionhome()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Commitee()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Staff()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Service()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Collection()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult userd()
        {
            return View();
        }
        public ActionResult com()
        {
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



        //public ActionResult Books()
        //{


        //    return View();

        //}
        public ActionResult VideoB(int? id)
        {
            VideoModel o = new VideoModel();




            if (id == null)
            {
                o.Vid = db.Videobooks.ToList();
            }
            else
            {
                // o.Out = db.VideoB.Where(z => z.branch_fid == id).ToList();
            }

            return View(o);

        }
        public ActionResult AudioB(int? id)
        {
            AudioModel o = new AudioModel();




            if (id == null)
            {
                o.Aid = db.AudioTables.ToList();
            }
            else
            {
                // o.Out = db.VideoB.Where(z => z.branch_fid == id).ToList();
            }

            return View(o);

        }
        public ActionResult QB(int? id)
        {
            QModel o = new QModel();




            if (id == null)
            {
                o.Qid = db.Questions.ToList();
            }
            else
            {
                // o.Out = db.VideoB.Where(z => z.branch_fid == id).ToList();
            }

            return View(o);

        }

       



        public ActionResult Wishlist()
        {


            return View();
        }
        public ActionResult AddtoWish(int id)
        {

            List<Item> list;
            if (Session["myWish"] == null)
            {
                list = new List<Item>();
            }
            else
            {
                list = (List<Item>)Session["myWish"];
            }
            list.Add(db.Items.Where(p => p.item_id == id).FirstOrDefault());


            Session["myWish"] = list;
            return RedirectToAction("Wishlist");
        }
        public ActionResult RemoveFromWish(int RowNo)
        {
            List<Item> list = (List<Item>)Session["myWish"];
            list.RemoveAt(RowNo);
            Session["myWish"] = list;
            return RedirectToAction("Wishlist");
        }


        public ActionResult DbookB(int? id)
        {
            Dmodel o = new Dmodel();




            if (id == null)
            {
                o.Did = db.Dbooks.ToList();
            }
            else
            {
                // o.Out = db.VideoB.Where(z => z.branch_fid == id).ToList();
            }

            return View(o);

        }
      
       




    }
}