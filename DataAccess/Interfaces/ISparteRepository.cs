using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ISparteRepository
    {
        void AddSparte(Sparte sparte);
        void EditSparte(Sparte sparte);
        void RemoveSparte(Sparte sparte);

        List<Sparte> SearchSparte();
        Sparte SearchSparteById(int id);
        Sparte SearchSparteByName(string name);
    }
}
