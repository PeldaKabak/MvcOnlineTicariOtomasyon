using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar; // Assuming you have a Models folder with Siniflar namespace
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil (int id)
        {
            var departman = c.Departmans.Find(id);
           departman.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = c.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departman = c.Departmans.Find(d.DepartmanID);
            departman.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var departmanPersonel = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var departman = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.departmanAd = departman;
            return View(departmanPersonel);
        }

        public ActionResult DepartmanPersonelSatis  (int id)
        {
            var personelSatis = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var personelAd = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.satisPer = personelAd;
            return View(personelSatis);
        }
    }
}