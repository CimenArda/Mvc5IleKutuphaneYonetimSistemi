using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    [Authorize]

    public class YazarController : Controller
    {
        // GET: Yazar
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            var yazarlar = db.TblYazar.ToList();
            return View(yazarlar);
        }


        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        public ActionResult YazarEkle(TblYazar yazar)
        {
            if (yazar != null && !string.IsNullOrWhiteSpace(yazar.AD) && !string.IsNullOrWhiteSpace(yazar.SOYAD))
            {
                db.TblYazar.Add(yazar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Yazar Adı boş olamaz!";
                ViewBag.Error2 = "Yazar Soyadı boş olamaz!";

                return View();
            }
           
        }


        public ActionResult YazarSil(int id)
        {
            var yazarbul = db.TblYazar.Find(id);

            db.TblYazar.Remove(yazarbul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult YazarGuncelle(int id)
        {
            var Yazarbul = db.TblYazar.Find(id);

            return View("YazarGuncelle", Yazarbul);
        }



        [HttpPost]
        public ActionResult YazarGuncelle(TblYazar Yazar)
        {
            var yzr = db.TblYazar.Find(Yazar.ID);
            yzr.AD = Yazar.AD;
            yzr.SOYAD = Yazar.SOYAD;
            yzr.DETAY = Yazar.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TblKitap.Where(x => x.YAZAR == id).ToList();

            var yazarad =db.TblYazar.Where(x=>x.ID == id).Select(x=>x.AD +" " +x.SOYAD).FirstOrDefault();

            ViewBag.yazarad = yazarad;

            return View(yazar);
        }







    }
}