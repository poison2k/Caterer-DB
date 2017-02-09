using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Resources;
using Caterer_DB.Services;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public ILoginService LoginService { get; set; }
        public IBenutzerService BenutzerService { get; set; }
        public IBenutzerViewModelService BenutzerViewModelService { get; set;}

        public AccountController(ILoginService loginService, IBenutzerService benutzerService, IBenutzerViewModelService benutzerViewModelService)
        {
            LoginService = loginService;
            BenutzerService = benutzerService;
            BenutzerViewModelService = benutzerViewModelService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var registerBenutzerViewModel = new RegisterBenutzerViewModel();

           registerBenutzerViewModel.Anreden = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Herr", Value = "Herr" },
                                new SelectListItem { Text = "Frau", Value = "Frau" }
                            }, "Value", "Text");

            registerBenutzerViewModel.Lieferumkreise = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Nur im eigenen Stadtgebiet", Value = "Nur im eigenen Stadtgebiet" },
                                new SelectListItem { Text = "Bis 30 km", Value = "Bis 30 km" },
                                new SelectListItem { Text = "Bis 50 km", Value = "Bis 50 km" },
                                new SelectListItem { Text = "Bis 50 - 100 km", Value = "Bis 50 - 100 km" },
                                new SelectListItem { Text = "Deutschlandweit", Value = "Deutschlandweit" },
                                new SelectListItem { Text = "Sonstiges", Value = "Sonstiges" },
                            }, "Value", "Text");




            registerBenutzerViewModel.Organisationsformen = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Mensaverein", Value = "Mensaverein" },
                                new SelectListItem { Text = "Caterer", Value = "Caterer" },
                                new SelectListItem { Text = "Sonstiges", Value = "Sonstiges" }
                            }, "Value", "Text");

            return View(registerBenutzerViewModel);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterSuccsessfull(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterComplete(string id ,string verify)
        {
            if (BenutzerService.VerifyRegistration(id, verify)) {
                return View();
            };
            return View("~/Views/Shared/Error.cshtml");
        }


        [AllowAnonymous]
        public ActionResult RegisterMailVerificationNotComplete()
        {
            
            
                return View();
           
            
        }


        // POST: Benutzer/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterBenutzerViewModel registerBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
                
                if ( BenutzerService.CheckEmailForRegistration( registerBenutzerViewModel.Mail))
                {
                    BenutzerService.RegisterBenutzer(BenutzerViewModelService.Map_RegisterBenutzerViewModel_Benutzer(registerBenutzerViewModel));
                }
                else {
                    ModelState.AddModelError("", LoginResources.EMailVorhanden);
                    return View(registerBenutzerViewModel);
                }
                return View("RegisterSuccsessfull");
            }

            return View(registerBenutzerViewModel);
        }


        //
        // POST: /Anmelde/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[RequireHttps]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                LoginSuccessLevel anmeldeErfolg = LoginService.AnmeldePrüfung(model.Email, model.Passwort);
                if (anmeldeErfolg == LoginSuccessLevel.Erfolgreich)
                {
                    if (!BenutzerService.SearchUserByEmail(model.Email).IstEmailVerifiziert) {
                        LoginService.Abmelden();
                        return RedirectToAction("RegisterMailVerificationNotComplete");
                    }
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                if (anmeldeErfolg == LoginSuccessLevel.BenutzerNichtGefunden)
                {
                    ModelState.AddModelError("", LoginResources.BenutzerBeschreibung);
                }
                if (anmeldeErfolg == LoginSuccessLevel.PasswortFalsch)
                {
                    ModelState.AddModelError("", LoginResources.PasswortBeschreibung);
                }
                if (anmeldeErfolg == LoginSuccessLevel.DatenbankFehler)
                {
                    ModelState.AddModelError("", LoginResources.DatenbankBeschreibung);
                }
                if (anmeldeErfolg == LoginSuccessLevel.Unbekannt)
                {
                    ModelState.AddModelError("", LoginResources.UnbekannterBeschreibung);
                }
            }

            return View(model);
        }

        // POST: /Account/Abmelden
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            LoginService.Abmelden();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}