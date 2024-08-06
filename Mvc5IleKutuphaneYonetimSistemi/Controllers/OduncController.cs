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
            var hareketler = db.TblHareket.ToList();

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





    }
}