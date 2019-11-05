using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniProje.Models;

namespace YeniProje.Controllers
{
    public class KargoController : Controller
    {
        Model1 m = new Model1();

        // GET: Kargo
        public ActionResult Index()
        {
            List<Kargo> krg = m.Kargo.ToList();
            return View(krg);
        }

        public ActionResult Ekle()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Ekle(Kargo y)
        {
            m.Kargo.Add(y);
            m.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Sil(int id)
        {
            Kargo k = m.Kargo.FirstOrDefault(x => x.KargoID== id);
            m.Kargo.Remove(k);
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
        public string Guncelle(int id, string ad,string Telno1,string Aciklama1)
        {
            Kargo p = m.Kargo.FirstOrDefault(x => x.KargoID == id);
            p.kargoadi = ad;
            p.telno = Telno1;
            p.adres = Aciklama1;

            m.SaveChanges();


            return "guncellendi";

        }
    }
}