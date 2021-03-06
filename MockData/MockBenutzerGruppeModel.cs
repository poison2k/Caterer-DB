﻿using Common.Model;
using Common.Resources;
using System.Collections.Generic;

namespace MockData
{
    public static class MockBenutzerGruppeModel
    {
        public static BenutzerGruppe AdminBenutzerGruppe()
        {
            return new BenutzerGruppe
            {
                NutzerGruppeID = 1,
                Bezeichnung = BenutzerGruppenResource.Administrator,
                RechteGruppe = MockRechteGruppeModel.AdminRechteGruppe()
            };
        }

        public static BenutzerGruppe MitarbeiterBenutzerGruppe()
        {
            return new BenutzerGruppe
            {
                NutzerGruppeID = 2,
                Bezeichnung = BenutzerGruppenResource.Administrator,
                RechteGruppe = MockRechteGruppeModel.MitarbeiterRechteGruppe()
            };
        }

        public static BenutzerGruppe CatererBenutzerGruppe()
        {
            return new BenutzerGruppe
            {
                NutzerGruppeID = 3,
                Bezeichnung = BenutzerGruppenResource.Administrator,
                RechteGruppe = MockRechteGruppeModel.CatererRechteGruppe()
            };
        }

        public static List<BenutzerGruppe> ListeBenutzerGruppe()
        {
            return new List<BenutzerGruppe>() { AdminBenutzerGruppe(), MitarbeiterBenutzerGruppe(), CatererBenutzerGruppe() };
        }
    }
}