using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataAccess.Model;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Business.Interfaces;

namespace Caterer_DB.Controllers
{
    public class FrageController : BaseController
    {
        private IFrageViewModelService FrageViewModelService { get; set; }

        private ISparteService SparteService { get; set; }

        private IFrageService FrageService { get; set; }

        public FrageController(IFrageService frageService, IFrageViewModelService frageViewModelService, ISparteService sparteService)
        {
            SparteService = sparteService;
            FrageService = frageService;
            FrageViewModelService = frageViewModelService;
        }

        // GET: Frages
        public ActionResult Index()
        {
            return View(FrageService.FindAlleFragen());
        }

        // GET: Frages/Details/5
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

        // GET: Frages/Create
        public ActionResult Create()
        {
            return View(FrageViewModelService.CreateCreateFrageViewModel(SparteService.FindAlleSparten()));
        }

        // POST: Frages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFrageViewModel createFrageViewModel, int test = 0 )
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["btnAddAnswer"] != null)
                {
                    if (createFrageViewModel.Antworten == null)
                    {
                        createFrageViewModel.Antworten = new List<Antwort>();
                    }
                    
                    createFrageViewModel.Antworten.Add(new Antwort());
                    
                    
                    return View(FrageViewModelService.AddListsToCreateFrageViewModel(createFrageViewModel,SparteService.FindAlleSparten()));

                }
                else if (Request.Form["btnDeleteAnswer"] != null)
                {
                    for (int i = 0; i < Request.Form.Count; i++)
                    {
                        if (Request.Form.AllKeys.ElementAt(i) == "btnDeleteAnswer")
                        {
                            ModelState.Clear();
                            createFrageViewModel.Antworten.RemoveAt(i / 2 - 2);
                            return View(FrageViewModelService.AddListsToCreateFrageViewModel(createFrageViewModel, SparteService.FindAlleSparten()));
                        }
                    }                    
                }
                else if (Request.Form["btnCreateQuestion"] != null)
                {
                    var frage = FrageViewModelService.Map_CreateFrageViewModel_Frage(createFrageViewModel);
                    frage.Sparte = SparteService.SearchSparteByName(createFrageViewModel.SpartenName);
                    FrageService.AddFrage(frage);
                }

                return RedirectToAction("Index");
            }

            return View(FrageViewModelService.AddListsToCreateFrageViewModel(createFrageViewModel, SparteService.FindAlleSparten()));
        }

        // GET: Frages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditFrageViewModel editFrageViewModel =
               FrageViewModelService.Map_Frage_EditFrageViewModel(FrageService.SearchFrageById(Convert.ToInt32(id)),SparteService.FindAlleSparten());

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
            if (ModelState.IsValid)
            {
                if (Request.Form["btnAddAnswer"] != null)
                {
                    if (editFrageViewModel.Antworten == null)
                    {
                        editFrageViewModel.Antworten = new List<Antwort>();
                    }

                    editFrageViewModel.Antworten.Add(new Antwort());


                    return View(FrageViewModelService.AddListsToEditFrageViewModel(editFrageViewModel, SparteService.FindAlleSparten()));

                }
                else if (Request.Form["btnDeleteAnswer"] != null)
                {
                    for (int i = 0; i < Request.Form.Count; i++)
                    {
                        if (Request.Form.AllKeys.ElementAt(i) == "btnDeleteAnswer")
                        {
                            ModelState.Clear();
                            editFrageViewModel.Antworten.RemoveAt(i / 2 - 2);
                            return View(FrageViewModelService.AddListsToEditFrageViewModel(editFrageViewModel, SparteService.FindAlleSparten()));
                        }
                    }
                }
                else if (Request.Form["btnSave"] != null)
                {
                    var frage = FrageViewModelService.Map_EditFrageViewModel_Frage(editFrageViewModel);
                    frage.Sparte = SparteService.SearchSparteByName(editFrageViewModel.SpartenName);
                    FrageService.EditFrage(frage);
                }
                return RedirectToAction("Index");
            }
            return View(FrageViewModelService.AddListsToEditFrageViewModel(editFrageViewModel,SparteService.FindAlleSparten()));
        }

        // GET: Frages/Delete/5
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


    }
}
