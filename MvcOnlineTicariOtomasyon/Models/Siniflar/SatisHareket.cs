using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }

        //URUNl
        //CARİ
        //PERSONEL
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }  
        public decimal ToplamTutar { get; set; }

        public int UrunID { get; set; } // Foreign key for Urun
        public int CariID { get; set; } // Foreign key for Cariler
           
        public int PersonelID { get; set; } // Foreign key for Personel
        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
        public bool Durum { get; set; } // Indicates if the sale is active or not


    }
}