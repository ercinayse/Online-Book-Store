using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniProje.Models;

namespace YeniProje.Controllers
{
    public class HomeController : Controller
    {
        Model1 m = new Model1();
        // GET: Home
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }
    }
}