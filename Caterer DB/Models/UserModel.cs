using System;
using System.Collections.Generic;
using System.Security.Principal;
using Caterer_DB.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{
    public class UserModel : IPrincipal
    {

        public UserModel(string kurzname, int benutzerId, ILoginService anmeldeService)
        {
            BenutzerId = benutzerId;
            Identity = new GenericIdentity(kurzname);
            Rechte = anmeldeService.ladeRechte(BenutzerId);
            NutzergruppenIds = anmeldeService.ladeNutzergruppenIds(BenutzerId);
        }

        public int BenutzerId { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        [EmailAddress]
        public string Email { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Passwort { get; set; }

        public IIdentity Identity { get; private set; }

        public List<string> Rechte { get; set; }

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
        [Required]
        [Display(Name = "Nutzername : ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort : ")]
        public string Passwort { get; set; }
    }

    public class CookieSerializeModel
    {
        public int BenutzerId { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public string Email { get; set; }
    }
}
