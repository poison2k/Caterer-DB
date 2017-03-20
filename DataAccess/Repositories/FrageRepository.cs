using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            return Db.Frage.Include(x => x.Antworten).Include(x => x.Kategorie).Where(x => x.FrageId == id).SingleOrDefault();
        }

        public List<List<Frage>> GetAllFragenSortetByKategorienInDifferntLists(List<Kategorie> kategorien) {

            var fragen = new List<List<Frage>>();
            foreach (Kategorie kategorie in kategorien) {
                fragen.Add(Db.Frage.Include(y => y.Kategorie).Where(x => x.Kategorie.Bezeichnung == kategorie.Bezeichnung).ToList());
            }

            return fragen;
        } 

        public List<Frage> SearchFrageByKategorie(Kategorie kategorien)
        {
            return Db.Frage.Include(x => x.Antworten).Where(x => x.Kategorie == kategorien).ToList();
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
            
            Db.Set<Antwort>().RemoveRange(frage.Antworten);
            
            Db.Set<Frage>().Remove(frage);
            Db.SaveChanges();
        }

        public List<Frage> SearchFrage()
        {
            return Db.Frage.Include(x => x.Antworten).ToList();
        }
    }
}
