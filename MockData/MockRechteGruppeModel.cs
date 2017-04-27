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
                Bezeichnung = "AdminRechte",
                Rechte = MockRechtModel.ListeVonRechten()
            };


        }

        public static RechteGruppe CatererRecteGruppe()
        {

            return new RechteGruppe
            {
                Bezeichnung = "CatererRechte",
                Rechte = new List<Recht>()
            };

        }

        public static RechteGruppe MitarbeiterRechteGruppe()
        {
            return new RechteGruppe
            {
                Bezeichnung = "MitarbeiterRechte",
                Rechte = new List<Recht>()
            };

        }

    }
}
