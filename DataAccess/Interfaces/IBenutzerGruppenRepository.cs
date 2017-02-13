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
        void AddGroup(editBenutzerGruppeViewModel benutzerGruppe);
        void EditGroup(editBenutzerGruppeViewModel benutzerGruppe);
        void RemoveGroup(editBenutzerGruppeViewModel benutzerGruppe);

        editBenutzerGruppeViewModel SearchGroupById(int id);
        editBenutzerGruppeViewModel SearchGroupByBezeichnung(string bezeichnung);

        List<editBenutzerGruppeViewModel> SearchGroup();
        List<editBenutzerGruppeViewModel> SearchGroupByRechteGruppe(RechteGruppe rechteGruppe);
        List<editBenutzerGruppeViewModel> SearchGroupByBenutzer(Benutzer benutzer);
    }
}
