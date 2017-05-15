using Caterer_DB.Models;
using System.Collections.Generic;

namespace MockData
{
    public static class MockAccountViewModels
    {
        public static LoginModel EinLoginModel()
        {
            return new LoginModel()
            {
                Email = "Test@test.de",
                Passwort = "test"
            };
        }

        public static ForgottenPasswordCreateNewPasswordViewModel EinForgottenPasswordCreateNewPasswordViewModel()
        {
            return new ForgottenPasswordCreateNewPasswordViewModel()
            {
                BenutzerId = 1,
                Mail = "test@test.de",
                Passwort = "test",
                PasswortVerification = "test"
            };
        }

        public static RegisterBenutzerViewModel EinRegisterBenutzerViewModel()
        {
            return new RegisterBenutzerViewModel()
            {
                AGBs = true,
                Organisationsform = "RegisterBenutzerViewModel",
                Anrede = "Herr",
                Datenschutz = true,
                Fax = "test",
                Firmenname = "testfirma",
                FunktionAnsprechpartner = "test",
                Internetadresse = "",
                Lieferumkreis = 30,
                Mail = "test@test.de",
                Nachname = "test",
                Ort = "test",
                Passwort = "test",
                PasswortVerification = "test",
                Postleitzahl = "10111",
                Sonstiges = "",
                Bemerkung = "",
                Straße = "",
                Telefon = "",
                Vorname = "test",
                WeitergabeVonDaten = true
            };
        }

        public static AnmeldenBenutzerViewModel EinAnmeldenBenutzerViewModel()
        {
            return new AnmeldenBenutzerViewModel()
            {
                AnmeldenModel = EinLoginModel(),
                Anrede = "Frau",
                BenutzerGruppen = MockBenutzerGruppeModel.ListeBenutzerGruppe(),
                FehlerListe = new List<string>(),
                Infobox = "",
                Nachname = "Musterfrau",
                OffeneFragen = 7,
                Vorname = "Peter"
            };
        }
    }
}