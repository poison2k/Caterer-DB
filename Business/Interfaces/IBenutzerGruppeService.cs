using System.Collections.Generic;
using Common.Model;

namespace Business.Interfaces
{
    public interface IBenutzerGruppeService
    {
        BenutzerGruppe SearchGroupById(int id);

        BenutzerGruppe SearchGroupByBezeichnung(string bezeichnung);

        List<BenutzerGruppe> FindAllGroups();

        void AddBenutzerGruppe(BenutzerGruppe benutzerGruppe);

        void EditBenutzerGruppe(BenutzerGruppe benutzerGruppe);

        void RemoveBenutzerGruppe(int id);
    }
}