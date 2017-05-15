using Common.Model;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace MockData
{
    public static class MockBenutzerModel
    {
        public static Benutzer EinCaterer()
        {
            return new Benutzer
            {
                BenutzerId = 1,
                Mail = "test@test.de",
                Passwort = "TestHash",
                Nachname = "Panzer",
                Vorname = "Paul",
                IstEmailVerifiziert = true,
                Firmenname = "City Grill Uelzen",
                Internetadresse = "citygrilluelzen.de",
                Lieferumkreis = 40,
                Organisationsform = "Caterer",
                Telefon = "05026/54682",
                Fax = "05026/54687",
                Straße = "Bahnhofsstraße 9",
                Postleitzahl = "29525 ",
                Ort = "Uelzen",
                Anrede = "Herr",
                FunktionAnsprechpartner = "Geschäftsführer",
                EMailVerificationCode = "TestHash",
                PasswordVerificationCode = "TestHash",
                _AntwortIDs = "4, 5, 9, 11, 18, 23, 25, 28",
                PasswortZeitstempel = System.DateTime.Now,
                LetzteÄnderung = System.DateTime.Now,
                Koordinaten = DbGeography.FromText("Point( 10.555055 52.966940 )"),
                BenutzerGruppen = new List<BenutzerGruppe>() { MockBenutzerGruppeModel.CatererBenutzerGruppe() }
            };
        }

        public static Benutzer EinMitarbeiter()
        {
            return new Benutzer
            {
                BenutzerId = 2,
                Mail = "mitarbeiter@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Musterfrau",
                Vorname = "Maxim",
                IstEmailVerifiziert = true,
                PasswortZeitstempel = System.DateTime.Now,
                LetzteÄnderung = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { MockBenutzerGruppeModel.MitarbeiterBenutzerGruppe() }
            };
        }

        public static Benutzer EinNichtVerifizierterBenutzer()
        {
            return new Benutzer
            {
                BenutzerId = 2,
                Mail = "mitarbeiter@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Musterfrau",
                Vorname = "Maxim",
                IstEmailVerifiziert = false,
                PasswortZeitstempel = System.DateTime.Now,
                LetzteÄnderung = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { MockBenutzerGruppeModel.MitarbeiterBenutzerGruppe() }
            };
        }

        public static Benutzer EinAdministrator()
        {
            return new Benutzer
            {
                BenutzerId = 3,
                Mail = "admin@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Müller",
                Vorname = "Alex",
                IstEmailVerifiziert = true,
                Anrede = "Herr",
                PasswortZeitstempel = System.DateTime.Now,
                LetzteÄnderung = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { MockBenutzerGruppeModel.AdminBenutzerGruppe() }
            };
        }

        public static List<Benutzer> CatererListe()
        {
            return new List<Benutzer>() { EinCaterer(), EinCaterer(), EinCaterer() };
        }

        public static List<Benutzer> MitarbeiterListe()
        {
            return new List<Benutzer>() { EinMitarbeiter(), EinAdministrator(), EinMitarbeiter() };
        }
    }
}