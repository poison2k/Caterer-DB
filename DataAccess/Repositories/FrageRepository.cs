using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using System.Data.Entity;

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
            return Db.Frage.Include(x => x.Antworten).Include(x => x.Sparte).Where(x => x.FrageId == id).SingleOrDefault();
        }

        public List<List<Frage>> GetAllFragenSortetBySparteInDifferntLists(List<Sparte> sparten) {

            var fragen = new List<List<Frage>>();
            foreach (Sparte sparte in sparten) {
                fragen.Add(Db.Frage.Include(y => y.Sparte).Where(x => x.Sparte.Bezeichnung == sparte.Bezeichnung).ToList());
            }

            return fragen;
        } 

        public List<Frage> SearchFrageBySparte(Sparte sparte)
        {
            return Db.Frage.Include(x => x.Antworten).Where(x => x.Sparte == sparte).ToList();
        }

        public void AddFrage(Frage frage)
        {
            Db.Frage.Add(frage);
            Db.SaveChanges();
        }

        public void EditFrage(Frage frage)
        {
            foreach (var item in frage.Antworten)
            {
                Db.SetModified(item);
            }

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
            return Db.Frage.Include(x => x.Antworten).ToList();
        }
    }
}
