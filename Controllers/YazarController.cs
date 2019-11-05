using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniProje.Models;

namespace YeniProje.Controllers
{
    public class YazarController : Controller
    {
        Model1 m = new Model1();
        // GET: Yazar
        public ActionResult Index()
        {
            List<Yazar> yzr = m.Yazar.ToList();
            return View(yzr);
        }
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Ekle(Yazar y)
        {
            m.Yazar.Add(y);
            m.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public string Sil(int id)
        {
            Yazar k = m.Yazar.FirstOrDefault(x => x.yazarID == id);
            m.Yazar.Remove(k);
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
        public string Guncelle(int id, string ad)
        {
            Yazar p = m.Yazar.FirstOrDefault(x => x.yazarID == id);
            p.ad = ad;
            
            m.SaveChanges();


            return "guncellendi";

        }
    }
}