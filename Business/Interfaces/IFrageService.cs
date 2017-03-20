using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFrageService
    {
        Frage SearchFrageById(int id);
        List<Frage> FindAlleFragen();
        List<Frage> FindFragenNachKategorieByKategorieId(int kategorieId);
        List<List<Frage>> FindAlleFragenNachKategorieninEigenenListen();
        void AddFrage(Frage frage);
        void EditFrage(Frage frage);
        void RemoveFrage(int id);

    }
}
