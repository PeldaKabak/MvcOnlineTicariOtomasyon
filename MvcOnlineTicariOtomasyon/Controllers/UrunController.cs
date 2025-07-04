using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar; // Assuming you have a Models folder with Siniflar namespace

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context(); // Assuming you have a Context class for database operations
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x=>x.Durum==true).ToList(); // Fetching all products from the database
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> urunKategori = (from x in c.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.KategoriID.ToString()
                                                 }).ToList();

            ViewBag.UrunKategori = urunKategori; // Passing the list of categories to the view using ViewBag
            return View(); // Returning the view to create a new product
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            c.Uruns.Add(u); // Adding a new product to the database
            c.SaveChanges(); // Saving changes to the database
            return RedirectToAction("Index"); // Redirecting to the Index action to display the updated list of products    
        }

        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id); // Finding the product by ID
            urun.Durum = false; // Setting the product status to false (soft delete)
            c.SaveChanges(); // Saving changes to the database
            return RedirectToAction("Index"); // Redirecting to the Index action
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> urunKategori = (from x in c.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.KategoriID.ToString()
                                                 }).ToList();

            ViewBag.UrunKategori = urunKategori;
            var urun = c.Uruns.Find(id); 

            return View("UrunGetir", urun); 
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            var urun = c.Uruns.Find(u.UrunID); 
            urun.UrunAd = u.UrunAd; 
            urun.Marka = u.Marka;
            urun.Stok = u.Stok; 
            urun.AlisFiyati = u.AlisFiyati; 
            urun.SatisFiyati = u.SatisFiyati;
            urun.KategoriID = u.KategoriID; 
            urun.UrunGorsel = u.UrunGorsel; 
            c.SaveChanges(); 
            return RedirectToAction("Index"); 
        }
    }
}