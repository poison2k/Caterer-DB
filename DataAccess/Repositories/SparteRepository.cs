using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Repositories
{
    public class SparteRepository : ISparteRepository
    {
        protected ICatererContext Db { get; }

        protected SparteRepository(ICatererContext db)
        {
            Db = db;
        }

        public Sparte SearchSparteById(int id)
        {
            return Db.Sparte.Where(x => x.SparteId == id).SingleOrDefault();
        }

        public Sparte SearchUserByName(string name)
        {
            return Db.Sparte.Where(x => x.Bezeichnung == name).SingleOrDefault();
        }
    }
}
