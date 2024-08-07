using Mvc5IleKutuphaneYonetimSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5IleKutuphaneYonetimSistemi.Models.Siniflar
{
    public class AnaSinif
    {
        public IEnumerable<TblKitap> tblKitap { get; set; }
        public IEnumerable<TblHakkimizda> tblHakkimizda { get; set; }
        public IEnumerable<TblIletisim> tblIletisim { get; set; }


    }
}