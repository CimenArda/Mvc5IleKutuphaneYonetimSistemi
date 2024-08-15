using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            var bilgiler = db.TblAdmin.FirstOrDefault(x => x.Kullanıcı == p.Kullanıcı && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanıcı, false);
                Session["Kullanici"] = bilgiler.Kullanıcı.ToString();
                return RedirectToAction("Index", "Kategori");

            }
            return View();

        }
    }
}