using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IFrageRepository
    {
        void AddFrage(Frage frage);
        void EditFrage(Frage frage);
        void RemoveFrage(Frage frage);
        
        List<Frage> SearchFrage();
        Frage SearchFrageById(int id);
        List<Frage> SearchFrageBySparte(Sparte sparte);
        List<List<Frage>> GetAllFragenSortetBySparteInDifferntLists(List<Sparte> sparten);
    }
}
