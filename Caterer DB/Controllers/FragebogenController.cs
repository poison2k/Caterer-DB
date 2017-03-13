using Business.Interfaces;
using Caterer_DB.Interfaces;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    public class FragebogenController : BaseController
    {
        public IFrageService FrageService { get; set; }

        public IFragebogenViewModelService FragebogenViewModelService { get; set; }

        public FragebogenController(IFrageService frageService, IFragebogenViewModelService fragebogenViewModelService) {
            FrageService = frageService;
            FragebogenViewModelService = fragebogenViewModelService;
        }

        // GET: Fragebogen/Details
        public ActionResult Details()
        {
            return View(FragebogenViewModelService.Map_Fragen_BearbeiteFragebogenViewModel(FrageService.FindAlleFragen()));
        }
    }
}