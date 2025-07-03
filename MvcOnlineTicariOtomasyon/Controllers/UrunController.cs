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
            var urunler = c.Uruns.ToList(); // Fetching all products from the database
            return View(urunler);
        }
    }
}