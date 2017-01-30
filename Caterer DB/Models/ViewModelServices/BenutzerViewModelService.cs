using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models.ViewModelServices
{
    public class BenutzerViewModelService
    {


        public Benutzer MapCreateBenutzerViewModel_Benutzer(CreateBenutzerViewModel createBenutzerViewModel)
        {
            return new Benutzer()
            {
                Nachname = createBenutzerViewModel.Nachname,
                Vorname = createBenutzerViewModel.Vorname,
                Mail = createBenutzerViewModel.Mail,
                Strasse = createBenutzerViewModel.Strasse,
                Plz = createBenutzerViewModel.Plz,
                Telefon = createBenutzerViewModel.Telefon,
                Anrede = createBenutzerViewModel.Anrede,
                BenutzerGruppen = createBenutzerViewModel.BenutzerGruppen,
                Ort = createBenutzerViewModel.Ort

            };


        }

    }
}