using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beyaz_Eşya_Otomasyonu.Models.Sınıflar;
using Beyaz_Eşya_Otomasyonu.Models;

namespace Beyaz_Eşya_Otomasyonu.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult CariEkle(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var crsl = c.Carilers.Find(id);
            crsl.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cr = c.Carilers.Find(id);
            return View("CariGetir",cr);
        }
        public ActionResult CariGuncelle(Cariler cr)
        {
            var crgncl = c.Carilers.Find(cr.CariId);
            crgncl.CariAd = cr.CariAd;
            crgncl.CariSoyad = cr.CariSoyad;
            crgncl.CariSehir = cr.CariSehir;
            crgncl.CariMail = cr.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}