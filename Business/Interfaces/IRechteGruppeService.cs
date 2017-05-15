using System.Collections.Generic;
using Common.Model;

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