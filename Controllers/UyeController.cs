using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YeniProje.App_Classes;

namespace YeniProje.Controllers
{
    public class UyeController : Controller
    {
        public ActionResult GirisYap()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult GirisYap(Kullanıcı k, string Hatirla)
        {

            bool sonuc = Membership.ValidateUser(k.KullaniciAdi, k.Parola);

            if (sonuc)
            {
                if (Hatirla == "on")
                {
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, true);
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, false);
                }
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı veya parola hatalı.";
                return View();
            }
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }

        public ActionResult ParolamiUnuttum()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult ParolamiUnuttum(Kullanıcı k)
        {
            MembershipUser mu = Membership.GetUser(k.KullaniciAdi);
            if (mu.PasswordQuestion == k.GizliSoru)
            {
                string pwd = mu.ResetPassword(k.GizliCevap);
                mu.ChangePassword(pwd, k.Parola);
                return RedirectToAction("GirisYap");


            }
            else
            {
                ViewBag.Mesaj = "Girilen bilgiler yanlıştır.";
                return View();
            }
        }

        public ActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(Kullanıcı k)
        {

            MembershipCreateStatus durum;
            Membership.CreateUser(k.KullaniciAdi, k.Parola, k.Email, k.GizliSoru, k.GizliCevap, true, out durum);
            string mesaj = "";

            switch (durum)
            {

                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    mesaj += "geçersiz kullancı adı";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    mesaj += "geçersiz parola";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    mesaj += "geçersiz gizli soru";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    mesaj += "geçersiz gizli cevap";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    mesaj += "geçersiz email";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    mesaj += "Kullanılmış kullanıcı adı hatası";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    mesaj += "Kullanılmış mail adresi girildi";
                    break;
                case MembershipCreateStatus.UserRejected:
                    mesaj += "Kullanıcı engel hatası";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    mesaj += "geçersiz kullancı key hatası";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    mesaj += "Kullanılmış kullanıcı key hatası";
                    break;
                case MembershipCreateStatus.ProviderError:
                    mesaj += "üye yönetimi sağlayıcı hatası";
                    break;
                default:
                    break;
            }
            ViewBag.Mesaj = mesaj;
            if (durum == MembershipCreateStatus.Success)
                return RedirectToAction("GirisYap");
            else
            {
                return View();
            }

        }
    }
}