using DataAccess.Context;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using Caterer_DB.Resources;

namespace Caterer_DB.App_Start.ContextInitializer
{
    public class ExampleData
    {
        public static void CreateExampleData(CatererContext db)
        {
            CreateRechte(db);
            CreateRechteGruppenData(db);
            CreateBenutzerGruppenData(db);
            CreateUserData(db);
            CreateConfig(db);
        }

        private static void CreateRechte(CatererContext db)
        {

            db.Recht.AddRange(new List<Recht>()
            {
                new Recht() { Bezeichnung = RechteResource.TestBlock1, Beschreibung = "Zeigt Block 1 an " },
                new Recht() { Bezeichnung = RechteResource.TestBlock2, Beschreibung = "Zeigt Block 2 an " },
                new Recht() { Bezeichnung = RechteResource.TestBlock3, Beschreibung = "Zeigt Block 3 an " },
                new Recht() { Bezeichnung = RechteResource.EditConfig, Beschreibung = "Einstellungen können bearbeitet werden" },
                new Recht() { Bezeichnung = RechteResource.CreateMitarbeiter, Beschreibung = "Mitarbeiter können angelegt werden" },
                new Recht() { Bezeichnung = RechteResource.IndexMitarbeiter, Beschreibung = "Anzeige aller Mitarbeiter" },
                new Recht() { Bezeichnung = RechteResource.CreateCaterer, Beschreibung = "Caterer können angelegt werden" },
                new Recht() { Bezeichnung = RechteResource.IndexCaterer, Beschreibung = "Anzeige aller Caterer" },
                new Recht() { Bezeichnung = RechteResource.MenueCaterer, Beschreibung = "Menü zur Bearbeitung und Anzeige von Caterern wird angezeigt" }

            });
            db.SaveChanges();

        }


        private static void CreateConfig(CatererContext db)
        {

            Config config = db.Config.Add(new Config
            {
                UserNameForSMTPServer = "Hoersaal10@gmail.com",
                PasswortForSMTPServer = "HS10idgHSe!",
                SmtpPort = 25,
                SmtpServer = "smtp.gmail.com"
            });
            db.SaveChanges();

        }

        private static void CreateRechteGruppenData(CatererContext db)
        {
            RechteGruppe AdminRechte = db.RechteGruppe.Add(new RechteGruppe
            {
                Bezeichnung = "AdminRechte",
                Rechte = db.Recht.ToList()
            });


            RechteGruppe CatererRechte = db.RechteGruppe.Add(new RechteGruppe
            {
                Bezeichnung = "CatererRechte",
                Rechte = new List<Recht>() { db.Recht.Single(x => x.Bezeichnung == RechteResource.TestBlock3) }
            });

            RechteGruppe MitarbeiterRechte = db.RechteGruppe.Add(new RechteGruppe
            {
                Bezeichnung = "MitarbeiterRechte",
                Rechte = new List<Recht>() { db.Recht.Single(x => x.Bezeichnung == RechteResource.TestBlock2),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.MenueCaterer) }
            });

            db.SaveChanges();
        }


        private static void CreateBenutzerGruppenData(CatererContext db)
        {

            BenutzerGruppe Admin = db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = BenutzerGruppenResource.Administrator,
                RechteGruppe = db.RechteGruppe.Single(x => x.Bezeichnung == "AdminRechte")
            });

            BenutzerGruppe Mitarbeiter = db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = BenutzerGruppenResource.Mitarbeiter,
                RechteGruppe = db.RechteGruppe.Single(x => x.Bezeichnung == "MitarbeiterRechte")
            });

            BenutzerGruppe Caterer = db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = BenutzerGruppenResource.Caterer,
                RechteGruppe = db.RechteGruppe.Single(x => x.Bezeichnung == "CatererRechte")
            });

            db.SaveChanges();
        }


        private static void CreateUserData(CatererContext db)
        {
            Benutzer caterer = db.Benutzer.Add(new Benutzer
            {
                Mail = "caterer@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Mustermann",
                Vorname = "Max",
                IstEmailVerifiziert = true,
                Firmenname = "AllYouCanEat GmbH",
                Internetadresse = "www.AYCE.de",
                Lieferumkreis = "Bis 10 km",
                Organisationsform = "Caterer",
                Telefon = "01234 - 56789",
                Fax = "01234 - 99999",
                Straße = "Holzweg 1",
                Postleitzahl = "87654",
                Ort = "Woodway",
                Anrede = "Herr",
                FunktionAnsprechpartner = "Chef",
                EMailVerificationCode = "",
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }

            });

            Benutzer caterer1 = db.Benutzer.Add(new Benutzer
            {
                Mail = "caterer1@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Mustermann",
                Vorname = "Max",
                IstEmailVerifiziert = true,
                Firmenname = "AllYouCanEat GmbH",
                Internetadresse = "www.AYCE.de",
                Lieferumkreis = "Bis 10 km",
                Organisationsform = "Caterer",
                Telefon = "01234 - 56789",
                Fax = "01234 - 99999",
                Straße = "Holzweg 1",
                Postleitzahl = "87654",
                Ort = "Woodway",
                Anrede = "Herr",
                FunktionAnsprechpartner = "Chef",
                EMailVerificationCode = "",
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }

            });

            Benutzer mitarbeiter = db.Benutzer.Add(new Benutzer
            {
                Mail = "mitarbeiter@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Musterfrau",
                Vorname = "Maxim",
                IstEmailVerifiziert = true,
                Firmenname = "-",
                Internetadresse = "-",
                Lieferumkreis = "-",
                Organisationsform = "-",
                Telefon = "-",
                Fax = "-",
                Straße = "-",
                Postleitzahl = "-",
                Ort = "-",
                Anrede = "-",
                FunktionAnsprechpartner = "-",
                EMailVerificationCode = "-",
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Mitarbeiter) }
            });

            Benutzer admin = db.Benutzer.Add(new Benutzer
            {
                Mail = "admin@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Müller",
                Vorname = "Alex",
                IstEmailVerifiziert = true,
                Firmenname = "-",
                Internetadresse = "-",
                Lieferumkreis = "-",
                Organisationsform = "-",
                Telefon = "-",
                Fax = "-",
                Straße = "-",
                Postleitzahl = "-",
                Ort = "-",
                Anrede = "-",
                FunktionAnsprechpartner = "-",
                EMailVerificationCode = "-",
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Administrator) }
            });

            Benutzer testuser = db.Benutzer.Add(new Benutzer
            {
                Mail = "poison2k@gmail.com",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Bünck",
                Vorname = "Sebastian",
                IstEmailVerifiziert = true,
                Firmenname = "AllYouCanEat GmbH",
                Internetadresse = "www.AYCE.de",
                Lieferumkreis = "50km",
                Organisationsform = "Vorhanden",
                Telefon = "01234 - 56789",
                Fax = "01234 - 99999",
                Straße = "Holzweg 1",
                Postleitzahl = "87654",
                Ort = "Woodway",
                Anrede = "Herr",
                FunktionAnsprechpartner = "Chef",
                EMailVerificationCode = "",
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Administrator) }

            });

            db.SaveChanges();
        }
    }
}