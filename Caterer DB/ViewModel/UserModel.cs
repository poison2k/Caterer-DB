using Caterer_DB.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Common.Services;

namespace Caterer_DB.Models
{
    public class UserModel : IPrincipal
    {
        public UserModel(string kurzname, int benutzerId, ILoginService anmeldeService)
        {
            BenutzerId = benutzerId;
            Identity = new GenericIdentity(kurzname);
            Rechte = anmeldeService.ladeRechte(BenutzerId);
            Rollen = anmeldeService.ladeRollen(BenutzerId);
            NutzergruppenIds = anmeldeService.ladeNutzergruppenIds(BenutzerId);
        }

        public int BenutzerId { get; set; }

        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Email { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        [MyRequired]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Passwort { get; set; }

        public IIdentity Identity { get; private set; }

        public List<string> Rechte { get; set; }

        public List<string> Rollen { get; set; }

        public List<int> NutzergruppenIds { get; set; }

        public bool IsInRole(string recht)
        {
            return Rechte.Contains(recht);
        }

        public bool HatDasRecht(string recht)
        {
            Boolean t = false;
            String teilrecht = "";
            if (recht.Contains(","))
            {
                foreach (string r in recht.Split(','))
                {
                    t = HatDasRecht(r.TrimStart(' '));
                    if (t)
                    {
                        teilrecht = r;
                        break;
                    }
                }
            }
            if (t)
                return Rechte.Contains(teilrecht);
            return Rechte.Contains(recht);
        }

        public bool HatDieRolle(string rolle)
        {
            Boolean t = false;
            String teilrecht = "";
            if (rolle.Contains(","))
            {
                foreach (string r in rolle.Split(','))
                {
                    t = HatDieRolle(r.TrimStart(' '));
                    if (t)
                    {
                        teilrecht = r;
                        break;
                    }
                }
            }
            if (t)
                return Rollen.Contains(teilrecht);
            return Rollen.Contains(rolle);
        }

        public bool HatNichtDasRecht(string recht)
        {
            return !HatDasRecht(recht);
        }

        public bool IstInGruppe(int nutzergruppeId)
        {
            return NutzergruppenIds.Contains(nutzergruppeId);
        }

        public List<int> IstInGruppen()
        {
            return NutzergruppenIds;
        }
    }

    public class LoginModel
    {
        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Email { get; set; }

        [MyRequired]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Passwort { get; set; }
    }

    public class CookieSerializeModel
    {
        public int BenutzerId { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public string Email { get; set; }

        public List<int> NutzergruppenIds { get; set; }
    }
}