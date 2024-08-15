using Mvc5IleKutuphaneYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizeKitapResult()
        {
            return Json(Liste());
        }


        public List<Class1> Liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayınevi = "Güneş",
                sayi = 7
            });
            cs.Add(new Class1()
            {
                yayınevi = "Mars",
                sayi = 4
            });
            cs.Add(new Class1()
            {
                yayınevi = "Jupiter",
                sayi = 5
            });

            return cs;
        }
    }
}