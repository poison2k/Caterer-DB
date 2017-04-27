using Caterer_DB.Resources;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockData
{
    public static class MockRechtModel
    {
        public static List<Recht> ListeVonRechten() {
            return new List<Recht>()
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
            };

        }

    }
}
