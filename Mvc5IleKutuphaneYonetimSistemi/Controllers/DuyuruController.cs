using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            var degerler = db.TblDuyuru.ToList();
            return View(degerler);
        }




        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(TblDuyuru P)
        {
            db.TblDuyuru.Add(P);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DuyuruSil(int id)
        {
            var Duyurubul = db.TblDuyuru.Find(id);

            db.TblDuyuru.Remove(Duyurubul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }






        [HttpGet]
        public ActionResult DuyuruGuncelle(int id)
        {
            var Duyurubul = db.TblDuyuru.Find(id);

            return View("DuyuruGuncelle", Duyurubul);
        }



        [HttpPost]
        public ActionResult DuyuruGuncelle(TblDuyuru p)
        {
            var Duyuru = db.TblDuyuru.Find(p.ID);

            Duyuru.KATEGORİ = p.KATEGORİ;
            Duyuru.ICERİK = p.ICERİK;
            Duyuru.TARIH =p.TARIH;

            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult DuyuruDetay(TblDuyuru p)
        {
            var duyuru = db.TblDuyuru.Find(p.ID);
            return View("DuyuruDetay",duyuru);
        }








    }
}