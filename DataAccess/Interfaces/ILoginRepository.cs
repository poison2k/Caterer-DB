using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
   
        public interface ILoginRepository
        {
            bool IstNutzerInDatenbankVorhanden(string kurzname);

            List<Recht> RechteFürGruppe(RechteGruppe rechteGruppe);

            void Speichern(Benutzer benutzer);

            Benutzer LadeNutzerMitEmail(string kurzname);

            List<editBenutzerGruppeViewModel> GruppenFürBenutzer(int benutzerId);

            RechteGruppe RechteVerwaltungsGruppeFürNutzergruppe(editBenutzerGruppeViewModel benutzerGruppe);
        }
    
}
