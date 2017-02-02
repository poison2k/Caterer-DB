﻿using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Resources;
using Caterer_DB.Services;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public ILoginService LoginService { get; set; }

        public AccountController(ILoginService loginService)
        {
            LoginService = loginService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
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