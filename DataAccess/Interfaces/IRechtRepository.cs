using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
