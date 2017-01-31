using Business.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using System;
using System.Net;
using System.Web.Mvc;

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
                BenutzerViewModelService.Map_Benutzer_DetailsBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

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
                BenutzerService.AddBenutzer(BenutzerViewModelService.Map_CreateBenutzerViewModel_Benutzer(createBenutzerViewModel));

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
                BenutzerViewModelService.Map_Benutzer_EditBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

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
                BenutzerService.EditBenutzer(BenutzerViewModelService.Map_EditBenutzerViewModel_Benutzer(editBenutzerViewModel));

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
                BenutzerViewModelService.Map_Benutzer_DeleteBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (deleteBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deleteBenutzerViewModel);
        }

        // POST: Benutzer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            BenutzerService.RemoveBenutzer(Convert.ToInt32(id));

            return RedirectToAction("Index");
        }
    }
}