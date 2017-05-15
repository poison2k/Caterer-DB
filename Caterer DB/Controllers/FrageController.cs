using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Resources;
using Caterer_DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Common.Model;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class FrageController : BaseController
    {
        private IFrageViewModelService FrageViewModelService { get; set; }

        private IKategorieService KategorienService { get; set; }

        private IFrageService FrageService { get; set; }

        public FrageController(IFrageService frageService, IFrageViewModelService frageViewModelService, IKategorieService kategorienService)
        {
            KategorienService = kategorienService;
            FrageService = frageService;
            FrageViewModelService = frageViewModelService;
        }

        // GET: Frages
        [CustomAuthorize(Rights = RechteResource.IndexFrage)]
        public ActionResult Index(int aktuelleSeite = 1, int seitenGrösse = 10, string Sortierrung = "Bezeichnung")
        {
            ViewBag.Sortierrung = Sortierrung;

            return View(FrageViewModelService.GeneriereListViewModel(
                FrageService.FindAllFrageWithPagingNeu(aktuelleSeite, seitenGrösse, Sortierrung)
               , FrageService.GetFrageNeuCount()
               , aktuelleSeite
               , seitenGrösse));
        }

        // GET: Frages
        [CustomAuthorize(Rights = RechteResource.IndexFrage)]
        public ActionResult IndexVeroeffentlicht(int aktuelleSeite = 1, int seitenGrösse = 10, string Sortierrung = "Bezeichnung")
        {
            ViewBag.Sortierrung = Sortierrung;

            return View(FrageViewModelService.GeneriereListViewModel(
                FrageService.FindAllFrageWithPagingVeröffentlicht(aktuelleSeite, seitenGrösse, Sortierrung)
               , FrageService.GetFrageVeröffentlichtCount()
               , aktuelleSeite
               , seitenGrösse));
        }

        // GET: Frages/Details/5
        [CustomAuthorize(Rights = RechteResource.DetailsFrage)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsFrageViewModel FrageViewModel =
                FrageViewModelService.Map_Frage_DetailsFrageViewModel(FrageService.SearchFrageById(Convert.ToInt32(id)));

            if (FrageViewModel == null)
            {
                return HttpNotFound();
            }
            return View(FrageViewModel);
        }

        // GET: Frages/DetailsVeroeffentlicht/5
        [CustomAuthorize(Rights = RechteResource.DetailsFrage)]
        public ActionResult DetailsVeroeffentlicht(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsFrageViewModel FrageViewModel =
                FrageViewModelService.Map_Frage_DetailsFrageViewModel(FrageService.SearchFrageById(Convert.ToInt32(id)));

            if (FrageViewModel == null)
            {
                return HttpNotFound();
            }
            return View(FrageViewModel);
        }

        // Post: Frages/DetailsVeroeffentlicht/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailsVeroeffentlicht(DetailsFrageViewModel detailsFrageViewModel)
        {
            FrageService.RemoveFrage(detailsFrageViewModel.FrageId);

            if (detailsFrageViewModel == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("IndexVeroeffentlicht");
        }

        // GET: Frages/Create
        [CustomAuthorize(Rights = RechteResource.CreateFrage)]
        public ActionResult Create()
        {
            return View(FrageViewModelService.CreateCreateFrageViewModel(KategorienService.FindAlleKategorien()));
        }

        // POST: Frages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFrageViewModel createFrageViewModel)
        {
            if (Request.Form["btnAddAnswer"] != null)
            {
                if (createFrageViewModel.Antworten == null)
                {
                    createFrageViewModel.Antworten = new List<Antwort>();
                }

                createFrageViewModel.Antworten.Add(new Antwort());

                return View(FrageViewModelService.AddListsToCreateFrageViewModel(createFrageViewModel, KategorienService.FindAlleKategorien()));
            }
            else if (Request.Form["btnDeleteAnswer"] != null)
            {
           
                    for (int i = 0; i < Request.Form.Count; i++)
                    {
                        if (Request.Form.AllKeys.ElementAt(i) == "btnDeleteAnswer")
                        {
                            ModelState.Clear();
                            createFrageViewModel.Antworten.RemoveAt(i / 2 - 3);
                            return View(FrageViewModelService.AddListsToCreateFrageViewModel(createFrageViewModel, KategorienService.FindAlleKategorien()));
                        }
                    }
                
            }
            if (ModelState.IsValid)
            {
                if (Request.Form["btnCreateQuestion"] != null)
                {
                    var frage = FrageViewModelService.Map_CreateFrageViewModel_Frage(createFrageViewModel);
                    frage.Kategorie = KategorienService.SearchKategorieById(createFrageViewModel.KategorieId);
                    FrageService.AddFrage(frage);
                }

                return RedirectToAction("Index");
            }
            if(createFrageViewModel.Antworten == null)
            {
                createFrageViewModel.Antworten = new List<Antwort>();
            }
          
            return View(FrageViewModelService.AddListsToCreateFrageViewModel(createFrageViewModel, KategorienService.FindAlleKategorien()));
        }

        // GET: Frages/Edit/5

        [CustomAuthorize(Rights = RechteResource.EditFrage)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditFrageViewModel editFrageViewModel =
               FrageViewModelService.Map_Frage_EditFrageViewModel(FrageService.SearchFrageById(Convert.ToInt32(id)), KategorienService.FindAlleKategorien());

            if (editFrageViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editFrageViewModel);
        }

        // POST: Frages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditFrageViewModel editFrageViewModel)
        {
            if (Request.Form["btnAddAnswer"] != null)
            {
                if (editFrageViewModel.Antworten == null)
                {
                    editFrageViewModel.Antworten = new List<Antwort>();
                }

                editFrageViewModel.Antworten.Add(new Antwort());

                return View(FrageViewModelService.AddListsToEditFrageViewModel(editFrageViewModel, KategorienService.FindAlleKategorien()));
            }
            else if (Request.Form["btnDeleteAnswer"] != null)
            {
                for (int i = 0; i < Request.Form.Count; i++)
                {
                    if (Request.Form.AllKeys.ElementAt(i) == "btnDeleteAnswer")
                    {
                        ModelState.Clear();
                        editFrageViewModel.Antworten.RemoveAt(i / 2 - 3);
                        return View(FrageViewModelService.AddListsToEditFrageViewModel(editFrageViewModel, KategorienService.FindAlleKategorien()));
                    }
                }
            }
            if (ModelState.IsValid)
            {
                if (Request.Form["btnVeroeffentlichen"] != null)
                {
                    var frage = FrageViewModelService.Map_EditFrageViewModel_Frage(editFrageViewModel);
                    frage.Kategorie = KategorienService.SearchKategorieById(editFrageViewModel.KategorieId);
                    frage.IstVeröffentlicht = true;
                    FrageService.EditFrage(frage);
                }
                else if (Request.Form["btnSave"] != null)
                {
                    var frage = FrageViewModelService.Map_EditFrageViewModel_Frage(editFrageViewModel);
                    frage.Kategorie = KategorienService.SearchKategorieById(editFrageViewModel.KategorieId);
                    FrageService.EditFrage(frage);
                }
                else if (Request.Form["btnModalDelete"] != null)
                {
                    FrageService.RemoveFrage(FrageViewModelService.Map_EditFrageViewModel_Frage(editFrageViewModel).FrageId);
                }
                return RedirectToAction("Index");
            }
            return View(FrageViewModelService.AddListsToEditFrageViewModel(editFrageViewModel, KategorienService.FindAlleKategorien()));
        }

        // GET: Frages/Delete/5
        [CustomAuthorize(Rights = RechteResource.DeleteFrage)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteFrageViewModel deleteFrageViewModel =
                FrageViewModelService.Map_Frage_DeleteFrageViewModel(FrageService.SearchFrageById(Convert.ToInt32(id)));

            if (deleteFrageViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteFrageViewModel);
        }

        // POST: Frages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FrageService.RemoveFrage(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AjaxLadeAntwortenZuFrage(FormCollection formCollection, int frageId = 0)
        {
            JsonResult returnJson = null;

            if (frageId == 0)
            {
                returnJson = Json(new List<AjaxAntwort>(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                returnJson = Json(FrageViewModelService.WandleAntworteninAjaxAntworten(FrageService.SearchFrageById(frageId).Antworten), JsonRequestBehavior.AllowGet);
            }

            return returnJson;
        }
    }
}