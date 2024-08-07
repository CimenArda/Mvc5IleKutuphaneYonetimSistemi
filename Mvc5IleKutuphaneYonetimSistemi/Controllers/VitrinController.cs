using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5IleKutuphaneYonetimSistemi.Models.Siniflar;

namespace Mvc5IleKutuphaneYonetimSistemi.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DbKutuphaneEntities db = new DbKutuphaneEntities();

        public ActionResult Index()
        {
            AnaSinif ana = new AnaSinif();
            ana.tblKitap = db.TblKitap.ToList();
            ana.tblHakkimizda = db.TblHakkimizda.ToList();


            return View(ana);
        }


        [HttpPost]
        public ActionResult Index(TblIletisim t)
        {
            db.TblIletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
               
        
        }

    }
}