using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using Caterer_DB.Resources;
using Caterer_DB.Services;
using DataAccess.Model;
using System;
using System.Net;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class BenutzerController : BaseController
    {
        private IBenutzerViewModelService BenutzerViewModelService { get; set; }

        private IBenutzerService BenutzerService { get; set; }

        public ILoginService LoginService { get; set; }

        public BenutzerController(IBenutzerService benutzerService, IBenutzerViewModelService benutzerViewModelService, ILoginService loginService)
        {
            LoginService = loginService;
            BenutzerService = benutzerService;
            BenutzerViewModelService = benutzerViewModelService;

        }

        // GET: Benutzer
        [CustomAuthorize(Roles = RechteResource.IndexMitarbeiter)]
        public ActionResult Index(int aktuelleSeite = 1, int seitenGrösse = 10, string Sortierrung = "Nachname")
        {
            ViewBag.Sortierrung = Sortierrung;

            return View(BenutzerViewModelService.GeneriereListViewModel(
                 BenutzerService.FindAllMitarbeiterWithPaging(aktuelleSeite, seitenGrösse, Sortierrung)
                , BenutzerService.GetMitarbeiterCount()
                , aktuelleSeite
                , seitenGrösse));

        }

        // GET: Benutzer
        [CustomAuthorize(Roles = RechteResource.IndexCaterer)]
        public ActionResult IndexCaterer(string suche, int aktuelleSeite = 1, int seitenGrösse = 10, string Sortierrung = "Firmenname")
        {
            ViewBag.Sortierrung = Sortierrung;

            return View(BenutzerViewModelService.GeneriereListViewModelCaterer(
                 BenutzerService.FindAllCatererWithPaging(aktuelleSeite, seitenGrösse, Sortierrung)
                , BenutzerService.GetCatererCount()
                , aktuelleSeite
                , seitenGrösse));

        }

        // GET: Benutzer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsBenutzerViewModel detailsBenutzerViewModel =
                BenutzerViewModelService.Map_Benutzer_DetailsBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (detailsBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(detailsBenutzerViewModel);
        }

        // GET: Benutzer/Details/5
        public ActionResult DetailsCaterer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsCatererViewModel detailsCatererViewModel =
                BenutzerViewModelService.Map_Benutzer_DetailsCatererViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (detailsCatererViewModel == null)
            {
                return HttpNotFound();
            }
            return View(detailsCatererViewModel);
        }

        // GET: Benutzer/Create
        [CustomAuthorize(Roles = RechteResource.CreateMitarbeiter)]
        public ActionResult Create()
        {
            return View(BenutzerViewModelService.CreateNewCreateMitarbeiterViewModel());
        }

        // GET: Benutzer/CreateCaterer
        [CustomAuthorize(Roles = RechteResource.CreateCaterer)]
        public ActionResult CreateCaterer()
        {
            return View(BenutzerViewModelService.CreateNewCreateCatererViewModel());
        }

        // POST: Benutzer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = RechteResource.CreateMitarbeiter)]
        public ActionResult Create(CreateMitarbeiterViewModel createMitarbeiterViewModel)
        {
            if (ModelState.IsValid)
            {
                if (BenutzerService.CheckEmailForRegistration(createMitarbeiterViewModel.Mail))
                {
                    if (Convert.ToBoolean(createMitarbeiterViewModel.IstAdmin)){
                        BenutzerService.AddMitarbeiter(BenutzerViewModelService.Map_CreateMitarbeiterViewModel_Benutzer(createMitarbeiterViewModel), BenutzerGruppenResource.Administrator);
                    } else {
                        BenutzerService.AddMitarbeiter(BenutzerViewModelService.Map_CreateMitarbeiterViewModel_Benutzer(createMitarbeiterViewModel), BenutzerGruppenResource.Mitarbeiter);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", LoginResources.EMailVorhanden);
                    return View(BenutzerViewModelService.AddListsToCreateViewModel(createMitarbeiterViewModel));
                }
            }
            return View(BenutzerViewModelService.AddListsToCreateViewModel(createMitarbeiterViewModel));
        }

        // POST: Benutzer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = RechteResource.CreateCaterer)]
        public ActionResult CreateCaterer(CreateCatererViewModel createCatererViewModel)
        {
            if (ModelState.IsValid)
            {
                if (BenutzerService.CheckEmailForRegistration(createCatererViewModel.Mail))
                {
                    BenutzerService.AddCaterer(BenutzerViewModelService.Map_CreateCatererViewModel_Benutzer(createCatererViewModel), BenutzerGruppenResource.Caterer);
                }
                else
                {
                    ModelState.AddModelError("", LoginResources.EMailVorhanden);
                    return View(BenutzerViewModelService.AddListsToCreateCatererViewModel(createCatererViewModel));
                }
                return RedirectToAction("IndexCaterer");
            }

            return View(BenutzerViewModelService.AddListsToCreateCatererViewModel(createCatererViewModel));

        }

        // GET: Benutzer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditBenutzerViewModel editBenutzerViewModel = BenutzerViewModelService.Map_Benutzer_EditBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (editBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editBenutzerViewModel);
        }

        // POST: Benutzer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBenutzerViewModel editBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
              
                    BenutzerService.EditBenutzer(BenutzerViewModelService.Map_EditBenutzerViewModel_Benutzer(editBenutzerViewModel), Convert.ToBoolean(editBenutzerViewModel.IstAdmin));
                
                return RedirectToAction("Index");
            }
            return View(BenutzerViewModelService.AddListsToEditViewModel(editBenutzerViewModel));
        }


        // GET: Benutzer/Mydata/5
        public ActionResult MyData(int? id)
        {
            if (id == null || id != User.BenutzerId)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            MyDataBenutzerViewModel myDataBenutzerViewModel =
                BenutzerViewModelService.Map_Benutzer_MyDataBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (myDataBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(myDataBenutzerViewModel);
        }

        // GET: Benutzer/Mydata/5
        public ActionResult EditCaterer(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            MyDataBenutzerViewModel myDataBenutzerViewModel =
                BenutzerViewModelService.Map_Benutzer_MyDataBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (myDataBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(myDataBenutzerViewModel);
        }

        // POST: Benutzer/MyData/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyData(MyDataBenutzerViewModel myDataBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["btnSave"] != null)
                {
                    BenutzerService.EditBenutzer(BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel));
                    TempData["isSaved"] = true;

                }
                else if (Request.Form["btnModalDelete"] != null)
                {
                    LoginService.Abmelden();
                    BenutzerService.RemoveBenutzer(BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel).BenutzerId);
                    TempData["isAccountDeleted"] = true;

                }
                return RedirectToAction("Index", "Home");

            }
            return View(BenutzerViewModelService.AddListsToMyDataViewModel(myDataBenutzerViewModel));
        }

        // POST: Benutzer/MyData/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCaterer(MyDataBenutzerViewModel myDataBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["btnSave"] != null)
                {
                    BenutzerService.EditCaterer(BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel));
                    //TempData["isSaved"] = true;

                }
                else if (Request.Form["btnModalDelete"] != null)
                {
                    BenutzerService.RemoveCaterer(BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel).BenutzerId);
                    //TempData["isAccountDeleted"] = true;

                }
                return RedirectToAction("IndexCaterer", "Benutzer");

            }
            return View(BenutzerViewModelService.AddListsToMyDataViewModel(myDataBenutzerViewModel));
        }

        // GET: Benutzer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteBenutzerViewModel deleteBenutzerViewModel =
                BenutzerViewModelService.Map_Benutzer_DeleteBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (deleteBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteBenutzerViewModel);
        }

        // POST: Benutzer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            BenutzerService.RemoveBenutzer(Convert.ToInt32(id));

            return RedirectToAction("Index");
        }
    }
}