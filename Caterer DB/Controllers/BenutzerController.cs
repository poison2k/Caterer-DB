﻿using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Common.Resources;
using Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Hosting;
using System.Web.Mvc;
using Caterer_DB.MVCServices;
using Caterer_DB.ViewModel;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class BenutzerController : BaseController
    {
        private IBenutzerViewModelService BenutzerViewModelService { get; set; }

        private IBenutzerService BenutzerService { get; set; }

        private IFrageService FrageService { get; set; }

        public ILoginService LoginService { get; set; }

        public IDokumentService DokumentService { get; set; }

        public BenutzerController(IBenutzerService benutzerService, IBenutzerViewModelService benutzerViewModelService, ILoginService loginService, IFrageService frageService, IDokumentService dokumentService)
        {
            LoginService = loginService;
            BenutzerService = benutzerService;
            BenutzerViewModelService = benutzerViewModelService;
            FrageService = frageService;
            DokumentService = dokumentService;
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
            var fullFilterCatererViewModel = new FullFilterCatererViewModel();

            if (fullFilterCatererViewModel.FrageAntwortModel == null)
            {
                fullFilterCatererViewModel.FrageAntwortModel = new List<FrageAntwortModel>();
                fullFilterCatererViewModel.FrageAntwortModel.Add(new FrageAntwortModel() { FrageAntwortId = fullFilterCatererViewModel.FrageAntwortModel.Count, AntwortId = 0, FrageId = 0 });
            }

            fullFilterCatererViewModel = BenutzerViewModelService.AddListsToFullFilterCatererViewModel(fullFilterCatererViewModel);
            fullFilterCatererViewModel = BenutzerViewModelService.AddFragenListsToFullFilterCatererViewModel(fullFilterCatererViewModel, FrageService.FindAlleFragen());
            fullFilterCatererViewModel.ResultListCaterer = BenutzerViewModelService.GeneriereListViewModelCaterer(
                 BenutzerService.FindAllCatererWithPaging(aktuelleSeite, seitenGrösse, Sortierrung, -1, "", "", new List<int>())
                , BenutzerService.GetCatererCount()
                , aktuelleSeite
                , seitenGrösse);
            ViewBag.Sortierrung = Sortierrung;

            return View(fullFilterCatererViewModel);
        }

        // GET: Benutzer
        [HttpPost]
        [CustomAuthorize(Rights = RechteResource.IndexCaterer)]
        public ActionResult IndexCaterer(FullFilterCatererViewModel fullFilterCatererViewModel, FormCollection formCollection)
        {
            // Weiterleitung falls Vergleich gewünscht ist
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

            List<int> antwortIds = new List<int>();

            //Model State korriegieren wenn keine PLZ gewählt ist damit kein Fehler ausgegeben wird
            if (fullFilterCatererViewModel.PLZ == null)
            {
                ModelState.Remove("Umkreis");
                ModelState.Remove("PLZ");
            }

            //Neuen FragenFilter hinzufügen oder entfernen
            if (Request.Form["btnAddFilter"] != null)
            {
                if (fullFilterCatererViewModel.FrageAntwortModel == null)
                {
                    fullFilterCatererViewModel.FrageAntwortModel = new List<FrageAntwortModel>();
                }

                fullFilterCatererViewModel.FrageAntwortModel.Add(new FrageAntwortModel() { FrageAntwortId = fullFilterCatererViewModel.FrageAntwortModel.Count + 1, AntwortId = 0, FrageId = 0 });
            }
            else if (Request.Form["btnDeleteFilter"] != null)
            {
                fullFilterCatererViewModel.FrageAntwortModel.RemoveAt(fullFilterCatererViewModel.FrageAntwortModel.Count - 1);
            }

            //aktuell Gewählte Antworten in Liste Speichern
            foreach (FrageAntwortModel frageAntwort in fullFilterCatererViewModel.FrageAntwortModel)
            {
                if (frageAntwort.AntwortId != 0)
                {
                    antwortIds.Add(frageAntwort.AntwortId);
                }
            }

            //Sortierung ermitteln
            string sortierrung = "Firmenname";
            int aktuelleSeite = 1;
            var seitenGrösse = 10;
            if (Request.Form["Telefon"] != null)
            {
                sortierrung = "Telefon";
            }
            else if (Request.Form["Telefon_desc"] != null)
            {
                sortierrung = "Telefon_desc";
            }
            else if (Request.Form["Firmenname"] != null)
            {
                sortierrung = "Firmenname";
            }
            else if (Request.Form["Firmenname_desc"] != null)
            {
                sortierrung = "Firmenname_desc";
            }
            else if (Request.Form["Ort"] != null)
            {
                sortierrung = "Ort";
            }
            else if (Request.Form["Ort_desc"] != null)
            {
                sortierrung = "Ort_desc";
            }
            else if (Request.Form["Postleitzahl"] != null)
            {
                sortierrung = "Postleitzahl";
            }
            else if (Request.Form["Postleitzahl_desc"] != null)
            {
                sortierrung = "Postleitzahl_desc";
            }
            ViewBag.Sortierrung = sortierrung;

            List<Benutzer> resultList;
            int resultcount = 0;

            //Falls fehlerhafte eingaben existieren
            if (!ModelState.IsValid)
            {
                resultList = BenutzerService.FindAllCatererWithPaging(aktuelleSeite, seitenGrösse, sortierrung, Convert.ToInt32(fullFilterCatererViewModel.Umkreis), null, fullFilterCatererViewModel.Name, antwortIds);
                resultcount = BenutzerService.FindAllCatererWithPaging(aktuelleSeite, 1000000, sortierrung, Convert.ToInt32(fullFilterCatererViewModel.Umkreis), null, fullFilterCatererViewModel.Name, antwortIds).Count;
                fullFilterCatererViewModel.ResultListCaterer = BenutzerViewModelService.GeneriereListViewModelCaterer(
                    resultList
                    , resultcount
                    , aktuelleSeite
                    , seitenGrösse);

                fullFilterCatererViewModel = BenutzerViewModelService.AddListsToFullFilterCatererViewModel(fullFilterCatererViewModel);
                fullFilterCatererViewModel = BenutzerViewModelService.AddFragenListsToFullFilterCatererViewModel(fullFilterCatererViewModel, FrageService.FindAlleFragen());

                return View(fullFilterCatererViewModel);
            }
            // Caterer abrufen mit allen Filtern
            resultList = BenutzerService.FindAllCatererWithPaging(aktuelleSeite, seitenGrösse, sortierrung, Convert.ToInt32(fullFilterCatererViewModel.Umkreis), fullFilterCatererViewModel.PLZ, fullFilterCatererViewModel.Name, antwortIds);
            resultcount = BenutzerService.FindAllCatererWithPaging(aktuelleSeite, 1000000, sortierrung, Convert.ToInt32(fullFilterCatererViewModel.Umkreis), fullFilterCatererViewModel.PLZ, fullFilterCatererViewModel.Name, antwortIds).Count;
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
                    try
                    {
                        BenutzerService.AddCaterer(BenutzerViewModelService.Map_CreateCatererViewModel_Benutzer(createCatererViewModel), BenutzerGruppenResource.Caterer);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(BenutzerViewModelService.AddListsToCreateCatererViewModel(createCatererViewModel));
                    }
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
                    BenutzerService.AdminEditMitarbeiterData(BenutzerViewModelService.Map_EditBenutzerViewModel_Benutzer(editBenutzerViewModel), Convert.ToBoolean(editBenutzerViewModel.IstAdmin));
                    return RedirectToAction("Index");
                }
                else if (Request.Form["btnModalDelete"] != null)
                {
                    if (editBenutzerViewModel.BenutzerId == User.BenutzerId)
                    {
                        LoginService.Abmelden();
                    }
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
                return RedirectToAction("ZugriffVerweigert", "Error");
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
                    try
                    {
                        BenutzerService.EditBenutzer(BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel));
                        TempData["isSaved"] = true;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(BenutzerViewModelService.AddListsToMyDataViewModel(myDataBenutzerViewModel));
                    }
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
                    try
                    {
                        BenutzerService.EditCaterer(BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel));
                        List<int> antwortIDs = BenutzerViewModelService.Map_MyDataBenutzerViewModel_BenutzerResultSet(myDataBenutzerViewModel);
                        var benutzer = BenutzerService.SearchUserById(myDataBenutzerViewModel.BenutzerId);
                        benutzer.AntwortIDs = antwortIDs;
                        BenutzerService.EditBenutzer(benutzer);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(BenutzerViewModelService.AddListsToMyDataViewModel(myDataBenutzerViewModel));
                    }
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
            string dateiName = "";
            bool istWeitergabeErlaubt = BenutzerService.SearchUserById(detailsCatererViewModel.BenutzerId).WeitergabeVonDaten;

            if (Request.Form["lueneburg"] != null)
            {
                if (istWeitergabeErlaubt)
                {
                    dateiName = "InformationsblattLueneburg.docx";
                }
                else
                {
                    dateiName = "InformationsblattLueneburgWasserzeichen.docx";
                }
            }
            else if (Request.Form["braunschweig"] != null)
            {
                if (istWeitergabeErlaubt)
                {
                    dateiName = "InformationsblattBraunschweig.docx";
                }
                else
                {
                    dateiName = "InformationsblattBraunschweigWasserzeichen.docx";
                }
            }
            else if (Request.Form["osnabrueck"] != null)
            {
                if (istWeitergabeErlaubt)
                {
                    dateiName = "InformationsblattOsnabrueck.docx";
                }
                else
                {
                    dateiName = "InformationsblattOsnabrueckWasserzeichen.docx";
                }
            }

            string quellDatei = "/Content/DocxVorlagen/" + dateiName;
            string zielDatei = dateiName;

            byte[] dateiArray = System.IO.File.ReadAllBytes(HostingEnvironment.MapPath(quellDatei));
            var memoryStream = new MemoryStream(dateiArray, true);
            DokumentService.DokumentDrucken(BenutzerService.SearchUserById(detailsCatererViewModel.BenutzerId), memoryStream);

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
        [CustomAuthorize(Rights = RechteResource.VergleichCaterer)]
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