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

        public Benutzer MapEditBenutzerViewModel_Benutzer(EditBenutzerViewModel editBenutzerViewModel)
        {
            return new Benutzer()
            {
                BenutzerId = editBenutzerViewModel.BenutzerId,
                Nachname = editBenutzerViewModel.Nachname,
                Vorname = editBenutzerViewModel.Vorname,
                Mail = editBenutzerViewModel.Mail,
                Strasse = editBenutzerViewModel.Strasse,
                Plz = editBenutzerViewModel.Plz,
                Telefon = editBenutzerViewModel.Telefon,
                Anrede = editBenutzerViewModel.Anrede,
                BenutzerGruppen = editBenutzerViewModel.BenutzerGruppen,
                Ort = editBenutzerViewModel.Ort

            };
        }

        public EditBenutzerViewModel MapBenutzer_EditBenutzerViewModel(Benutzer benutzer)
        {
            return new EditBenutzerViewModel()
            {
                BenutzerId = benutzer.BenutzerId,
                Nachname = benutzer.Nachname,
                Vorname = benutzer.Vorname,
                Mail = benutzer.Mail,
                Strasse = benutzer.Strasse,
                Plz = benutzer.Plz,
                Telefon = benutzer.Telefon,
                Anrede = benutzer.Anrede,
                BenutzerGruppen = benutzer.BenutzerGruppen,
                Ort = benutzer.Ort
            };
        }

        public DetailsBenutzerViewModel MapBenutzer_DetailsBenutzerViewModel(Benutzer benutzer)
        {
            return new DetailsBenutzerViewModel()
            {
                BenutzerId = benutzer.BenutzerId,
                Nachname = benutzer.Nachname,
                Vorname = benutzer.Vorname,
                Mail = benutzer.Mail,
                Strasse = benutzer.Strasse,
                Plz = benutzer.Plz,
                Telefon = benutzer.Telefon,
                Anrede = benutzer.Anrede,
                BenutzerGruppen = benutzer.BenutzerGruppen,
                Ort = benutzer.Ort
            };
        }

        public Benutzer MapDeleteBenutzerViewModel_Benutzer(DeleteBenutzerViewModel deleteBenutzerViewModel)
        {
            return new Benutzer()
            {
                BenutzerId = deleteBenutzerViewModel.BenutzerId,
                Nachname = deleteBenutzerViewModel.Nachname,
                Vorname = deleteBenutzerViewModel.Vorname,
                Mail = deleteBenutzerViewModel.Mail,
                Strasse = deleteBenutzerViewModel.Strasse,
                Plz = deleteBenutzerViewModel.Plz,
                Telefon = deleteBenutzerViewModel.Telefon,
                Anrede = deleteBenutzerViewModel.Anrede,
                BenutzerGruppen = deleteBenutzerViewModel.BenutzerGruppen,
                Ort = deleteBenutzerViewModel.Ort

            };
        }

        public DeleteBenutzerViewModel MapBenutzer_DeleteBenutzerViewModel(Benutzer benutzer)
        {
            return new DeleteBenutzerViewModel()
            {
                BenutzerId = benutzer.BenutzerId,
                Nachname = benutzer.Nachname,
                Vorname = benutzer.Vorname,
                Mail = benutzer.Mail,
                Strasse = benutzer.Strasse,
                Plz = benutzer.Plz,
                Telefon = benutzer.Telefon,
                Anrede = benutzer.Anrede,
                BenutzerGruppen = benutzer.BenutzerGruppen,
                Ort = benutzer.Ort
            };
        }

    }
}