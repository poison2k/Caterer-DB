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
using Business.Interfaces;
using Caterer_DB.Models;

namespace Caterer_DB.Controllers
{
    public class SparteController : BaseController
    {
        private ISparteViewModelService SparteViewModelService { get; set; }

        private ISparteService SparteService { get; set; }

        public SparteController(ISparteService sparteService, ISparteViewModelService sparteViewModelService)
        {
            SparteService = sparteService;
            SparteViewModelService = sparteViewModelService;
        }

        // GET: Spartes
        public ActionResult Index()
        {
            return View(SparteService.FindAlleSparten());
        }

        // GET: Spartes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsSparteViewModel SparteViewModel =
                SparteViewModelService.Map_Sparte_DetailsSparteViewModel(SparteService.SearchSparteById(Convert.ToInt32(id)));

            if (SparteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(SparteViewModel);
        }

        // GET: Spartes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spartes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSparteViewModel createSparteViewModel)
        {
            if (ModelState.IsValid)
            {
                SparteService.AddSparte(SparteViewModelService.Map_CreateSparteViewModel_Sparte(createSparteViewModel));
                return RedirectToAction("Index");
            }

            return View(createSparteViewModel);
        }

        // GET: Spartes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditSparteViewModel editSparteViewModel =
               SparteViewModelService.Map_Sparte_EditSparteViewModel(SparteService.SearchSparteById(Convert.ToInt32(id)));

            if (editSparteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editSparteViewModel);
        }

        // POST: Spartes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditSparteViewModel editSparteViewModel)
        {
            if (ModelState.IsValid)
            {
                SparteService.EditSparte(SparteViewModelService.Map_EditSparteViewModel_Sparte(editSparteViewModel));
                return RedirectToAction("Index");
            }
            return View(editSparteViewModel);
        }

        // GET: Spartes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteSparteViewModel deleteSparteViewModel =
                SparteViewModelService.Map_Sparte_DeleteSparteViewModel(SparteService.SearchSparteById(Convert.ToInt32(id)));

            if (deleteSparteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteSparteViewModel);
        }

        // POST: Spartes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SparteService.RemoveSparte(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }

    }
}
