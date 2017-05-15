using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Common.Model;

namespace DataAccess.Repositories
{
    public class AntwortRepository : IAntwortRepository
    {
        protected ICatererContext Db { get; }

        public AntwortRepository(ICatererContext db)
        {
            Db = db;
        }

        public Antwort SearchAntwortById(int id)
        {
            return Db.Antwort.Where(x => x.AntwortId == id).SingleOrDefault();
        }

        public void AddAntwort(Antwort Antwort)
        {
            Db.Antwort.Add(Antwort);
            Db.SaveChanges();
        }

        public void EditAntwort(Antwort Antwort)
        {
            Db.SetModified(Antwort);
            Db.SaveChanges();
        }

        public void RemoveAntwort(Antwort Antwort)
        {
            Db.Set<Antwort>().Remove(Antwort);
            Db.SaveChanges();
        }

        public List<Antwort> SearchAntwort()
        {
            return Db.Antwort.ToList();
        }

        public List<Antwort> SearchAntwortByFrage(Frage frage)
        {
            return Db.Antwort.Where(x => x.Frage == frage).ToList();
        }
    }
}