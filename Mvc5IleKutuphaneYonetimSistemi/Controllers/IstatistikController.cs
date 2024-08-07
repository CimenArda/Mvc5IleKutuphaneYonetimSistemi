using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            return View();
        }
    }
}