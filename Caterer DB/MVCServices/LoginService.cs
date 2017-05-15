using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Caterer_DB.Interfaces;
using Caterer_DB.ViewModel;
using Common.Model;
using DataAccess.Interfaces;
using Newtonsoft.Json;

namespace Caterer_DB.MVCServices
{
    public class LoginService : ILoginService
    {
        public LoginService(ILoginRepository loginRepository)
        {
            LoginRepository = loginRepository;
        }

        public ILoginRepository LoginRepository { get; private set; }

        /// <returns>
        ///     1 = Login Erfolgreich; 2 = Nutzergruppen nicht vorhanden; 3 = Passwort falsch; 4 = Fehler beim lesen des Users
        ///     aus der Datenbank; 5 = Unbekannter Fehler
        /// </returns>
        public LoginSuccessLevel AnmeldePrüfung(string email, string passwort)
        {
            try
            {
                Benutzer user = LoginRepository.LadeNutzerMitEmail(email);
                if (!(Crypto.VerifyHashedPassword(user.Passwort, passwort)))
                {
                    return LoginSuccessLevel.PasswortFalsch;
                }

                ErstelleLoginCookie(user);

                return LoginSuccessLevel.Erfolgreich;
            }
            catch (ArgumentException e)
            {
                if (e.ParamName == "LDAPVerbindungBenutzer")
                    return LoginSuccessLevel.BenutzerNichtGefunden;
                if (e.ParamName == "LDAPVerbindungPasswort")
                    return LoginSuccessLevel.PasswortFalsch;
                if (e.ParamName == "DatenbankFehler")
                    return LoginSuccessLevel.DatenbankFehler;
            }
            catch (Exception)
            {
                return LoginSuccessLevel.Unbekannt;
            }
            return LoginSuccessLevel.Unbekannt;
        }

        public void Abmelden()
        {
            FormsAuthentication.SignOut();
        }

        private static void ErstelleLoginCookie(Benutzer user)
        {
            try
            {
                //var gruppen = user.Gruppen.Select(m => m.Bezeichnung).ToArray();

                var serializeModel = new CookieSerializeModel
                {
                    BenutzerId = user.BenutzerId,
                    Vorname = user.Vorname,
                    Nachname = user.Nachname,
                    Email = user.Mail,
                };

                string benutzerDaten = JsonConvert.SerializeObject(serializeModel);

                var authTicket = new FormsAuthenticationTicket
                    (1
                    , user.Mail
                    , DateTime.Now
                    , DateTime.Now.AddMinutes(30)
                    , false
                    , benutzerDaten);

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                HttpContext.Current.Response.Cookies.Add(faCookie);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> LadeRechte(int benutzerId)
        {
            var rechteGruppen = LoginRepository
                .GruppenFürBenutzer(benutzerId)
                .Select(nutzergruppe => nutzergruppe.RechteGruppe);

            List<string> rechteBezeichnungen = new List<string>();

            foreach (var rechtegrp in rechteGruppen)
                foreach (var recht in rechtegrp.Rechte)
                    rechteBezeichnungen.Add(recht.Bezeichnung);

            return rechteBezeichnungen;
        }

        public List<string> LadeRollen(int benutzerId)
        {
            var benutzerGruppen = LoginRepository
                .GruppenFürBenutzer(benutzerId)
                .Select(nutzergruppe => nutzergruppe);

            List<string> gruppenBezeichnungen = new List<string>();

            foreach (var benutzergrp in benutzerGruppen)
                gruppenBezeichnungen.Add(benutzergrp.Bezeichnung);

            return gruppenBezeichnungen;
        }

        public List<int> LadeNutzergruppenIds(int benutzerId)
        {
            return LoginRepository
                .GruppenFürBenutzer(benutzerId)
                .Select(nutzergruppe => nutzergruppe.NutzerGruppeID).ToList();
        }
    }

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }

        public string RolesConfigKey { get; set; }

        public string RightsConfigKey { get; set; }

        public string Rights { get; set; }

        protected virtual UserModel CurrentUser
        {
            get { return HttpContext.Current.User as UserModel; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                string authorizedUsers = ConfigurationManager.AppSettings[UsersConfigKey];
                string authorizedRoles = ConfigurationManager.AppSettings[RolesConfigKey];
          
                Users = String.IsNullOrEmpty(Users) ? authorizedUsers : Users;
                Roles = String.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;
                Rights = String.IsNullOrEmpty(Rights) ? authorizedRoles : Rights;

                if (!String.IsNullOrEmpty(Rights))
                    if (!CurrentUser.HatDasRecht(Rights))
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "ZugriffVerweigert" }));

                if (!String.IsNullOrEmpty(Roles))
                    if (!CurrentUser.HatDieRolle(Roles))
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "ZugriffVerweigert" }));

                if (!String.IsNullOrEmpty(Users))
                    if (!Users.Contains(CurrentUser.BenutzerId.ToString()))
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "ZugriffVerweigert" }));

                if (String.IsNullOrEmpty(Users) && String.IsNullOrEmpty(Rights) && String.IsNullOrEmpty(Roles))
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "ZugriffVerweigert" }));
            }
            else
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
        }
    }
}