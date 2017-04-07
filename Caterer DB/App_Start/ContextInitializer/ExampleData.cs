using Caterer_DB.Resources;
using DataAccess.Context;
using DataAccess.Model;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;

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
            CreateKategorie(db);
            CreateFragen(db);
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
                new Recht() { Bezeichnung = RechteResource.EditMitarbeiter, Beschreibung = "Bearbeiten aller Mitarbeiter" },
                new Recht() { Bezeichnung = RechteResource.DeleteMitarbeiter, Beschreibung = "Löschen aller Mitarbeiter" },
                new Recht() { Bezeichnung = RechteResource.DetailsMitarbeiter, Beschreibung = "Mitarbeiter Details können gesehen werden" },

                new Recht() { Bezeichnung = RechteResource.CreateFrage, Beschreibung = "Frage können angelegt werden" },
                new Recht() { Bezeichnung = RechteResource.IndexFrage, Beschreibung = "Anzeige aller Frage" },
                new Recht() { Bezeichnung = RechteResource.EditFrage, Beschreibung = "Bearbeiten aller Frage" },
                new Recht() { Bezeichnung = RechteResource.DeleteFrage, Beschreibung = "Löschen aller Frage" },
                new Recht() { Bezeichnung = RechteResource.DetailsFrage, Beschreibung = "Frage Details können gesehen werden" },

                new Recht() { Bezeichnung = RechteResource.EditFrageBogen, Beschreibung = "Bearbeiten aller Fragebogen der Caterer" },
                new Recht() { Bezeichnung = RechteResource.DetailsFrageBogen, Beschreibung = "Bearbeiten des eigenen Fragebogen" },

                new Recht() { Bezeichnung = RechteResource.CreateCaterer, Beschreibung = "Caterer können angelegt werden" },
                new Recht() { Bezeichnung = RechteResource.IndexCaterer, Beschreibung = "Anzeige aller Caterer" },
                new Recht() { Bezeichnung = RechteResource.EditCaterer, Beschreibung = "Caterer können bearbeitet werden" },
                new Recht() { Bezeichnung = RechteResource.DeleteCaterer, Beschreibung = "Caterer können gelöscht werden" },
                new Recht() { Bezeichnung = RechteResource.DetailsCaterer, Beschreibung = "Caterer Details können gesehen werden" },
                new Recht() { Bezeichnung = RechteResource.MenueCaterer, Beschreibung = "Menü zur Bearbeitung und Anzeige von Caterern wird angezeigt" },

                new Recht() { Bezeichnung = RechteResource.MeineDatenMitarbeiter, Beschreibung = "Mitarbeiter kann seine Daten bearbeiten" },

                new Recht() { Bezeichnung = RechteResource.EditKategorie, Beschreibung = "Mitarbeiter kann Kategorien Bearbeiten" },
                new Recht() { Bezeichnung = RechteResource.DetailsKategorie, Beschreibung = "Mitarbeiter kann Kategorien Einsehen" },
                new Recht() { Bezeichnung = RechteResource.IndexKategorie, Beschreibung = "Mitarbeiter kann Kategorien Übersicht sehen"  },
                new Recht() { Bezeichnung = RechteResource.CreateKategorie, Beschreibung = "Mitarbeiter kann Kategorien anlegen"  },
                new Recht() { Bezeichnung = RechteResource.DeleteKategorie, Beschreibung = "Mitarbeiter kann Kategorien löschen"  }
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
                Rechte = new List<Recht>() { db.Recht.Single(x => x.Bezeichnung == RechteResource.TestBlock3),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.EditFrageBogen)}
            });

            RechteGruppe MitarbeiterRechte = db.RechteGruppe.Add(new RechteGruppe
            {
                Bezeichnung = "MitarbeiterRechte",
                Rechte = new List<Recht>() { db.Recht.Single(x => x.Bezeichnung == RechteResource.TestBlock2),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.MenueCaterer),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.IndexCaterer),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.CreateCaterer),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.EditCaterer),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.DeleteCaterer),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.DetailsCaterer),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.IndexFrage),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.CreateFrage),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.EditFrage),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.DeleteFrage),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.DetailsFrage),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.EditFrageBogen),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.MeineDatenMitarbeiter),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.IndexKategorie),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.DeleteKategorie),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.CreateKategorie),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.DetailsKategorie),
                                             db.Recht.Single(x => x.Bezeichnung == RechteResource.EditKategorie)}
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
                Koordinaten = DbGeography.FromText("Point( 6.442804 51.180457 )"),
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

            Benutzer admin2 = db.Benutzer.Add(new Benutzer
            {
                Mail = "admin2@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Mustermann ",
                Vorname = "Maximus",
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

            for (int i = 0; i < 20; i++)
            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "mitarbeiter" + i + "@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Mitarbeiter" + i,
                    Vorname = "Vorname" + i,
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
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "-",
                    EMailVerificationCode = "-",
                    PasswortZeitstempel = System.DateTime.Now,
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Mitarbeiter) }
                });
            }

            { 
            db.Benutzer.Add(new Benutzer
            {
                Mail = "caterer1@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Caterer1",
                Vorname = "Test",
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
                Koordinaten = DbGeography.FromText("Point( 6.442804 51.180457 )"),
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
            });

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "citygrilluelzen@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Panzer",
                    Vorname = "Paul",
                    IstEmailVerifiziert = true,
                    Firmenname = "City Grill Uelzen",
                    Internetadresse = "citygrilluelzen.de",
                    Lieferumkreis = "Bis 40 km",
                    Organisationsform = "Caterer",
                    Telefon = "05026/54682",
                    Fax = "05026/54687",
                    Straße = "Bahnhofsstraße 9",
                    Postleitzahl = "29525 ",
                    Ort = "Uelzen",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Geschäftsführer",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "4, 5, 9, 11, 18, 23, 25, 28",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 10.555055 52.966940 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "ingosgrill@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Griller",
                    Vorname = "Ingo",
                    IstEmailVerifiziert = true,
                    Firmenname = "Ingos Grill",
                    Internetadresse = "ingosgrill.de",
                    Lieferumkreis = "Bis 10 km",
                    Organisationsform = "Caterer",
                    Telefon = "05264/456458",
                    Fax = "05264/4564555",
                    Straße = "Große Horststr. 48",
                    Postleitzahl = "29328",
                    Ort = "Faßberg",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Geschäftsführer",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "4, 5, 6, 9, 14, 15, 18, 23, 25, 27",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 10.170305 52.899754 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "11akuechehannover@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Mütterchen",
                    Vorname = "Erna",
                    IstEmailVerifiziert = true,
                    Firmenname = "11A-Küche mit Garten-Hannover",
                    Internetadresse = "11akuechehannover.de",
                    Lieferumkreis = "Bis 5 km",
                    Organisationsform = "Caterer",
                    Telefon = "0511/4564521",
                    Fax = "",
                    Straße = "Am Küchengarten 11A",
                    Postleitzahl = "30449",
                    Ort = "Hannover",
                    Anrede = "Frau",
                    FunktionAnsprechpartner = "Geschäftsführer",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "1, 6, 8, 11, 13, 17, 20, 28",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 9.713295 52.370499 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "daseihannover@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Henne",
                    Vorname = "Mareike",
                    IstEmailVerifiziert = true,
                    Firmenname = "Das EI Hannover",
                    Internetadresse = "daseihannover.de",
                    Lieferumkreis = "Bis 50 km",
                    Organisationsform = "Caterer",
                    Telefon = "0511/1234548",
                    Fax = "0511/12345481",
                    Straße = "Selmastraße 9",
                    Postleitzahl = "30451",
                    Ort = "Hannover",
                    Anrede = "Frau",
                    FunktionAnsprechpartner = "Geschäftsführer",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "3, 7, 9, 11, 14, 15, 16, 25, 29",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 9.711535 52.371030 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "vapianooldenburg@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Garciaz",
                    Vorname = "Stefano",
                    IstEmailVerifiziert = true,
                    Firmenname = "Vapiano Oldenburg",
                    Internetadresse = "vapianooldenburg.de",
                    Lieferumkreis = "Bis 30 km",
                    Organisationsform = "Caterer",
                    Telefon = "05644/564564",
                    Fax = "05644/564561",
                    Straße = "Kasinopl. 3",
                    Postleitzahl = "26122",
                    Ort = "Oldenburg",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Prokurist",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "3, 6, 7, 10, 11, 13, 16, 23, 28",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 8.213351 53.138222 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "pizzablitz@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Blitz",
                    Vorname = "Pizzaro",
                    IstEmailVerifiziert = true,
                    Firmenname = "Pizza Blitz Hoya",
                    Internetadresse = "pizzablitz.de",
                    Lieferumkreis = "Bis 10 km",
                    Organisationsform = "Caterer",
                    Telefon = "05022/146546",
                    Fax = "05022/146541",
                    Straße = "Bücker Str. 2",
                    Postleitzahl = "27318",
                    Ort = "Hoya",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Geschäftsführer",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "3, 6, 9, 14, 15, 17, 21, 23, 29",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 9.135246 52.804920 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "mensavereinsoltau@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Reynolds",
                    Vorname = "Malcom",
                    IstEmailVerifiziert = true,
                    Firmenname = "Mensaverein Soltau e.V.",
                    Internetadresse = "mensavereinsoltau.de",
                    Lieferumkreis = "Bis 5 km",
                    Organisationsform = "Mensaverein",
                    Telefon = "05356/46515",
                    Fax = "05356/46511",
                    Straße = "Claudiusstraße 19",
                    Postleitzahl = "29614",
                    Ort = "Soltau",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Vorstandsvorsitzender",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "2, 5, 6, 9, 12,16, 19, 22, 29",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 9.835967 52.975741 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "weiteweltgoslar@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Barbarossa",
                    Vorname = "Friedrich",
                    IstEmailVerifiziert = true,
                    Firmenname = "Weite Welt-Goslar",
                    Internetadresse = "weiteweltgoslar.de",
                    Lieferumkreis = "Bis 75 km",
                    Organisationsform = "Caterer",
                    Telefon = "05979/4655",
                    Fax = "05979/4651",
                    Straße = "Hoher Weg 11",
                    Postleitzahl = "38640",
                    Ort = "Goslar",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Kaiser",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "4, 6, 7, 10, 15, 18, 22, 23, 28",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 10.427396 51.903510 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "derbuttjever@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Flunder",
                    Vorname = "Ole",
                    IstEmailVerifiziert = true,
                    Firmenname = "Der Butt - Jever",
                    Internetadresse = "derbuttjever.de",
                    Lieferumkreis = "100 km +",
                    Organisationsform = "Caterer",
                    Telefon = "06544/4685",
                    Fax = "",
                    Straße = "Kattrepel 2",
                    Postleitzahl = "26441",
                    Ort = "Jever",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Geschäftsführer",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "1, 5, 8, 11, 17, 21, 23, 28",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 7.903658 53.574694 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "mensavereinbraunschweig@test,de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Lieberknecht",
                    Vorname = "Torsten",
                    IstEmailVerifiziert = true,
                    Firmenname = "Mensaverein der IGS Querum in Braunschweig e. V.",
                    Internetadresse = "mensavereinbraunschweig.de",
                    Lieferumkreis = "Bis 5 km",
                    Organisationsform = "Mensaverein",
                    Telefon = "05666/16545",
                    Fax = "05666/16541",
                    Straße = "Essener Str. 85",
                    Postleitzahl = "38108",
                    Ort = "Braunschweig",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Vorstandsvorsitzender",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "2, 5, 6, 9, 11, 17, 18, 21, 23, 24, 27",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 10.560487 52.290498 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "dorospartyservice@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Schmitz",
                    Vorname = "Dorothea",
                    IstEmailVerifiziert = true,
                    Firmenname = "Dorotheas Party Service",
                    Internetadresse = "dorospartyservice.de",
                    Lieferumkreis = "Bis 20 km",
                    Organisationsform = "Caterer",
                    Telefon = "05233/14654",
                    Fax = "",
                    Straße = "Zum Alten Bad 23",
                    Postleitzahl = "29227",
                    Ort = "Celle",
                    Anrede = "Frau",
                    FunktionAnsprechpartner = "Geschäftsführer",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "2, 5, 6, 10, 11, 12, 17, 18, 21, 24, 28",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 10.083429 52.602581 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            {
                db.Benutzer.Add(new Benutzer
                {
                    Mail = "gloecklgastronomie@test.de",
                    Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                    Nachname = "Hansen",
                    Vorname = "Hendrick",
                    IstEmailVerifiziert = true,
                    Firmenname = "Glöckl Gastro Catering",
                    Internetadresse = "gloeckl-gastronomie.de",
                    Lieferumkreis = "Bis 30 km",
                    Organisationsform = "Caterer",
                    Telefon = "05244/14654",
                    Fax = "05244/14666",
                    Straße = " Reislinger Straße 20",
                    Postleitzahl = "38446",
                    Ort = "Wolfsburg",
                    Anrede = "Herr",
                    FunktionAnsprechpartner = "Geschäftsführer",
                    EMailVerificationCode = "-",
                    _AntwortIDs = "1, 5, 6, 8, 12, 17, 18, 21, 23, 24, 27",
                    PasswortZeitstempel = System.DateTime.Now,
                    Koordinaten = DbGeography.FromText("Point( 10.814477 52.428914 )"),
                    BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Caterer) }
                });
            }

            db.SaveChanges();
        }

        private static void CreateKategorie(CatererContext db)
        {
            db.Kategorie.Add(new Kategorie()
            {
                Bezeichnung = "Allgemeines"
            });
            db.Kategorie.Add(new Kategorie()
            {
                Bezeichnung = "Speiseplan"
            });
            db.Kategorie.Add(new Kategorie()
            {
                Bezeichnung = "Wahlmoeglichkeiten"
            });
            db.SaveChanges();
        }

        public static void CreateFragen(CatererContext db)
        {
            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Haben Sie Erfahrung mit der Lieferung von Mahlzeiten an Schulen/Kitas? Liegen Referenzen vor?",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "keine Angabe..."},
                    new Antwort() {Bezeichnung = "Ja mit Refernezen"},
                    new Antwort() {Bezeichnung = "Ja ohne Refernzen"},
                    new Antwort() {Bezeichnung = "Nein"},
                },
                IstVeröffentlicht = true,
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Allgemeines"),
                IstMultiSelect = false
            });

            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Nach welchem Produktionssystem können Sie ihre Waren anbieten?",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Cook & Serve"},
                    new Antwort() {Bezeichnung = "Cook & Hold"},
                    new Antwort() {Bezeichnung = "Cook & Chill"},

                },
                IstVeröffentlicht = true,
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Allgemeines"),
                IstMultiSelect = true
            });
            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Bleiben die Warmheltezeiten ihrer Speisen unter 3 Stunden?",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "keine Angabe..."},
                    new Antwort() {Bezeichnung = "Ja"},
                    new Antwort() {Bezeichnung = "Nein"}
                },
                IstVeröffentlicht = true,
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Allgemeines"),
                IstMultiSelect = false
            });
            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Welche Mahlzeiten bieten Sie an?",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Mittagsverpflegung"},
                    new Antwort() {Bezeichnung = "Pausenverpflegung (Kiosk, Bistro, Frühstücksservice)"},
                    new Antwort() {Bezeichnung = "Zwischenverpflegung am Nachmittag"},
                    new Antwort() {Bezeichnung = "Automatenverpflegung"},
                    new Antwort() {Bezeichnung = "Getränkeservice"}

                },
                IstVeröffentlicht = true,
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Speiseplan"),
                IstMultiSelect = true
            });
            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Orientieren Sie sich an ernährungswissenschaftlichen Empfehlungen?",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "DGE-Qualitätsstandard für Kita- oder Schulverpflegung"},
                    new Antwort() {Bezeichnung = "optimix - Forschungsinstitut für Kinderernährung"},
                    new Antwort() {Bezeichnung = "Bremer Checkliste"}
                },
                IstVeröffentlicht = true,
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Speiseplan"),
                IstMultiSelect = true
            });

            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Besitzen Sie eine der folgenden Zertifizierungen?",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Deutsche Gesellschaft für Ernährung e.V."},
                    new Antwort() {Bezeichnung = "TÜV Reinland / Hochschule Niederrhein"},
                    new Antwort() {Bezeichnung = "Forschungsinstitut für Kinderernährung"},
                    new Antwort() {Bezeichnung = "Technische Universität Dortmund"},
                    new Antwort() {Bezeichnung = "DIN EN ISO"},
                    new Antwort() {Bezeichnung = "IFS oder BRC"},
                    new Antwort() {Bezeichnung = "EU Öko-VO"},
                    new Antwort() {Bezeichnung = "Technische Universität Dortmund"}

                },
                IstVeröffentlicht = true,
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Speiseplan"),
                IstMultiSelect = true
            });

            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Ist ein Onlinebestellsystem vorhanden?",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "keine Angabe..."},
                    new Antwort() {Bezeichnung = "Ja"},
                    new Antwort() {Bezeichnung = "Nein"},
                },
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Speiseplan"),
                IstVeröffentlicht = true
            });
            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Fragetext zu Frage 8",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Antworttext1 zu Frage 8"},
                    new Antwort() {Bezeichnung = "Antworttext2 zu Frage 8"},
                    new Antwort() {Bezeichnung = "Antworttext3 zu Frage 8"},
                    new Antwort() {Bezeichnung = "Antworttext4 zu Frage 8"}
                },
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Speiseplan"),
            });
            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Fragetext zu Frage 9",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Antworttext1 zu Frage 9"},
                    new Antwort() {Bezeichnung = "Antworttext2 zu Frage 9"},
                    new Antwort() {Bezeichnung = "Antworttext3 zu Frage 9"},
                    new Antwort() {Bezeichnung = "Antworttext4 zu Frage 9"}
                },
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Speiseplan")
            });
            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Fragetext zu Frage 10",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Antworttext1 zu Frage 10"},
                    new Antwort() {Bezeichnung = "Antworttext2 zu Frage 10"},
                    new Antwort() {Bezeichnung = "Antworttext3 zu Frage 10"},
                    new Antwort() {Bezeichnung = "Antworttext4 zu Frage 10"}
                },
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Wahlmoeglichkeiten"),
                IstVeröffentlicht = true
            });

            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Fragetext zu Frage 11",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Antworttext1 zu Frage 11"},
                    new Antwort() {Bezeichnung = "Antworttext2 zu Frage 11"},
                    new Antwort() {Bezeichnung = "Antworttext3 zu Frage 11"}
                },
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Wahlmoeglichkeiten"),
                IstVeröffentlicht = true
            });

            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Fragetext zu Frage 12",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Antworttext1 zu Frage 12"},
                    new Antwort() {Bezeichnung = "Antworttext2 zu Frage 12"},
                    new Antwort() {Bezeichnung = "Antworttext3 zu Frage 12"}
                },
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Wahlmoeglichkeiten"),
                IstVeröffentlicht = true
            });

            db.Frage.Add(new Frage()
            {
                Bezeichnung = "Fragetext zu Frage 13",
                Antworten = new List<Antwort>() {
                    new Antwort() {Bezeichnung = "Antworttext1 zu Frage 13"},
                    new Antwort() {Bezeichnung = "Antworttext2 zu Frage 13"},
                    new Antwort() {Bezeichnung = "Antworttext3 zu Frage 13"}
                },
                Kategorie = db.Kategorie.Single(x => x.Bezeichnung == "Wahlmoeglichkeiten"),
                IstVeröffentlicht = true
            });
        }
    }
}