using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices.ComTypes;

//namespace MacLibraryProject.Controllers
//{
//    public class PdfController : Controller
//    {
//        public JsonResult ReadTextFile(string fileName)
//        {
//            string retString = string.Empty;
//            string path = Path.Combine(Server.MapPath("~/uploads"), fileName);
//            if (System.IO.File.Exists(path))
//            {
//                if (Path.GetExtension(path) == "doc" || Path.GetExtension(path) == ".docx")
//                {
//                    Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
//                    object miss = System.Reflection.Missing.Value;
//                    object readOnly = true;
//                    object wordPath = path;
//                    Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(
//                        ref wordPath,
//                        ref miss,
//                        ref readOnly,
//                        ref miss, ref miss, ref miss,
//                        ref miss, ref miss, ref miss,
//                        ref miss, ref miss, ref miss,
//                        ref miss, ref miss, ref miss, ref miss);
//                    for (int i = 0; i < docs.Paragraphs.Count; i++)
//                    {
//                        retString += " \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString();
//                    }
//                }
//                else if (Path.GetExtension(path) == "txt")
//                {
//                    using (StreamReader sr = new StreamReader(path))
//                    {
//                        retString = sr.ReadToEnd();
//                    }
//                }
//            }
//            return Json(retString, JsonRequestBehavior.AllowGet);
//        }
//        // GET: Pdf
//        [HttpGet]
//        public ActionResult Index()
//        {
//            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

//            return View();
//        }
//        [HttpPost]
//        public ActionResult Index(HttpPostedFileBase file)
//        {
//            var supportedTypes = new[] { "txt", "rtf", "html", "xaml", "xslx", "pdf", "doc", "docx", "csv" };

//            var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

//            if (!supportedTypes.Contains(fileExt))
//            {
//                ModelState.AddModelError("file", "Invalid type. Only the following types (txt, rtf, html, xslx, pdf, xaml, doc, docx, csv) are supported.");
//                return View();
//            }
//            if (file.ContentLength > 200000)
//            {
//                ModelState.AddModelError("file", "The size of the file should not exceed 200 KB");
//                return View();
//            }
//            if (file.ContentLength > 0)
//            {


//                var fileName = Path.GetFileName(file.FileName);
//                var path = Path.Combine(Server.MapPath("~/ProPic"), fileName);
//                file.SaveAs(path);
//            }

//            return RedirectToAction("Index");
//        }

//        public ActionResult About()
//        {
//            var uploadedFiles = new List<UploadedFile>();
//            var files = Directory.GetFiles(Server.MapPath("~/ProPic"));
//            foreach (var file in files)
//            {
//                var fileInfo = new FileInfo(file);
//                var uploadedFile = new UploadedFile() { Name = Path.GetFileName(file) };
//                uploadedFile.Size = fileInfo.Length;
//                uploadedFile.extension = Path.GetExtension(file);

//                uploadedFile.Path = ("~/ProPic/") + Path.GetFileName(file);

//                uploadedFiles.Add(uploadedFile);
//            }
//            return View(uploadedFiles);
//        }
//    }

//}
//}