using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblUye uye)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");

            }
            db.TblUye.Add(uye);
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}