using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ILoginRepository
    {
        bool IstNutzerInDatenbankVorhanden(string kurzname);

        List<Recht> RechteFürGruppe(RechteGruppe rechteGruppe);

        void Speichern(Benutzer benutzer);

        Benutzer LadeNutzerMitEmail(string kurzname);

        List<BenutzerGruppe> GruppenFürBenutzer(int benutzerId);

        RechteGruppe RechteVerwaltungsGruppeFürNutzergruppe(BenutzerGruppe benutzerGruppe);
    }
}