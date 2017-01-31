using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBenutzerGruppeRepository
    {
        void AddGroup(BenutzerGruppe benutzerGruppe);
        void EditGroup(BenutzerGruppe benutzerGruppe);
        void RemoveGroup(BenutzerGruppe benutzerGruppe);

        BenutzerGruppe SearchGroupById(int id);
        BenutzerGruppe SearchGroupByBezeichnung(string bezeichnung);

        List<BenutzerGruppe> SearchGroup();
        List<BenutzerGruppe> SearchGroupByRechteGruppe(RechteGruppe rechteGruppe);
        List<BenutzerGruppe> SearchGroupByBenutzer(Benutzer benutzer);
    }
}
