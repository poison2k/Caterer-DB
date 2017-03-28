using System;
using System.Net;
using System.Web.Mvc;
using Caterer_DB.Interfaces;
using Business.Interfaces;
using Caterer_DB.Models;
using System.Collections.Generic;

namespace Caterer_DB.Controllers
{
    public class KategorieController : BaseController
    {
        private IKategorieViewModelService KategorieViewModelService { get; set; }

        private IKategorieService KategorieService { get; set; }

        private IFrageService FrageService { get; set; }

        public KategorieController(IKategorieService kategorieService, IKategorieViewModelService kategorieViewModelService, IFrageService frageService)
        {
            KategorieService = kategorieService;
            FrageService = frageService;
            KategorieViewModelService = kategorieViewModelService;

        }

        // GET: Kategorie
        public ActionResult Index()
        {
            List<IndexKategorieViewModel> kategorieList = new List<IndexKategorieViewModel>();

            foreach (var kategorie in KategorieService.FindAlleKategorien())
            {
                kategorieList.Add(KategorieViewModelService.Map_Kategorie_IndexKategorieViewModel(kategorie,
                                               FrageService.FindFragenNachKategorieByKategorieId(Convert.ToInt32(kategorie.KategorieId))));
            }
            
            return View(kategorieList);
        }

        // GET: Kategorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsKategorieViewModel KategorieViewModel =
                KategorieViewModelService.Map_Kategorie_DetailsKategorieViewModel(KategorieService.SearchKategorieById(Convert.ToInt32(id)), FrageService.FindFragenNachKategorieByKategorieId(Convert.ToInt32(id)));

            if (KategorieViewModel == null)
            {
                return HttpNotFound();
            }
            return View(KategorieViewModel);
        }

        // GET: Kategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateKategorieViewModel createKategorieViewModel)
        {
            if (ModelState.IsValid)
            {
                KategorieService.AddKategorie(KategorieViewModelService.Map_CreateKategorieViewModel_Kategorie(createKategorieViewModel));
                return RedirectToAction("Index");
            }

            return View(createKategorieViewModel);
        }

        // GET: Kategorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditKategorieViewModel editKategorieViewModel =
               KategorieViewModelService.Map_Kategorie_EditKategorieViewModel(KategorieService.SearchKategorieById(Convert.ToInt32(id)), FrageService.FindFragenNachKategorieByKategorieId(Convert.ToInt32(id)));

            if (editKategorieViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editKategorieViewModel);
        }

        // POST: Kategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditKategorieViewModel editKategorieViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["btnModalDelete"] != null)
                {
                    KategorieService.RemoveKategorie(editKategorieViewModel.KategorieId);
                }
                else
                {
                    KategorieService.EditKategorie(KategorieViewModelService.Map_EditKategorieViewModel_Kategorie(editKategorieViewModel));
                }
                return RedirectToAction("Index");
            }
            return View(editKategorieViewModel);
        }

        // GET: Kategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeleteKategorieViewModel deleteKategorieViewModel =
                KategorieViewModelService.Map_Kategorie_DeleteKategorieViewModel(KategorieService.SearchKategorieById(Convert.ToInt32(id)));

            if (deleteKategorieViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteKategorieViewModel);
        }

        // POST: Kategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategorieService.RemoveKategorie(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }

    }
}
