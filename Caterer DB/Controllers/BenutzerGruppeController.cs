using System;
using System.Net;
using System.Web.Mvc;
using Caterer_DB.Models.ViewModelServices;
using Business.Interfaces;
using Caterer_DB.Models;

namespace Caterer_DB.Controllers
{
    public class BenutzerGruppeController : BaseController
    {
        private BenutzerGruppeViewModelService BenutzerGruppeViewModelService = new BenutzerGruppeViewModelService();

        private IBenutzerGruppeService BenutzerGruppeService { get; set; }

        public BenutzerGruppeController(IBenutzerGruppeService benutzerGruppeService)
        {
            BenutzerGruppeService = benutzerGruppeService;
        }
        // GET: BenutzerGruppe
        public ActionResult Index()
        {
            return View(BenutzerGruppeService.FindAllGroups());
        }

        // GET: BenutzerGruppe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsBenutzerGruppeViewModel detailsGruppeBenutzerViewModel =
                BenutzerGruppeViewModelService.Map_BenutzerGruppe_DetailsBenutzerGruppeViewModel(BenutzerGruppeService.SearchGroupById(Convert.ToInt32(id)));

            if (detailsGruppeBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(detailsGruppeBenutzerViewModel);
        }

        // GET: BenutzerGruppe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BenutzerGruppe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBenutzerGruppeViewModel createBenutzerGruppeViewModel)
        {
            if (ModelState.IsValid)
            {
                BenutzerGruppeService.AddBenutzerGruppe(BenutzerGruppeViewModelService.Map_CreateBenutzerGruppeViewModel_BenutzerGruppe(createBenutzerGruppeViewModel));
                return RedirectToAction("Index");
            }

            return View(createBenutzerGruppeViewModel);
        }

        // GET: BenutzerGruppe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditBenutzerGruppeViewModel editBenutzerGruppeViewModel =
                BenutzerGruppeViewModelService.Map_BenutzerGruppe_EditBenutzerGruppeViewModel(BenutzerGruppeService.SearchGroupById(Convert.ToInt32(id)));

            if (editBenutzerGruppeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editBenutzerGruppeViewModel);
        }

        // POST: BenutzerGruppe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBenutzerGruppeViewModel editBenutzerGruppeViewModel)
        {
            if (ModelState.IsValid)
            {
                BenutzerGruppeService.EditBenutzerGruppe(BenutzerGruppeViewModelService.Map_EditBenutzerGruppeViewModel_BenutzerGruppe(editBenutzerGruppeViewModel));

                return RedirectToAction("Index");
            }
            return View(editBenutzerGruppeViewModel);
        }

        // GET: BenutzerGruppe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteBenutzerGruppeViewModel deleteBenutzerGruppeViewModel =
                BenutzerGruppeViewModelService.Map_BenutzerGruppe_DeleteBenutzerGruppeViewModel(BenutzerGruppeService.SearchGroupById(Convert.ToInt32(id)));

            if (deleteBenutzerGruppeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteBenutzerGruppeViewModel);
        }

        // POST: BenutzerGruppe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BenutzerGruppeService.RemoveBenutzerGruppe(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }
    }
}
