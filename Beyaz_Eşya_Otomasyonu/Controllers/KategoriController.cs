using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beyaz_Eşya_Otomasyonu.Models;
using Beyaz_Eşya_Otomasyonu.Models.Sınıflar;
namespace Beyaz_Eşya_Otomasyonu.Controllers
{
    public class KategoriController : Controller
    {
        Context c = new Context();
        // GET: Kategori
        public ActionResult Index()
        {
            var değerler = c.Kategoris.ToList();
            return View(değerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);//databasede bulduğu kategori id yi eşler ve atama yapar
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGüncelle(Kategori k)
        {
            var ktg = c.Kategoris.Find(k.KategoriId);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}