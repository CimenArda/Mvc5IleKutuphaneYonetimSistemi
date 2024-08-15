using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class PanelimController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        // GET: Panelim
        [Authorize]
        public ActionResult Index2()
        {
            var uyeMail = (string)Session["Mail"];
            //var degerler =db.TblUye.FirstOrDefault(z=>z.MAIL == uyeMail);


            var degerler = db.TblDuyuru.ToList();

            var d1 = db.TblUye.Where(x => x.MAIL == uyeMail).Select(y => y.AD).FirstOrDefault();

            ViewBag.d1 = d1;

            var d2 = db.TblUye.Where(x => x.MAIL == uyeMail).Select(y => y.SOYAD).FirstOrDefault();

            ViewBag.d2 = d2;

            var d3 = db.TblUye.Where(x => x.MAIL == uyeMail).Select(y => y.KULLANICIAD).FirstOrDefault();

            ViewBag.d3 = d3;


            var d4 = db.TblUye.Where(x => x.MAIL == uyeMail).Select(y => y.TELEFON).FirstOrDefault();

            ViewBag.d4 = d4;

            var d5 = db.TblUye.Where(x => x.MAIL == uyeMail).Select(y => y.OKUL).FirstOrDefault();

            ViewBag.d5 = d5;

            var d6 = db.TblUye.Where(x => x.MAIL == uyeMail).Select(y => y.MAIL).FirstOrDefault();

            ViewBag.d6 = d6;



            var uyeId = db.TblUye.Where(x => x.MAIL == uyeMail).Select(y => y.ID).FirstOrDefault();

            var d8 = db.TblHareket.Where(x => x.UYE == uyeId).Count();
            ViewBag.d8 = d8;


            var d9 = db.TblMesajlar.Where(x => x.ALICI == uyeMail).Count();
            ViewBag.d9 = d9;

            var d10 = db.TblMesajlar.Where(x => x.GONDEREN == uyeMail).Count();
            ViewBag.d10 = d10;
            return View(degerler);
        }




        [HttpPost]
        public ActionResult Index2(TblUye p)
        {

            var kullanici = (string)Session["Mail"];
            var uye =db.TblUye.FirstOrDefault(x=>x.MAIL ==kullanici);

            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.KULLANICIAD = p.KULLANICIAD;
            uye.OKUL = p.OKUL;
            db.SaveChanges();
            return View();
        }



        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TblUye.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();

            var hareketler = db.TblHareket.Where(x => x.UYE == id).ToList();

            return View(hareketler);

        }



        public ActionResult Duyurular()
        {
            var duyuruListesi = db.TblDuyuru.ToList();
            return View(duyuruListesi);
        }

        public ActionResult DuyuruDetayPanelim(TblDuyuru p)
        {
            var duyuru = db.TblDuyuru.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }


        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
           var id =db.TblUye.Where(x=>x.MAIL==kullanici).Select(y=>y.ID).FirstOrDefault();
            var uyebul = db.TblUye.Find(id);
            return PartialView("Partial2",uyebul);
        }



    }
}