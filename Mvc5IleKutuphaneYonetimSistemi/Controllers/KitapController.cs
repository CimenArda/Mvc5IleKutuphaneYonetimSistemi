using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class KitapController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TblKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));
            }
            return View(kitaplar.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> kategori =(from i in db.TblKategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text=i.AD,
                                             Value=i.ID.ToString()
                                         }).ToList();
            ViewBag.kategori = kategori;

            List<SelectListItem> yazar = (from i in db.TblYazar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AD +" "+i.SOYAD,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.yazar = yazar;




            return View();

        }

        [HttpPost]
        public ActionResult KitapEkle(TblKitap kitap)
        {
            var kategori =db.TblKategori.Where(k=>k.ID==kitap.TblKategori.ID).FirstOrDefault();
            var yazar =db.TblYazar.Where(k=>k.ID==kitap.TblYazar.ID).FirstOrDefault();


            kitap.TblKategori = kategori;
            kitap.TblYazar = yazar;

            db.TblKitap.Add(kitap);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult KitapSil(int id)
        {

            var kitapbul = db.TblKitap.Find(id);

            db.TblKitap.Remove(kitapbul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public ActionResult KitapGuncelle(int id)
        {
            var kitapbul = db.TblKitap.Find(id);
            List<SelectListItem> kategori = (from i in db.TblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AD,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.kategori = kategori;

            List<SelectListItem> yazar = (from i in db.TblYazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD + " " + i.SOYAD,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.yazar = yazar;

            return View("KitapGuncelle", kitapbul);
        }

        

        [HttpPost]
        public ActionResult KitapGuncelle(TblKitap Kitap)
        {
            var ktp = db.TblKitap.Find(Kitap.ID);

            ktp.AD = Kitap.AD;
            ktp.BASIMYIL = Kitap.BASIMYIL;
            ktp.BASIMYIL = Kitap.BASIMYIL;
            ktp.YAYINEVİ = Kitap.YAYINEVİ;
            ktp.SAYFA = Kitap.SAYFA;
            
            var ktg =db.TblKategori.Where(k=>k.ID == Kitap.TblKategori.ID).FirstOrDefault();
            var yzr =db.TblYazar.Where(k=>k.ID == Kitap.TblYazar.ID).FirstOrDefault();

            Kitap.KATEGORI = ktg.ID;
            Kitap.YAZAR =yzr.ID;

            db.SaveChanges();
        
            return RedirectToAction("Index");
        }


    }
}