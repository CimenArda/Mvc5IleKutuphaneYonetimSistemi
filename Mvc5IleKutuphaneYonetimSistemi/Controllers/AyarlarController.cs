using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        //public ActionResult Index()
        //{
        //    var kullanicilar = db.TblAdmin.ToList();
        //    return View(kullanicilar);
        //}

        public ActionResult Index2()
        {
            var kullanicilar = db.TblAdmin.ToList();
            return View(kullanicilar);
        }

        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniAdmin(TblAdmin p)
        {

            db.TblAdmin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }


        public ActionResult AdminSil(int id)
        {
            var adminbul = db.TblAdmin.Find(id);
            db.TblAdmin.Remove(adminbul);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult AdminDuzenle(int id)
        {
            var adminbul = db.TblAdmin.Find(id);
            return View("AdminDuzenle",adminbul);
        }

        [HttpPost]
        public ActionResult AdminDuzenle(TblAdmin p)
        {
            var adminbul = db.TblAdmin.Find(p.ID);
            adminbul.Kullanıcı = p.Kullanıcı;
            adminbul.Sifre = p.Sifre;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}