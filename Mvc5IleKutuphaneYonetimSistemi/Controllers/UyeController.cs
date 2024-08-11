using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index(int sayfa = 1)
        {
            //var uyeler = db.TblUye.ToList();

            var uyeler = db.TblUye.ToList().ToPagedList(sayfa, 3);

            return View(uyeler);
        }


        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TblUye P)
        {
            db.TblUye.Add(P);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]

        public ActionResult UyeSil(int id)
        {
            var uyebul = db.TblUye.Find(id);

            db.TblUye.Remove(uyebul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UyeGuncelle(int id)
        {
            var uyebul = db.TblUye.Find(id);

            return View("UyeGuncelle", uyebul);
        }



        [HttpPost]
        public ActionResult UyeGuncelle(TblUye p)
        {
            var uye = db.TblUye.Find(p.ID);

            uye.AD=p.AD;
            uye.SOYAD =p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIAD = p.KULLANICIAD;
            uye.SIFRE = p.SIFRE;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.TELEFON  = p.TELEFON;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeKitapGecmis(int id)
        {
            var kitapgecmis =db.TblHareket.Where(x=>x.UYE==id).ToList();
            var uyead = db.TblUye.Where(x => x.ID == id).Select(x => x.AD + " " + x.SOYAD).FirstOrDefault();

            ViewBag.uyead = uyead;
            return View(kitapgecmis);
        }



    }
}