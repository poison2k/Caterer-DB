using Common.Model;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IRechteGruppeService
    {
        RechteGruppe SearchRightGroupById(int id);

        List<RechteGruppe> FindAllRightGroups();

        void AddRechteGruppe(RechteGruppe rechteGruppe);

        void EditRechteGruppe(RechteGruppe rechteGruppe);

        void RemoveRechteGruppe(int id);
    }
}