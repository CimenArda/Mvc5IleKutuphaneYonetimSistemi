//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc5IleKutuphaneYonetimSistemi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblKitap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblKitap()
        {
            this.TblHareket = new HashSet<TblHareket>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public Nullable<int> KATEGORI { get; set; }
        public Nullable<int> YAZAR { get; set; }
        public string BASIMYIL { get; set; }
        public string YAYINEVİ { get; set; }
        public string SAYFA { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblHareket> TblHareket { get; set; }
        public virtual TblKategori TblKategori { get; set; }
        public virtual TblYazar TblYazar { get; set; }
    }
}
