using Business.Interfaces;
using Caterer_DB.ViewModel;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    public class GoogleController : Controller
    {
        // GET: Google
        public ActionResult Index()
        {
            var test = new GoogleViewModel();
            return View(test);
        }

        public IBenutzerService BenutzerService { get; set; }

        public GoogleController(IBenutzerService benutzerService) {
            BenutzerService = benutzerService;
        }

        [HttpPost]
        public ActionResult Index(GoogleViewModel googleModel)
        {
            
            
            var test = BenutzerService.FindeCatererNachUmkreis(googleModel.PLZ, 100);
            
            return View(googleModel);
        }
    }
}
