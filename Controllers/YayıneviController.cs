using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniProje.Models;

namespace YeniProje.Controllers
{
    public class YayıneviController : Controller
    {
        Model1 m = new Model1();
        // GET: Yayınevi
        public ActionResult Index()
        {
            List<Yayınevi> y = m.Yayınevi.ToList();
            return View(y);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Yayınevi y)
        {
            m.Yayınevi.Add(y);
            m.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public string Sil(int id)
        {
            Yayınevi k = m.Yayınevi.FirstOrDefault(x => x.yayıneviID == id);
            m.Yayınevi.Remove(k);
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
        public string Guncelle(int id, string ad,string Aciklama1,string tel1)
        {
            Yayınevi p = m.Yayınevi.FirstOrDefault(x => x.yayıneviID == id);
            p.ad = ad;
            p.adres = Aciklama1;
            p.telno = tel1;

            m.SaveChanges();


            return "guncellendi";

        }
    }
}