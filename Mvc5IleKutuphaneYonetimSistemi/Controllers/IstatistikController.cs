using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    [Authorize]

    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
         
            ViewBag.toplamuye =db.TblUye.Count().ToString();
            ViewBag.toplamkitap =db.TblKitap.Count().ToString();

            ViewBag.emanetkitap =db.TblKitap.Where(x=>x.DURUM==false).Count().ToString();

            ViewBag.kasa =db.TblCeza.Sum(x=>x.PARA).ToString();
            
            return View();
        }


        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();

        }


        public ActionResult Galeri()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase postedFile)
        {
            if (postedFile.ContentLength >0)
            {
                string dosyayolu =Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(postedFile.FileName));
                postedFile.SaveAs(dosyayolu);
            }

            return RedirectToAction("Galeri");
        }



        public ActionResult LinqKart()
        {
            ViewBag.dgr1 = db.TblKitap.Count().ToString();
            ViewBag.dgr2 = db.TblUye.Count().ToString();
            ViewBag.dgr3 = db.TblCeza.Sum(x=>x.PARA).ToString();
            ViewBag.dgr4 = db.TblKitap.Where(x=>x.DURUM==false).Count().ToString();
            ViewBag.dgr5= db.TblKategori.Count().ToString();


            ViewBag.dgr8 = db.enFazlakitapYazar().FirstOrDefault();


            ViewBag.dgr9 = db.TblKitap.GroupBy(x => x.YAYINEVİ).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();

            ViewBag.dgr11= db.TblIletisim.Count().ToString();










            return View();
        }
    }
}