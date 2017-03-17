using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;

namespace DataAccess.Repositories
{
    public class SparteRepository : ISparteRepository
    {
        protected ICatererContext Db { get; }

        public SparteRepository(ICatererContext db)
        {
            Db = db;
        }

        public Sparte SearchSparteById(int id)
        {
            return Db.Sparte.Where(x => x.SparteId == id).SingleOrDefault();
        }

        public void AddSparte(Sparte Sparte)
        {
            Db.Sparte.Add(Sparte);
            Db.SaveChanges();
        }

        public void EditSparte(Sparte Sparte)
        {
            Db.SetModified(Sparte);
            Db.SaveChanges();
        }

        public void RemoveSparte(Sparte Sparte)
        {
            Db.Set<Sparte>().Remove(Sparte);
            Db.SaveChanges();
        }

        public List<Sparte> SearchSparte()
        {
            return Db.Sparte.OrderBy(x=>x.Bezeichnung).ToList();
        }

        public Sparte SearchSparteByName(string name)
        {
            return Db.Sparte.Where(x => x.Bezeichnung == name).SingleOrDefault();
        }
    }
}
