using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();

        }


        public ActionResult Galeri()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase postedFile)
        {
            if (postedFile.ContentLength >0)
            {
                string dosyayolu =Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(postedFile.FileName));
                postedFile.SaveAs(dosyayolu);
            }

            return RedirectToAction("Galeri");
        }
    }
}