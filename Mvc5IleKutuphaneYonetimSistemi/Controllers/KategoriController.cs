using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class KategoriController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        
        public ActionResult Index()
        {
            var kategoriler = db.TblKategori.Where(x=>x.DURUM ==true).ToList();

            return View(kategoriler);
        }


        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TblKategori kategori)
        {

            if (kategori != null && !string.IsNullOrWhiteSpace(kategori.AD))
            {
                db.TblKategori.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Kategori adı boş olamaz!";

                return View();
            }
        }


        public ActionResult KategoriSil(int id)
        {
            var kategoribul =db.TblKategori.Find(id);

            //db.TblKategori.Remove(kategoribul);

                 kategoribul.DURUM = false;
                db.SaveChanges();
                return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var kategoribul = db.TblKategori.Find(id);

            return View("KategoriGuncelle", kategoribul);
        }



        [HttpPost]
        public ActionResult KategoriGuncelle(TblKategori kategori)
        {
            var ktg = db.TblKategori.Find(kategori.ID);
            ktg.AD = kategori.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}