using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AGB()
        {
            ViewBag.Message = "Allgemeine Geschäftsbedingungen";

            return View();
        }

        public ActionResult Datenschutz()
        {
            ViewBag.Message = "Ihre Daten sind bei uns sicher!";

            return View();
        }
       
    }
}