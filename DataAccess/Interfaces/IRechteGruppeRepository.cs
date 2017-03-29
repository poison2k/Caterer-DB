using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IRechteGruppeRepository
    {
        void AddRightGroup(RechteGruppe rechteGruppe);

        void EditRightGroup(RechteGruppe rechteGruppe);

        void RemoveRightGroup(RechteGruppe rechteGruppe);

        RechteGruppe SearchRightGroupById(int id);

        RechteGruppe SearchRightGroupByBezeichnung(string bezeichnung);

        List<RechteGruppe> SearchRightGroup();

        List<RechteGruppe> SearchRightGroupByRecht(Recht recht);
    }
}