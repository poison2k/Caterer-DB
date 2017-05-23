using System.Collections.Generic;
using System.Linq;
using Common.Model;
using Common.Resources;
using DataAccess.Context;

namespace Caterer_DB.ContextInitializer
{
    public class StartData
    {
        public static void CreateStartData(CatererContext db)
        {
            CreateRechte(db);
            CreateRechteGruppen(db);
            CreateBenutzerGruppen(db);
            CreateUser(db);
            CreateConfig(db);
            CreateKategorie(db);
         
        }


        private static void CreateRechte(CatererContext db)
        {
            db.Recht.AddRange(new List<Recht>()
            {
                new Recht() { Bezeichnung = RechteResource.TestBlock1, Beschreibung = "Zeigt Block 1 an " },
                new Recht() { Bezeichnung = RechteResource.TestBlock2, Beschreibung = "Zeigt Block 2 an " },
                new Recht() { Bezeichnung = RechteResource.TestBlock3, Beschreibung = "Zeigt Block 3 an " },
                new Recht() { Bezeichnung = RechteResource.EditConfig, Beschreibung = "Einstellungen können bearbeitet werden" },

                new Recht() { Bezeichnung = RechteResource.GlimpseUsing, Beschreibung = "Glimpsekann genutzt werden" },

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
                new Recht() { Bezeichnung = RechteResource.VergleichCaterer, Beschreibung = "Mitarbeiter kann Caterer Vergleichen" },

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
            db.Config.Add(new Config
            {
                UserNameForSMTPServer = "info@caterer-schulverpflegung-niedersachsen.de",
                PasswortForSMTPServer = "Start#22!2",
                SmtpPort = 587,
                SmtpServer = "smtp.1und1.de",
                ZeitInStundendÄnderungsverfolgung = 8,
                AenderungsVerfolgungCatererAktiviert = false,
                URLWebseite = "https://caterer-schulverpflegung-niedersachsen.de"
            });
            db.SaveChanges();
        }

        private static void CreateRechteGruppen(CatererContext db)
        {
            db.RechteGruppe.Add(new RechteGruppe
            {
                Bezeichnung = "AdminRechte",
                Rechte = db.Recht.ToList()
            });

            db.RechteGruppe.Add(new RechteGruppe
            {
                Bezeichnung = "CatererRechte",
                Rechte = new List<Recht>() { db.Recht.Single(x => x.Bezeichnung == RechteResource.TestBlock3),
                    db.Recht.Single(x => x.Bezeichnung == RechteResource.EditFrageBogen)}
            });

            db.RechteGruppe.Add(new RechteGruppe
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
                    db.Recht.Single(x => x.Bezeichnung == RechteResource.VergleichCaterer),
                    db.Recht.Single(x => x.Bezeichnung == RechteResource.EditKategorie)}
            });

            db.SaveChanges();
        }


        private static void CreateBenutzerGruppen(CatererContext db)
        {
            db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = BenutzerGruppenResource.Administrator,
                RechteGruppe = db.RechteGruppe.Single(x => x.Bezeichnung == "AdminRechte")
            });

            db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = BenutzerGruppenResource.Mitarbeiter,
                RechteGruppe = db.RechteGruppe.Single(x => x.Bezeichnung == "MitarbeiterRechte")
            });

            db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = BenutzerGruppenResource.Caterer,
                RechteGruppe = db.RechteGruppe.Single(x => x.Bezeichnung == "CatererRechte")
            });

            db.SaveChanges();
        }

        private static void CreateUser(CatererContext db)
        {
           db.Benutzer.Add(new Benutzer
            {
                Mail = "Superadmin@caterer-schulverpflegung-niedersachsen.de",
                Passwort = "AH8g+3XwpJpvLRG+oezcBQVHAWOnndkfSYkDObsNQsgxPAwUQ6sMJuiitmVJTFldUQ==",
                Nachname = "Chuck",
                Vorname = "Norris",
                FunktionAnsprechpartner = "Superadmin",
                IstEmailVerifiziert = true,
                PasswortZeitstempel = System.DateTime.Now,
                LetzteÄnderung = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == BenutzerGruppenResource.Administrator) }
            });

            db.SaveChanges();
        }

        private static void CreateKategorie(CatererContext db)
        {
            db.Kategorie.Add(new Kategorie()
            {
                Bezeichnung = "Beispielkategorie"
            });
          
            db.SaveChanges();
        }

    }
}