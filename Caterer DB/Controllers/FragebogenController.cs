using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Caterer_DB.MVCServices;
using Caterer_DB.ViewModel;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class FragebogenController : BaseController
    {
        public IFrageService FrageService { get; set; }

        public IBenutzerService BenutzerService { get; set; }

        public IFragebogenViewModelService FragebogenViewModelService { get; set; }

        public FragebogenController(IFrageService frageService, IFragebogenViewModelService fragebogenViewModelService, IBenutzerService benutzerService)
        {
            FrageService = frageService;
            FragebogenViewModelService = fragebogenViewModelService;
            BenutzerService = benutzerService;
        }

        // GET: Fragebogen/Details
        [CustomAuthorize(Roles = "Caterer")]
        public ActionResult Details()
        {
            var benutzer = BenutzerService.SearchUserById(User.BenutzerId);
            var bearbeiteFragebogenViewModel = FragebogenViewModelService.Map_Fragen_BearbeiteFragebogenViewModel(FrageService.FindAlleFragenNachKategorieninEigenenListen(), benutzer.AntwortIDs);
            bearbeiteFragebogenViewModel.Sonstiges = benutzer.Sonstiges;
            return View(bearbeiteFragebogenViewModel);
        }

        // POST: Fragebogen/Details
        [HttpPost]
        [CustomAuthorize(Roles = "Caterer")]
        public ActionResult Details(BearbeiteFragebogenViewModel bearbeitefragebogenviewmodel)
        {
            if (ModelState.IsValid)
            {
                List<int> antwortIDs = FragebogenViewModelService.Map_BearbeiteFragebogenViewModel_BenutzerResultSet(bearbeitefragebogenviewmodel);
                var benutzer = BenutzerService.SearchUserById(User.BenutzerId);
                benutzer.AntwortIDs = antwortIDs;
                benutzer.Sonstiges = bearbeitefragebogenviewmodel.Sonstiges;
                BenutzerService.EditBenutzer(benutzer);
                if (Request.Form["btnSave"] != null)
                {
                    TempData["isSavedFragebogen"] = true;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(bearbeitefragebogenviewmodel);
        }
    }
}