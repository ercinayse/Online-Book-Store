using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YeniProje.App_Classes;
using YeniProje.Models;

namespace YeniProje.Controllers
{

    public class KullanıcıController : Controller
    {
        Model1 m = new Model1();
        
        // GET: Kullanıcı
        public ActionResult Index()
        {
            MembershipUserCollection users = Membership.GetAllUsers();
            List<Uye> u = m.Uye.ToList();

            return View(users);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Ekle()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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
                return RedirectToAction("Index");
            else
            {
                return View();
            }

        }

        [Authorize(Roles = "Admin")]

        public ActionResult RolAta(string id)
        {
            ViewBag.Kullanicilar = Membership.GetAllUsers();
            ViewBag.Roller = Roles.GetAllRoles().ToList();
            return View(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult RolAta(string KullaniciAdi, string RolAdi)
        {
            Roles.AddUserToRole(KullaniciAdi, RolAdi);//bir kullancıya bir rol atıyoruz
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public string UyeRolleri(string kullaniciAdi)
        {
            List<string> roller = Roles.GetRolesForUser(kullaniciAdi).ToList();
            string rol = "";
            foreach (string r in roller)
            {
                rol += r + "-";

            }
            rol = rol.Remove(rol.Length - 1, 1);
            return rol;
        }

        public ActionResult KayıtOl(Uye u)
        {
            return View();
        }


        

    }

}