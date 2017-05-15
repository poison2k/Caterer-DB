using Business.Interfaces;
using Caterer_DB.Interfaces;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IBenutzerViewModelService benutzerViewModelService, IFrageService frageService)
        {
            BenutzerViewModelService = benutzerViewModelService;
            FragenService = frageService;
        }

        private IBenutzerViewModelService BenutzerViewModelService { get; set; }

        private IFrageService FragenService { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
                return View(BenutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(User.BenutzerId, FragenService.FindAlleFragenNachKategorieninEigenenListen()));

            return View(BenutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(-1));
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