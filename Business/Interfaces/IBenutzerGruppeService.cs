using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
