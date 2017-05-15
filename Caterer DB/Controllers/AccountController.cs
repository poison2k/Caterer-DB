using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using System;
using System.Web.Mvc;
using Caterer_DB.MVCServices;
using Common.Resources;

namespace Caterer_DB.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public ILoginService LoginService { get; set; }
        public IBenutzerService BenutzerService { get; set; }
        public IBenutzerViewModelService BenutzerViewModelService { get; set; }

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

            return View(BenutzerViewModelService.CreateNewRegisterBenutzerViewModel());
        }

        // GET: /Account/RegisterSuccsessfull
        [AllowAnonymous]
        public ActionResult RegisterSuccsessfull(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // GET: /Account/RegisterComplete
        [AllowAnonymous]
        public ActionResult RegisterComplete(string id, string verify)
        {
            if (BenutzerService.VerifyRegistration(id, verify))
            {
                return View();
            };
            return View("~/Views/Shared/Error.cshtml");
        }

        // GET: /Account/PasswordRequest
        [AllowAnonymous]
        public ActionResult PasswordRequest(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // GET: /Account/PasswordChange
        [AllowAnonymous]
        public ActionResult PasswordChange(string id, string verify)
        {
            if (BenutzerService.VerifyPasswordChange(id, verify) || (User != null && id.Contains(User.BenutzerId.ToString())))
            {
                return View(BenutzerViewModelService.Get_ForgottenPasswordCreateNewPasswordViewModel_ByBenutzerId(Convert.ToInt32(id)));
            };
            return View("~/Views/Shared/Error.cshtml");
        }

        // GET: /Account/PasswordRequestComplete
        [AllowAnonymous]
        public ActionResult PasswordRequestComplete()
        {
            return View();
        }

        // GET: /Account/PasswordChangeComplete
        [AllowAnonymous]
        public ActionResult PasswordChangeComplete()
        {
            return View();
        }

        // GET: /Account/RegisterMailVerificationNotComplete
        [AllowAnonymous]
        public ActionResult RegisterMailVerificationNotComplete()
        {
            return View();
        }

        // Post: /Account/PasswordRequest
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordRequest(ForgottenPasswordRequestViewModel forgottenPasswordRequestViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!BenutzerService.CheckEmailForRegistration(forgottenPasswordRequestViewModel.Mail))
                {
                    BenutzerService.ForgottenPasswordEmailForBenutzer(forgottenPasswordRequestViewModel.Mail);
                    return View("PasswordRequestComplete");
                }
                else
                {
                    return View("PasswordRequestComplete");
                }
            }
            return View();
        }

        // Post: /Account/PasswordChange
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordChange(ForgottenPasswordCreateNewPasswordViewModel forgottenPasswordCreateNewPasswordViewModel, string id, string verify)
        {
            if (BenutzerService.VerifyPasswordChange(id, verify))
            {
                if (ModelState.IsValid)
                {
                    var benutzer = BenutzerViewModelService.Map_ForgottenPasswordCreateNewPasswordViewModel_Benutzer(forgottenPasswordCreateNewPasswordViewModel);
                    BenutzerService.EditBenutzerPassword(benutzer);
                    return RedirectToAction("PasswordChangeComplete");
                }
                return View();
            }
            if (User != null)
            {
                if (User.BenutzerId.ToString() == id)
                {
                    if (ModelState.IsValid)
                    {
                        var benutzer = BenutzerViewModelService.Map_ForgottenPasswordCreateNewPasswordViewModel_Benutzer(forgottenPasswordCreateNewPasswordViewModel);
                        BenutzerService.EditBenutzerPassword(benutzer);
                        TempData["isPasswordChanged"] = true;
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    return View();
                }
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        // POST: Benutzer/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterBenutzerViewModel registerBenutzerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (BenutzerService.CheckEmailForRegistration(registerBenutzerViewModel.Mail))
                {
                    try
                    {
                        BenutzerService.RegisterBenutzer(BenutzerViewModelService.Map_RegisterBenutzerViewModel_Benutzer(registerBenutzerViewModel));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(BenutzerViewModelService.AddListsToRegisterViewModel(registerBenutzerViewModel));
                    }
                }
                else
                {
                    ModelState.AddModelError("", LoginResources.EMailVorhanden);
                    return View(BenutzerViewModelService.AddListsToRegisterViewModel(registerBenutzerViewModel));
                }
                return RedirectToAction("RegisterSuccsessfull");
            }

            return View(BenutzerViewModelService.AddListsToRegisterViewModel(registerBenutzerViewModel));
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
                    if (!BenutzerService.SearchUserByEmail(model.Email).IstEmailVerifiziert)
                    {
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
            return RedirectToAction("Index", "Home");
        }
    }
}