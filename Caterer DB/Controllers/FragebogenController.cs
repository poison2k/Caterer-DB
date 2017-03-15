using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class FragebogenController : BaseController
    {
        public IFrageService FrageService { get; set; }

        public IBenutzerService BenutzerService { get; set; }

        public IFragebogenViewModelService FragebogenViewModelService { get; set; }

        public FragebogenController(IFrageService frageService, IFragebogenViewModelService fragebogenViewModelService , IBenutzerService benutzerService) {
            FrageService = frageService;
            FragebogenViewModelService = fragebogenViewModelService;
            BenutzerService = benutzerService;
        }

        // GET: Fragebogen/Details
        [CustomAuthorize(Roles = "Caterer")]
        public ActionResult Details()
        {
            var benutzer = BenutzerService.SearchUserById(User.BenutzerId);

            return View(FragebogenViewModelService.Map_Fragen_BearbeiteFragebogenViewModel(FrageService.FindAlleFragenNachSparteninEigenenListen(),benutzer.AntwortIDs));
        }

        // GET: Fragebogen/Details
        [HttpPost]
        [CustomAuthorize(Roles = "Caterer")]
        public ActionResult Details(BearbeiteFragebogenViewModel bearbeitefragebogenviewmodel)
        {
            if (ModelState.IsValid) {
               List<int> antwortIDs = FragebogenViewModelService.Map_BearbeiteFragebogenViewModel_BenutzerResultSet(bearbeitefragebogenviewmodel);
               var benutzer = BenutzerService.SearchUserById(User.BenutzerId);
               benutzer.AntwortIDs = antwortIDs;
               BenutzerService.EditBenutzer(benutzer);
            }
            return View(bearbeitefragebogenviewmodel);
        }
    }
}