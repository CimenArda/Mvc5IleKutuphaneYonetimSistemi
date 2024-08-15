using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    [Authorize]

    public class MesajlarController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TblMesajlar.Where(x => x.ALICI == uyemail).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TblMesajlar p)
        {
            var uyemail = (string)Session["Mail"].ToString();
            p.GONDEREN = uyemail.ToString();
            db.TblMesajlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Mesajlar");
        }


        public ActionResult GonderilenMesajlar()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TblMesajlar.Where(x => x.GONDEREN == uyemail).ToList();
            return View(mesajlar);
        }




        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var gelensayisi = db.TblMesajlar.Where(x => x.ALICI == uyemail).Count();

            ViewBag.gelen =gelensayisi.ToString();
            var gidensayisi = db.TblMesajlar.Where(x => x.GONDEREN == uyemail).Count();

            ViewBag.giden = gidensayisi.ToString();

            return PartialView();
        }
















    }
}