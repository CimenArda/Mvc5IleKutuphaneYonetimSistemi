using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            var hareketler = db.TblHareket.Where(x=>x.ISLEMDURUM==false).ToList();

            return View(hareketler);
        }

        public ActionResult OduncVer()
        {

            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TblHareket hareket)
        {

            if (hareket != null && !string.IsNullOrWhiteSpace(hareket.KITAP.ToString()) && !string.IsNullOrWhiteSpace(hareket.PERSONEL.ToString()))
            {
                db.TblHareket.Add(hareket);
                db.SaveChanges();
                return View();
            }
            else
            {
                ViewBag.Error = "Hareket Değerleri boş olamaz!";
                ViewBag.Error2 = "Hareket Değerleri boş olamaz!";

                return View();
            }
        }

        public ActionResult IadeEt(int id)
        {

            var odn =db.TblHareket.Find(id);
            return View("IadeEt",odn);
        }

        [HttpPost]
        public ActionResult OduncGuncelle(TblHareket p)
        {
            var hareket = db.TblHareket.Find(p.ID);
            hareket.UYEGETIRDIGITARIH = p.UYEGETIRDIGITARIH;
            hareket.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}