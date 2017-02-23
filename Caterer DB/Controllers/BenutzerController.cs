using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using DataAccess.Model;
using System;
using System.Net;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    public class BenutzerController : BaseController
    {
        //private CatererContext db = new CatererContext();
        private IBenutzerViewModelService BenutzerViewModelService { get; set; }

        private IBenutzerService BenutzerService { get; set; }

        public ILoginService LoginService { get; set; }

        public BenutzerController(IBenutzerService benutzerService, IBenutzerViewModelService benutzerViewModelService, ILoginService loginService)
        {
            LoginService = loginService;
            BenutzerService = benutzerService;
            BenutzerViewModelService = benutzerViewModelService;

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


        // GET: Benutzer/Mydata/5
        public ActionResult MyData(int? id)
        {
            if (id == null || id != User.BenutzerId)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            MyDataBenutzerViewModel myDataBenutzerViewModel =
                BenutzerViewModelService.Map_Benutzer_MyDataBenutzerViewModel(BenutzerService.SearchUserById(Convert.ToInt32(id)));

            if (myDataBenutzerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(myDataBenutzerViewModel);
        }

        // POST: Benutzer/MyData/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyData(MyDataBenutzerViewModel myDataBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["btnSave"] != null)
                { 
                //Benutzer oldUser = BenutzerService.SearchUserByIdNoTracking(Convert.ToInt32(myDataBenutzerViewModel.BenutzerId));
                //Benutzer changedUser = BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel);
                //changedUser.Passwort = oldUser.Passwort;
                //changedUser.IstEmailVerifiziert = oldUser.IstEmailVerifiziert;
                
                BenutzerService.EditBenutzer(BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel));

                }
                else if(Request.Form["btnModalDelete"] != null)
                {
                    LoginService.Abmelden();
                    BenutzerService.RemoveBenutzer(BenutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel).BenutzerId);
                }
                return RedirectToAction("Index", "Home");

            }
            return View(BenutzerViewModelService.AddListsToMyDataViewModel(myDataBenutzerViewModel));
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