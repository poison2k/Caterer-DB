using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using System;
using System.Net;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class AntwortController : BaseController
    {
        private IAntwortViewModelService AntwortViewModelService { get; set; }

        private IAntwortService AntwortService { get; set; }

        public AntwortController(IAntwortService antwortService, IAntwortViewModelService antwortViewModelService)
        {
            AntwortService = antwortService;
            AntwortViewModelService = antwortViewModelService;
        }

        // GET: Antworts
        public ActionResult Index()
        {
            return View(AntwortService.FindAlleAntworten());
        }

        // GET: Antworts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsAntwortViewModel AntwortViewModel =
                AntwortViewModelService.Map_Antwort_DetailsAntwortViewModel(AntwortService.SearchAntwortById(Convert.ToInt32(id)));

            if (AntwortViewModel == null)
            {
                return HttpNotFound();
            }
            return View(AntwortViewModel);
        }

        // GET: Antworts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Antworts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAntwortViewModel createAntwortViewModel)
        {
            if (ModelState.IsValid)
            {
                AntwortService.AddAntwort(AntwortViewModelService.Map_CreateAntwortViewModel_Antwort(createAntwortViewModel));
                return RedirectToAction("Index");
            }

            return View(createAntwortViewModel);
        }

        // GET: Antworts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditAntwortViewModel editAntwortViewModel =
               AntwortViewModelService.Map_Antwort_EditAntwortViewModel(AntwortService.SearchAntwortById(Convert.ToInt32(id)));

            if (editAntwortViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editAntwortViewModel);
        }

        // POST: Antworts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditAntwortViewModel editAntwortViewModel)
        {
            if (ModelState.IsValid)
            {
                AntwortService.EditAntwort(AntwortViewModelService.Map_EditAntwortViewModel_Antwort(editAntwortViewModel));
                return RedirectToAction("Index");
            }
            return View(editAntwortViewModel);
        }

        // GET: Antworts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteAntwortViewModel deleteAntwortViewModel =
                AntwortViewModelService.Map_Antwort_DeleteAntwortViewModel(AntwortService.SearchAntwortById(Convert.ToInt32(id)));

            if (deleteAntwortViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteAntwortViewModel);
        }

        // POST: Antworts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AntwortService.RemoveAntwort(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }
    }
}