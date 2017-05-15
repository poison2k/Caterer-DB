using Common.Model;
using System.Collections.Generic;

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