using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; // Assuming you are using Entity Framework for database context

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Context :DbContext
    {
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Departman> Departmans { get; set; }

    }
}