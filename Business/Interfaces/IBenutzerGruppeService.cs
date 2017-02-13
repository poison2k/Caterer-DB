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
        editBenutzerGruppeViewModel SearchGroupById(int id);
        List<editBenutzerGruppeViewModel> FindAllGroups();
        void AddBenutzerGruppe(editBenutzerGruppeViewModel benutzerGruppe);
        void EditBenutzerGruppe(editBenutzerGruppeViewModel benutzerGruppe);
        void RemoveBenutzerGruppe(int id);
    }
}
