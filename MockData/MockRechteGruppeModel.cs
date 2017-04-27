using Caterer_DB.Resources;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockData
{
    public static class MockRechteGruppeModel
    {
        public static RechteGruppe AdminRechteGruppe()
        {
            return new RechteGruppe
            {
                RechteVerwaltungsGruppeId = 1,
                Bezeichnung = "AdminRechte",
                Rechte = MockRechtModel.ListeVonRechten()
            };


        }

        public static RechteGruppe CatererRechteGruppe()
        {

            return new RechteGruppe
            {
                RechteVerwaltungsGruppeId = 2,
                Bezeichnung = "CatererRechte",
                Rechte = MockRechtModel.ListeVonRechten()
            };

        }

        public static RechteGruppe MitarbeiterRechteGruppe()
        {
            return new RechteGruppe
            {
                RechteVerwaltungsGruppeId = 3,
                Bezeichnung = "MitarbeiterRechte",
                Rechte = MockRechtModel.ListeVonRechten()
            };

        }

    }
}
