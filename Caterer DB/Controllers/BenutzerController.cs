using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Resources;
using Caterer_DB.Services;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using System.Xml;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class BenutzerController : BaseController
    {
        private IBenutzerViewModelService BenutzerViewModelService { get; set; }

        private IBenutzerService BenutzerService { get; set; }

        private IFrageService FrageService { get; set; }

        public ILoginService LoginService { get; set; }

        public BenutzerController(IBenutzerService benutzerService, IBenutzerViewModelService benutzerViewModelService, ILoginService loginService, IFrageService frageService)
        {
            LoginService = loginService;
            BenutzerService = benutzerService;
            BenutzerViewModelService = benutzerViewModelService;
            FrageService = frageService;
        }

        // GET: Benutzer
        [CustomAuthorize(Rights = RechteResource.IndexMitarbeiter)]
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
        [CustomAuthorize(Rights = RechteResource.IndexCaterer)]
        public ActionResult IndexCaterer(string suche, int aktuelleSeite = 1, int seitenGrösse = 10, string Sortierrung = "Firmenname")
        {
            var fullFilterViewModel = new FullFilterCatererViewModel();
            fullFilterViewModel = BenutzerViewModelService.AddListsToFullFilterCatererViewModel(fullFilterViewModel);
            fullFilterViewModel = BenutzerViewModelService.AddFragenListsToFullFilterCatererViewModel(fullFilterViewModel, FrageService.FindAlleFragen());
            fullFilterViewModel.ResultListCaterer = BenutzerViewModelService.GeneriereListViewModelCaterer(
                 BenutzerService.FindAllCatererWithPaging(aktuelleSeite, seitenGrösse, Sortierrung, -1, "", "", new List<int>())
                , BenutzerService.GetCatererCount()
                , aktuelleSeite
                , seitenGrösse);
            ViewBag.Sortierrung = Sortierrung;

            return View(fullFilterViewModel);
        }

        // GET: Benutzer
        [HttpPost]
        [CustomAuthorize(Rights = RechteResource.IndexCaterer)]
        public ActionResult IndexCaterer(FullFilterCatererViewModel fullFilterCatererViewModel, FormCollection formCollection)
        {
            List<string> values = new List<string>();
            List<int> antwortIds = new List<int>();

            foreach (var key in formCollection.Keys)
            {
                if(key.ToString().Contains("antworten"))
                values.Add(key.ToString()); 
            }

            foreach (string key in values) {
                antwortIds.Add(Convert.ToInt32(formCollection[key]));
            }

            if (Request.Form["btnVergleich"] != null)
            {
                string listIds = "";
                var count = 0;
                foreach (IndexCatererViewModel caterer in fullFilterCatererViewModel.ResultListCaterer.Entitäten)
                {
                    if (caterer.selected)
                    {
                        listIds += caterer.BenutzerId + ",";
                        count++;
                    }
                }
                if (count > 0 && count < 4)
                {
                    return RedirectToAction("VergleichCaterer", "Benutzer", new { ids = listIds });
                }
            }
            string Sortierrung = "Firmenname";
            int aktuelleSeite = 1;
            var seitenGrösse = 10;
            if (Request.Form["Telefon"] != null)
            {
                Sortierrung = "Telefon";
            }
            else if (Request.Form["Telefon_desc"] != null)
            {
                Sortierrung = "Telefon_desc";
            }
            else if (Request.Form["Firmenname"] != null)
            {
                Sortierrung = "Firmenname";
            }
            else if (Request.Form["Firmenname_desc"] != null)
            {
                Sortierrung = "Firmenname_desc";
            }
            else if (Request.Form["Ort"] != null)
            {
                Sortierrung = "Ort";
            }
            else if (Request.Form["Ort_desc"] != null)
            {
                Sortierrung = "Ort_desc";
            }
            else if (Request.Form["Postleitzahl"] != null)
            {
                Sortierrung = "Postleitzahl";
            }
            else if (Request.Form["Postleitzahl_desc"] != null)
            {
                Sortierrung = "Postleitzahl_desc";
            }


            ViewBag.Sortierrung = Sortierrung;


            var resultList = BenutzerService.FindAllCatererWithPaging(aktuelleSeite, seitenGrösse, Sortierrung, Convert.ToInt32(fullFilterCatererViewModel.Umkreis), fullFilterCatererViewModel.PLZ, fullFilterCatererViewModel.Name, antwortIds);
            var resultcount = BenutzerService.FindAllCatererWithPaging(aktuelleSeite, 1000000, Sortierrung, Convert.ToInt32(fullFilterCatererViewModel.Umkreis), fullFilterCatererViewModel.PLZ, fullFilterCatererViewModel.Name, antwortIds).Count;
            fullFilterCatererViewModel.ResultListCaterer = BenutzerViewModelService.GeneriereListViewModelCaterer(
                resultList
                , resultcount
                , aktuelleSeite
                , seitenGrösse);
            fullFilterCatererViewModel = BenutzerViewModelService.AddListsToFullFilterCatererViewModel(fullFilterCatererViewModel);
            fullFilterCatererViewModel = BenutzerViewModelService.AddFragenListsToFullFilterCatererViewModel(fullFilterCatererViewModel, FrageService.FindAlleFragen());
            return View(fullFilterCatererViewModel);
        }

        // GET: Benutzer/Details/5
        [CustomAuthorize(Rights = RechteResource.DetailsMitarbeiter)]
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
        [CustomAuthorize(Rights = RechteResource.DetailsCaterer)]
        public ActionResult DetailsCaterer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsCatererViewModel detailsCatererViewModel =
                BenutzerViewModelService.Map_Benutzer_DetailsCatererViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)), FrageService.FindAlleFragenNachKategorieninEigenenListen());

            if (detailsCatererViewModel == null)
            {
                return HttpNotFound();
            }
            return View(detailsCatererViewModel);
        }

        // GET: Benutzer/Create
        [CustomAuthorize(Rights = RechteResource.CreateMitarbeiter)]
        public ActionResult Create()
        {
            return View(BenutzerViewModelService.CreateNewCreateMitarbeiterViewModel());
        }

        // GET: Benutzer/CreateCaterer
        [CustomAuthorize(Rights = RechteResource.CreateCaterer)]
        public ActionResult CreateCaterer()
        {
            return View(BenutzerViewModelService.CreateNewCreateCatererViewModel());
        }

        // POST: Benutzer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Rights = RechteResource.CreateMitarbeiter)]
        public ActionResult Create(CreateMitarbeiterViewModel createMitarbeiterViewModel)
        {
            if (ModelState.IsValid)
            {
                if (BenutzerService.CheckEmailForRegistration(createMitarbeiterViewModel.Mail))
                {
                    if (Convert.ToBoolean(createMitarbeiterViewModel.IstAdmin))
                    {
                        BenutzerService.AddMitarbeiter(BenutzerViewModelService.Map_CreateMitarbeiterViewModel_Benutzer(createMitarbeiterViewModel), BenutzerGruppenResource.Administrator);
                    }
                    else
                    {
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
        [CustomAuthorize(Rights = RechteResource.CreateCaterer)]
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
        [CustomAuthorize(Rights = RechteResource.EditMitarbeiter)]
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
                if (Request.Form["btnSave"] != null)
                {
                    BenutzerService.EditBenutzer(BenutzerViewModelService.Map_EditBenutzerViewModel_Benutzer(editBenutzerViewModel), Convert.ToBoolean(editBenutzerViewModel.IstAdmin));
                    return RedirectToAction("Index");
                }
                else if (Request.Form["btnModalDelete"] != null)
                {
                    BenutzerService.RemoveBenutzer(BenutzerViewModelService.Map_EditBenutzerViewModel_Benutzer(editBenutzerViewModel).BenutzerId);
                    return RedirectToAction("Index");
                }
            }

            return View(BenutzerViewModelService.AddListsToEditViewModel(editBenutzerViewModel));
        }

        // GET: Benutzer/MeineDaten/5
        [CustomAuthorize(Rights = RechteResource.MeineDatenMitarbeiter)]
        public ActionResult MeineDaten(int? id)
        {
            if (id == null || id != User.BenutzerId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeineDatenBenutzerViewModel meineDatenBenutzerViewModel = BenutzerViewModelService.Map_Benutzer_MeineDatenBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (meineDatenBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(meineDatenBenutzerViewModel);
        }

        // POST: Benutzer/MeineDaten/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MeineDaten(MeineDatenBenutzerViewModel meineDatenBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["btnSave"] != null)
                {
                    BenutzerService.EditBenutzer(BenutzerViewModelService.Map_MeineDatenBenutzerViewModel_Benutzer(meineDatenBenutzerViewModel));
                    TempData["isSaved"] = true;
                }
                else if (Request.Form["btnModalDelete"] != null)
                {
                    LoginService.Abmelden();
                    BenutzerService.RemoveBenutzer(BenutzerViewModelService.Map_MeineDatenBenutzerViewModel_Benutzer(meineDatenBenutzerViewModel).BenutzerId);
                    TempData["isAccountDeleted"] = true;
                }
                return RedirectToAction("Index", "Home");
            }
            return View(BenutzerViewModelService.AddListsToMeineDatenViewModel(meineDatenBenutzerViewModel));
        }

        // GET: Benutzer/Mydata/5
        public ActionResult MyData(int? id)
        {
            if (id == null || id != User.BenutzerId)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            MyDataBenutzerViewModel myDataBenutzerViewModel =
                BenutzerViewModelService.Map_Benutzer_MyDataBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)), FrageService.FindAlleFragenNachKategorieninEigenenListen());

            if (myDataBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(myDataBenutzerViewModel);
        }

        // GET: Benutzer/Mydata/5
        [CustomAuthorize(Rights = RechteResource.EditCaterer)]
        public ActionResult EditCaterer(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            MyDataBenutzerViewModel myDataBenutzerViewModel =
                BenutzerViewModelService.Map_Benutzer_MyDataBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)), FrageService.FindAlleFragenNachKategorieninEigenenListen());

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
                    List<int> antwortIDs = BenutzerViewModelService.Map_MyDataBenutzerViewModel_BenutzerResultSet(myDataBenutzerViewModel);
                    var benutzer = BenutzerService.SearchUserById(myDataBenutzerViewModel.BenutzerId);
                    benutzer.AntwortIDs = antwortIDs;
                    BenutzerService.EditBenutzer(benutzer);
                    return RedirectToAction("DetailsCaterer", new RouteValueDictionary(new { controller = "Benutzer", action = "DetailsCaterer", Id = benutzer.BenutzerId }));
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

        // POST: Benutzer/DetailsCaterer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailsCaterer(DetailsCatererViewModel detailsCatererViewModel)
        {
            string dateiName = "CatererUebersicht.docx";

            if (Request.Form["lueneburg"] != null)
            {
                dateiName = "CatererUebersicht.docx";
            }
            else if (Request.Form["braunschweig"] != null)
            {
                dateiName = "CatererUebersicht.docx";
            }
            else if (Request.Form["osnabrueck"] != null)
            {
                dateiName = "CatererUebersicht.docx";
            }

            string quellDatei = "/Content/DocxVorlagen/" + dateiName;
            string zielDatei = dateiName;

            byte[] dateiArray = System.IO.File.ReadAllBytes(HostingEnvironment.MapPath(quellDatei));
            var memoryStream = new MemoryStream(dateiArray, true);
            BenutzerService.DokumentDrucken(BenutzerService.SearchUserById(detailsCatererViewModel.BenutzerId), memoryStream);

            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", zielDatei);

        }

        // GET: Benutzer/Delete/5
        [CustomAuthorize(Rights = RechteResource.DeleteMitarbeiter)]
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


        // GET: Benutzer/Delete/5

        public ActionResult VergleichCaterer(string ids)
        {

            List<int> listIds = new List<int>();
            string[] stringlist = new string[0];
            if (ids != "" && ids != null)
            {
                stringlist = ids.Split(',');
            }


            foreach (string caterer in stringlist)
            {
                if (caterer != "")
                {
                    listIds.Add(Convert.ToInt32(caterer));
                }
            }

            var vergleichCatererViewModel = BenutzerViewModelService.Map_ListBenutzer_VergleichCatererViewModel(BenutzerService.FindeCatererNachIds(listIds), FrageService.FindAlleFragenNachKategorieninEigenenListen());



            return View(vergleichCatererViewModel);
        }

     
    }
}