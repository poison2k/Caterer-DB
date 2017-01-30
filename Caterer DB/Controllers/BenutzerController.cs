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
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using Business.Services;
using Business.Interfaces;

namespace Caterer_DB.Controllers
{
    public class BenutzerController : Controller
    {
        //private CatererContext db = new CatererContext();
        private BenutzerViewModelService BenutzerViewModelService = new BenutzerViewModelService();
        private IBenutzerService BenutzerService { get; set; }

        public BenutzerController(IBenutzerService benutzerService)
        {
            BenutzerService = benutzerService; 
        }

        // GET: Benutzer
        public ActionResult Index()
        {
            return View(BenutzerService.FindAllBenutzers());
        }

        // GET: Benutzer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsBenutzerViewModel detailsBenutzerViewModel =
                BenutzerViewModelService.MapBenutzer_DetailsBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (detailsBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(detailsBenutzerViewModel);
        }

        // GET: Benutzer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Benutzer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBenutzerViewModel createBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
                BenutzerService.AddBenutzer(BenutzerViewModelService.MapCreateBenutzerViewModel_Benutzer(createBenutzerViewModel));
                
                return RedirectToAction("Index");
            }

            return View(createBenutzerViewModel);
        }

        // GET: Benutzer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditBenutzerViewModel editBenutzerViewModel = 
                BenutzerViewModelService.MapBenutzer_EditBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));
            
            if (editBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editBenutzerViewModel);
        }

        // POST: Benutzer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBenutzerViewModel editBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
                BenutzerService.EditBenutzer(BenutzerViewModelService.MapEditBenutzerViewModel_Benutzer(editBenutzerViewModel));
               
                return RedirectToAction("Index");
            }
            return View(editBenutzerViewModel);
        }

        // GET: Benutzer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteBenutzerViewModel deleteBenutzerViewModel =
                BenutzerViewModelService.MapBenutzer_DeleteBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (deleteBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteBenutzerViewModel);
        }

        // POST: Benutzer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DeleteBenutzerViewModel deleteBenutzerViewModel)
        {
            BenutzerService.RemoveBenutzer(BenutzerViewModelService.MapDeleteBenutzerViewModel_Benutzer(deleteBenutzerViewModel));
            
            return RedirectToAction("Index");
        }

       
    }
}
