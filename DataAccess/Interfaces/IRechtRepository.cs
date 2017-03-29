using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IRechtRepository
    {
        void AddRight(Recht recht);

        void EditRight(Recht recht);

        void RemoveRight(Recht recht);

        Recht SearchRightById(int id);

        Recht SearchRightByBezeichnung(string bezeichnung);

        List<Recht> SearchRight();

        List<Recht> SearchRightByRechteGruppe(RechteGruppe rechteGruppe);
    }
}