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

        public ActionResult IadeEt(TblHareket p)
        {

            var odn =db.TblHareket.Find(p.ID);

            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());

            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            TimeSpan d3 = d2 - d1;
            ViewBag.dgr2 = d3.TotalDays;




            ViewBag.dgr = d1;
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