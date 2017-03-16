using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISparteService
    {
        Sparte SearchSparteById(int id);
        List<Sparte> FindAlleSparten();
        void AddSparte(Sparte sparte);
        void EditSparte(Sparte sparte);
        void RemoveSparte(int id);
        Sparte SearchSparteByName(string sparte);
    }
}
