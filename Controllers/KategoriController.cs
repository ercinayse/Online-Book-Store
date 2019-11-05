using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniProje.Models;

namespace YeniProje.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        Model1 m = new Model1();
        // GET: Kategori
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Kategori> ktg = m.Kategori.ToList();
            return View(ktg);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Ekle(Kategori ktg)
        {
            m.Kategori.Add(ktg);
            m.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public string Sil(int id)
        {
            Kategori k = m.Kategori.FirstOrDefault(x => x.kategoriID == id);
            m.Kategori.Remove(k);
            try
            {
                m.SaveChanges();
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }


        [HttpPost]
        public string Guncelle(int id, string ad, string Aciklama1)
        {
            Kategori p = m.Kategori.FirstOrDefault(x => x.kategoriID == id);
            p.ad = ad;
            p.aciklama = Aciklama1;
            m.SaveChanges();
            

            return "guncellendi";

        }
    }
}