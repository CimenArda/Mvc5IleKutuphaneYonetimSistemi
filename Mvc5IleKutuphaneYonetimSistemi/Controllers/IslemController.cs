using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {

            var hareketler = db.TblHareket.Where(x => x.ISLEMDURUM == true).ToList();

            return View(hareketler);
        }
    }
}