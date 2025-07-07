using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar; 

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cariList = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(cariList);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniCari (Cariler r)
        {
            r.Durum = true; // Set the status to true when adding a new customer
            c.Carilers.Add(r);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Durum = false; // Set the status to false when deleting a customer
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler r)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir"); 
            }
            var cari = c.Carilers.Find(r.CariID);
            cari.CariAd = r.CariAd;
            cari.CariSoyad = r.CariSoyad;
            cari.CariSehir = r.CariSehir;
            cari.CariMail = r.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult MusteriSatis ( int id)
        {
            var degerler =c.SatisHarekets.Where(x=>x.CariID == id).ToList();
            var cariAd = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cariAd = cariAd;
            return View(degerler);
        }
    }
}