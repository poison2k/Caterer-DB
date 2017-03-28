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

    [Authorize]
    public class RechteGruppeController : BaseController
    {
        private IRechteGruppeViewModelService RechteGruppeViewModelService { get; set; }

        private IRechteGruppeService RechteGruppeService { get; set; }

        public RechteGruppeController(IRechteGruppeService rechteGruppeService, IRechteGruppeViewModelService rechteGruppeViewModelService)
        {
            RechteGruppeService = rechteGruppeService;
            RechteGruppeViewModelService = rechteGruppeViewModelService;
        }

        // GET: RechteGruppe
        public ActionResult Index()
        {
            return View(RechteGruppeService.FindAllRightGroups());
        }

        // GET: RechteGruppe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsRechteGruppeViewModel detailsGruppeBenutzerViewModel =
                RechteGruppeViewModelService.Map_RechteGruppe_DetailsRechteGruppeViewModel(RechteGruppeService.SearchRightGroupById(Convert.ToInt32(id)));

            if (detailsGruppeBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(detailsGruppeBenutzerViewModel);
        }

        // GET: RechteGruppe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RechteGruppe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRechteGruppeViewModel createRechteGruppeViewModel)
        {
            if (ModelState.IsValid)
            {
                RechteGruppeService.AddRechteGruppe(RechteGruppeViewModelService.Map_CreateRechteGruppeViewModel_RechteGruppe(createRechteGruppeViewModel));
                return RedirectToAction("Index");
            }

            return View(createRechteGruppeViewModel);
        }

        // GET: RechteGruppe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditRechteGruppeViewModel editRechteGruppeViewModel =
                RechteGruppeViewModelService.Map_RechteGruppe_EditRechteGruppeViewModel(RechteGruppeService.SearchRightGroupById(Convert.ToInt32(id)));

            if (editRechteGruppeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editRechteGruppeViewModel);
        }

        // POST: RechteGruppe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRechteGruppeViewModel editRechteGruppeViewModel)
        {
            if (ModelState.IsValid)
            {
                RechteGruppeService.EditRechteGruppe(RechteGruppeViewModelService.Map_EditRechteGruppeViewModel_RechteGruppe(editRechteGruppeViewModel));

                return RedirectToAction("Index");
            }
            return View(editRechteGruppeViewModel);
        }

        // GET: RechteGruppe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteRechteGruppeViewModel deleteRechteGruppeViewModel =
                RechteGruppeViewModelService.Map_RechteGruppe_DeleteRechteGruppeViewModel(RechteGruppeService.SearchRightGroupById(Convert.ToInt32(id)));

            if (deleteRechteGruppeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteRechteGruppeViewModel);
        }

        // POST: RechteGruppe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RechteGruppeService.RemoveRechteGruppe(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }
    }
}
