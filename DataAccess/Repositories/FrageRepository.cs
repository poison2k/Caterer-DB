using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Repositories
{
    public class FrageRepository : IFrageRepository
    {
        protected ICatererContext Db { get; }
        
        public FrageRepository(ICatererContext db)
        {
            Db = db;
        }

        public Frage SearchFrageById(int id)
        {
            return Db.Frage.Where(x => x.FrageId == id).SingleOrDefault();
        }

        public List<Frage> SearchFrageBySparte(Sparte sparte)
        {
            return Db.Frage.Where(x => x.Sparte == sparte).ToList();
        }

        public void AddFrage(Frage frage)
        {
            Db.Frage.Add(frage);
            Db.SaveChanges();
        }

        public void EditFrage(Frage frage)
        {
            Db.SetModified(frage);
            Db.SaveChanges();
        }

        public void RemoveFrage(Frage frage)
        {
            Db.Set<Frage>().Remove(frage);
            Db.SaveChanges();
        }

        public List<Frage> SearchFrage()
        {
            return Db.Frage.ToList();
        }
    }
}
