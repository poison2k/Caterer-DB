using Caterer_DB.Resources;
using System.Collections.Generic;
using Common.Model;

namespace MockData
{
    public static class MockRechtModel
    {
        public static List<Recht> ListeVonRechten()
        {
            return new List<Recht>()
            {
                new Recht() { RechtId = 5,Bezeichnung = RechteResource.CreateMitarbeiter, Beschreibung = "Mitarbeiter können angelegt werden" },
                new Recht() { RechtId = 6,Bezeichnung = RechteResource.IndexMitarbeiter, Beschreibung = "Anzeige aller Mitarbeiter" },
                new Recht() { RechtId = 7,Bezeichnung = RechteResource.EditMitarbeiter, Beschreibung = "Bearbeiten aller Mitarbeiter" },
                new Recht() { RechtId = 8, Bezeichnung = RechteResource.DeleteMitarbeiter, Beschreibung = "Löschen aller Mitarbeiter" },
                new Recht() { RechtId = 9,Bezeichnung = RechteResource.DetailsMitarbeiter, Beschreibung = "Mitarbeiter Details können gesehen werden" },

                new Recht() { RechtId = 10,Bezeichnung = RechteResource.CreateFrage, Beschreibung = "Frage können angelegt werden" },
                new Recht() { RechtId = 11,Bezeichnung = RechteResource.IndexFrage, Beschreibung = "Anzeige aller Frage" },
                new Recht() { RechtId = 12,Bezeichnung = RechteResource.EditFrage, Beschreibung = "Bearbeiten aller Frage" },
                new Recht() { RechtId = 13,Bezeichnung = RechteResource.DeleteFrage, Beschreibung = "Löschen aller Frage" },
                new Recht() { RechtId = 14,Bezeichnung = RechteResource.DetailsFrage, Beschreibung = "Frage Details können gesehen werden" },

                new Recht() { RechtId = 15,Bezeichnung = RechteResource.EditFrageBogen, Beschreibung = "Bearbeiten aller Fragebogen der Caterer" },
                new Recht() { RechtId = 16,Bezeichnung = RechteResource.DetailsFrageBogen, Beschreibung = "Bearbeiten des eigenen Fragebogen" },

                new Recht() { RechtId = 17,Bezeichnung = RechteResource.CreateCaterer, Beschreibung = "Caterer können angelegt werden" },
                new Recht() { RechtId = 18, Bezeichnung = RechteResource.IndexCaterer, Beschreibung = "Anzeige aller Caterer" },
                new Recht() { RechtId = 19,Bezeichnung = RechteResource.EditCaterer, Beschreibung = "Caterer können bearbeitet werden" },
                new Recht() { RechtId = 20,Bezeichnung = RechteResource.DeleteCaterer, Beschreibung = "Caterer können gelöscht werden" },
                new Recht() { RechtId = 21,Bezeichnung = RechteResource.DetailsCaterer, Beschreibung = "Caterer Details können gesehen werden" },
                new Recht() { RechtId = 22,Bezeichnung = RechteResource.MenueCaterer, Beschreibung = "Menü zur Bearbeitung und Anzeige von Caterern wird angezeigt" },

                new Recht() { RechtId = 23,Bezeichnung = RechteResource.MeineDatenMitarbeiter, Beschreibung = "Mitarbeiter kann seine Daten bearbeiten" },

                new Recht() { RechtId = 24,Bezeichnung = RechteResource.EditKategorie, Beschreibung = "Mitarbeiter kann Kategorien Bearbeiten" },
                new Recht() { RechtId = 25,Bezeichnung = RechteResource.DetailsKategorie, Beschreibung = "Mitarbeiter kann Kategorien Einsehen" },
                new Recht() { RechtId = 26,Bezeichnung = RechteResource.IndexKategorie, Beschreibung = "Mitarbeiter kann Kategorien Übersicht sehen"  },
                new Recht() { RechtId = 27,Bezeichnung = RechteResource.CreateKategorie, Beschreibung = "Mitarbeiter kann Kategorien anlegen"  },
                new Recht() { RechtId = 28,Bezeichnung = RechteResource.DeleteKategorie, Beschreibung = "Mitarbeiter kann Kategorien löschen"  }
            };

        }
        public static Recht EinRecht()
        {
            return new Recht() { RechtId = 1, Bezeichnung = "TestRecht", Beschreibung = "Testrecht" };
        }
    }
}
