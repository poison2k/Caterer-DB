using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Common.Resources;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class ConfigController : BaseController
    {
        public IConfigViewModelService ConfigViewModelService { get; set; }

        public IConfigService ConfigService { get; set; }

        public ConfigController(IConfigViewModelService configViewModelService, IConfigService configService)
        {
            ConfigViewModelService = configViewModelService;
            ConfigService = configService;
        }

        // GET: Config
        [CustomAuthorize(Rights = RechteResource.EditConfig)]
        public ActionResult Edit()
        {
            return View(ConfigViewModelService.Map_Config_EditConfigViewModel(ConfigService.GetConfig()));
        }

        // POST: Config
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditConfigViewModel editConfigViewModel)
        {
            if (ModelState.IsValid)
            {
                ConfigService.EditConfig(ConfigViewModelService.Map_EditConfigViewModel_Config(editConfigViewModel));
                return RedirectToAction("Index", "Home");
            }

            return View(editConfigViewModel);
        }
    }
}