using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var degerler =db.TblUye.FirstOrDefault(z=>z.MAIL == uyeMail);

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
    }
}