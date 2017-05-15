using System.Collections.Generic;
using Common.Model;

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