using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblUye p)
        {
            var BİLGİLER =db.TblUye.FirstOrDefault(x=>x.MAIL==p.MAIL && x.SIFRE==p.SIFRE);


            if (BİLGİLER !=null)
            {
                FormsAuthentication.SetAuthCookie(BİLGİLER.MAIL, false);

                Session["Mail"] = BİLGİLER.MAIL.ToString();

                //Session["Ad"] = BİLGİLER.AD.ToString();
                //Session["Soyad"] = BİLGİLER.SOYAD.ToString();
                //Session["KullanıcıAd"] = BİLGİLER.KULLANICIAD.ToString();
                //Session["Okul"] = BİLGİLER.OKUL.ToString();
                //Session["Sifre"] = BİLGİLER.SIFRE.ToString();
                //Session["Id"] = BİLGİLER.ID.ToString();


                return RedirectToAction("Index2", "Panelim");

            }
           return View();


        }





    }
}