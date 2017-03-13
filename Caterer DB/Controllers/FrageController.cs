using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Context;
using DataAccess.Model;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Business.Interfaces;

namespace Caterer_DB.Controllers
{
    public class FrageController : BaseController
    {
        private IFrageViewModelService FrageViewModelService { get; set; }

        private IFrageService FrageService { get; set; }

        public FrageController(IFrageService frageService, IFrageViewModelService frageViewModelService)
        {
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
            return View();
        }

        // POST: Frages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFrageViewModel createFrageViewModel)
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
                    return View(createFrageViewModel);

                }
                else if (Request.Form["btnCreateQuestion"] != null)
                {

                    FrageService.AddFrage(FrageViewModelService.Map_CreateFrageViewModel_Frage(createFrageViewModel));
                }

                return RedirectToAction("Index");
            }

            return View(createFrageViewModel);
        }

        // GET: Frages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditFrageViewModel editFrageViewModel =
               FrageViewModelService.Map_Frage_EditFrageViewModel(FrageService.SearchFrageById(Convert.ToInt32(id)));

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
                FrageService.EditFrage(FrageViewModelService.Map_EditFrageViewModel_Frage(editFrageViewModel));
                return RedirectToAction("Index");
            }
            return View(editFrageViewModel);
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




        // GET: Frages/Edit/5
        public ActionResult Bearbeiten(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BearbeiteFrageViewModel bearbeiteFrageViewModel =
               FrageViewModelService.Map_Frage_BearbeiteFrageViewModel(FrageService.SearchFrageById(Convert.ToInt32(id)));

            if (bearbeiteFrageViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bearbeiteFrageViewModel);
        }

        // POST: Frages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bearbeiten(BearbeiteFrageViewModel bearbeiteFrageViewModel)
        {
            if (ModelState.IsValid)
            {
                FrageService.EditFrage(FrageViewModelService.Map_BearbeiteFrageViewModel_Frage(bearbeiteFrageViewModel));
                return RedirectToAction("Index");
            }
            return View(bearbeiteFrageViewModel);
        }
    }
}
