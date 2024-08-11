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
            List<SelectListItem> deger1 = (from x in db.TblUye.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD +" " +x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.deger1 = deger1;


            List<SelectListItem> deger2 = (from x in db.TblKitap.Where(x=>x.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.deger2 = deger2;
            List<SelectListItem> deger3 = (from x in db.TblPersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONEL,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.deger3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TblHareket hareket)
        {
            if (hareket != null && hareket.TblUye != null && hareket.TblKitap != null && hareket.TblPersonel != null)
            {
                var uye = db.TblUye.Find(hareket.TblUye.ID);
                var kitap = db.TblKitap.Find(hareket.TblKitap.ID);
                var personel = db.TblPersonel.Find(hareket.TblPersonel.ID);

                if (uye != null && kitap != null && personel != null)
                {
                    hareket.TblUye = uye;
                    hareket.TblKitap = kitap;
                    hareket.TblPersonel = personel;

                    db.TblHareket.Add(hareket);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Geçerli bir Üye, Kitap veya Personel seçiniz.";
                }
            }
            else
            {
                ViewBag.Error = "Hareket Değerleri boş olamaz!";
            }

            return View(hareket);
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