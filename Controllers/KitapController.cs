using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniProje.App_Classes;
using YeniProje.Models;

namespace YeniProje.Controllers
{
    public class KitapController : Controller
    {
        Model1 m = new Model1();
        // GET: Kitap
        public ActionResult Index()
        {
            List<Kitap> ktp = m.Kitap.ToList();
            return View(ktp);
        }

        public ActionResult Ekle()
        {
            ViewBag.Yazar = m.Yazar.ToList();
            ViewBag.Kategori = m.Kategori.ToList();
            ViewBag.Yayınevleri = m.Yayınevi.ToList();
            return View();
        }

        
        [HttpPost]

        public ActionResult Ekle(Kitap y)
        {
            m.Kitap.Add(y);
            m.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public string Sil(int id)
        {
            Kitap k = m.Kitap.FirstOrDefault(x => x.kitapID == id);
            m.Kitap.Remove(k);
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

        public ActionResult ResimEkle(int id)
        {
            
                return View(id);
        }

        [HttpPost]
        public ActionResult ResimEkle(int uId,HttpPostedFileBase fileUpload)
        {
            if(fileUpload!=null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);

                Bitmap ortaResim = new Bitmap(img, Settings.KitapOrtaBoyut);

                Bitmap buyukResim = new Bitmap(img, Settings.KitapBuyukBoyut);

                string ortaYol = "/Content/KitapResim/Orta/" + Guid.NewGuid()+Path.GetExtension(fileUpload.FileName);

                string buyukYol= "/Content/KitapResim/Buyuk/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                ortaResim.Save(Server.MapPath(ortaYol));
                buyukResim.Save(Server.MapPath(buyukYol));

                Resim rsm = new Resim();
                rsm.BuyukYol = buyukYol;
                rsm.OrtaYol = ortaYol;
                rsm.KitapID = uId;
                if(m.Resim.FirstOrDefault(x=>x.KitapID==uId && x.Varsayılan==true)!=null)
                {
                    rsm.Varsayılan = true;
                }
                else
                {
                    rsm.Varsayılan = false;
                }
                m.Resim.Add(rsm);
                m.SaveChanges();
                return View(uId);
                

            }
            return View(uId);
        }

        public ActionResult List()
        {
            var data = m.Kitap.ToList();
            return View(data);
        }

        [HttpPost]
        public void SepeteAt(int id)
        {
            Sepet s;
            if (Session["AktifSepet"] == null)//sepet ilk defa oluşturuluyor
            {
                s = new Sepet();

            }
            else
            {
                s = (Sepet)Session["AktifSepet"];

            }
            Kitap u = m.Kitap.FirstOrDefault(x => x.kitapID == id);
            s.Kitap.Add(u);
            Session["AktifSepet"] = s;
        }

        public ActionResult KitapDetay(int id,string ad)
        {
            int id1 = Convert.ToInt32(Request.QueryString["id"].ToString());
            string ad1 = Request.QueryString["adi"].ToString();
            Kitap k = m.Kitap.FirstOrDefault(x => x.kitapID == id);
            return View(k);
            

        }

        public ActionResult SepetDetay()
        {
            List<Kitap> kitap = new List<Kitap>();
            if (Session["AktifSepet"] != null)
            {
                Sepet s = (Sepet)Session["AktifSepet"];
                kitap = s.Kitap;
            }
            return View(kitap);
        }
    }
}