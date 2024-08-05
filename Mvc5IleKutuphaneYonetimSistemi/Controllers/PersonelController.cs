using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class PersonelController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var personeller = db.TblPersonel.ToList();
            return View(personeller);
        }



        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TblPersonel P)
        {
                db.TblPersonel.Add(P);
                db.SaveChanges();
                return RedirectToAction("Index");
            
            
        }
        public ActionResult PersonelSil(int id)
        {
            var personelbul = db.TblPersonel.Find(id);

            db.TblPersonel.Remove(personelbul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            var personelbul = db.TblPersonel.Find(id);

            return View("PersonelGuncelle", personelbul);
        }



        [HttpPost]
        public ActionResult PersonelGuncelle(TblPersonel p)
        {
            var personel = db.TblPersonel.Find(p.ID);
            personel.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }










    }
}