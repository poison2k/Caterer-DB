using Business.Interfaces;
using Caterer_DB.ViewModel;
using GoogleMaps.LocationServices;
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
            var Adresse = new AddressData()
            {
                Country = googleModel.Land,
                Zip = googleModel.PLZ,
                City = googleModel.Ort,
                Address = googleModel.Street,
                
            };

            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(Adresse);

            googleModel.Längengrad = point.Longitude.ToString();
            googleModel.Breitengrad = point.Latitude.ToString();

            var test = BenutzerService.FindeCatererNachUmkreis(googleModel.PLZ, 100);
            
            return View(googleModel);
        }
    }
}
