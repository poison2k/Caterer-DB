using Caterer_DB.Interfaces;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IBenutzerViewModelService benutzerViewModelService)
        {
            BenutzerViewModelService = benutzerViewModelService;
        }

        private IBenutzerViewModelService BenutzerViewModelService { get; set; }

        [HttpGet]
        public ActionResult Index(string infobox = "")
        {
            if (Request.IsAuthenticated)
                return View(BenutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(User.BenutzerId, infobox));

            return View(BenutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(-1, infobox));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ihre Kontakt Seite";

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

        public ActionResult Impressum()
        {
            ViewBag.Message = "Impressum";

            return View();
        }
    }
}