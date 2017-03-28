using System;
using System.Net;
using System.Web.Mvc;
using Caterer_DB.Interfaces;
using Business.Interfaces;
using Caterer_DB.Models;

namespace Caterer_DB.Controllers
{

    [Authorize]
    public class RechtController : BaseController
    {
        private IRechtViewModelService RechtViewModelService { get; set; }

        private IRechtService RechtService { get; set; }

        public RechtController(IRechtService rechtService, IRechtViewModelService rechtViewModelService)
        {
            RechtService = rechtService;
            RechtViewModelService = rechtViewModelService;
        }

        // GET: Rechts
        public ActionResult Index()
        {
            return View(RechtService.FindAllRights());
        }

        // GET: Rechts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsRechtViewModel rechtViewModel =
                RechtViewModelService.Map_Recht_DetailsRechtViewModel(RechtService.SearchRightById(Convert.ToInt32(id)));

            if (rechtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(rechtViewModel);
        }

        // GET: Rechts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rechts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRechtViewModel createRechtViewModel)
        {
            if (ModelState.IsValid)
            {
                RechtService.AddRecht(RechtViewModelService.Map_CreateRechtViewModel_Recht(createRechtViewModel));
                return RedirectToAction("Index");
            }

            return View(createRechtViewModel);
        }

        // GET: Rechts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditRechtViewModel editRechtViewModel =
               RechtViewModelService.Map_Recht_EditRechtViewModel(RechtService.SearchRightById(Convert.ToInt32(id)));

            if (editRechtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editRechtViewModel);
        }

        // POST: Rechts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRechtViewModel editRechtViewModel)
        {
            if (ModelState.IsValid)
            {
                RechtService.EditRecht(RechtViewModelService.Map_EditRechtViewModel_Recht(editRechtViewModel));
                return RedirectToAction("Index");
            }
            return View(editRechtViewModel);
        }

        // GET: Rechts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteRechtViewModel deleteRechtViewModel =
                RechtViewModelService.Map_Recht_DeleteRechtViewModel(RechtService.SearchRightById(Convert.ToInt32(id)));

            if (deleteRechtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteRechtViewModel);
        }

        // POST: Rechts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RechtService.RemoveRecht(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }
        
    }
}
