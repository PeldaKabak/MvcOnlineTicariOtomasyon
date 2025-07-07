using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar; 

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context(); 
        public ActionResult Index()
        {

            var satislar = c.SatisHarekets.Where(x => x.Durum == true).ToList(); 
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> satisUrun = ( from x  in c.Uruns.ToList()
                                           select new SelectListItem
                                              {
                                                  Text = x.UrunAd ,
                                                  Value = x.UrunID.ToString()
                                              }).ToList();
            List<SelectListItem> satisCari = (from x in c.Carilers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CariAd + " " + x.CariSoyad,
                                                  Value = x.CariID.ToString()
                                              }).ToList();
            List<SelectListItem> satisPersonel = (from x in c.Personels.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                      Value = x.PersonelID.ToString()
                                                  }).ToList();
            ViewBag.satisUrun = satisUrun;
            ViewBag.satisCari = satisCari;
            ViewBag.satisPersonel = satisPersonel;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            s.Durum = true;
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SatisGetir (int id)
        {
            var satis = c.SatisHarekets.Find(id);
            List<SelectListItem> satisUrun = (from x in c.Uruns.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UrunAd,
                                                  Value = x.UrunID.ToString()
                                              }).ToList();
            List<SelectListItem> satisCari = (from x in c.Carilers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CariAd + " " + x.CariSoyad,
                                                  Value = x.CariID.ToString()
                                              }).ToList();
            List<SelectListItem> satisPersonel = (from x in c.Personels.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                      Value = x.PersonelID.ToString()
                                                  }).ToList();
            ViewBag.satisUrun = satisUrun;
            ViewBag.satisCari = satisCari;
            ViewBag.satisPersonel = satisPersonel;
            return View("SatisGetir", satis);

        }

        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var satis = c.SatisHarekets.Find(s.SatisID);
            satis.UrunID = s.UrunID;
            satis.CariID = s.CariID;
            satis.PersonelID = s.PersonelID;
           satis.ToplamTutar = s.ToplamTutar;
            satis.Adet = s.Adet;
            satis.Fiyat = s.Fiyat;
            //satis.Tarih = s.Tarih; hata alıyorum sonra bak nasıl yapılabilir 
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var satisDetay = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
             return View( "SatisDetay",satisDetay);
        }
    }
}