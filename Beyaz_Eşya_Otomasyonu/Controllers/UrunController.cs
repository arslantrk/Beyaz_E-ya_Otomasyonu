using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beyaz_Eşya_Otomasyonu.Models;
using Beyaz_Eşya_Otomasyonu.Models.Sınıflar;

namespace Beyaz_Eşya_Otomasyonu.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text=x.KategoriAd,
                                              Value=x.KategoriId.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;//controller tarafından view tarafına veri taşımak için kullanılır.
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var silinicekdeğer = c.Uruns.Find(id);
            silinicekdeğer.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriId.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            var getir = c.Uruns.Find(id);
            return View("UrunGetir", getir);
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunId);
            urn.AlisFiyat = u.AlisFiyat;
            urn.Durum = u.Durum;
            urn.Kategoriid = u.Kategoriid;
            urn.Marka = u.Marka;
            urn.SatisFiyat = u.SatisFiyat;
            urn.Stok = u.Stok;
            urn.UrunAd = u.UrunAd;
            urn.UrunGorsel = u.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}