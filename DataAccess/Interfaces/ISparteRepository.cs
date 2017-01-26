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
        Sparte SearchSparteById(int id);
        Sparte SearchUserByName(string name);
    }
}
