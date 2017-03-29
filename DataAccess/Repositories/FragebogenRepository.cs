using DataAccess.Interfaces;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class FragebogenRepository : IFragebogenRepository
    {
        protected ICatererContext Db { get; }

        protected FragebogenRepository(ICatererContext db)
        {
            Db = db;
        }

        public Fragebogen SearchFragenbogenById(int id)
        {
            return Db.Fragebogen.Where(x => x.FragebogenId == id).SingleOrDefault();
        }

        public List<Fragebogen> SearchFragebogenByBenutzer(Benutzer benutzer)
        {
            return Db.Fragebogen.Where(x => x.Benutzer == benutzer).ToList();
        }

        public List<Fragebogen> SearchFragebogenByAntwort(Antwort antwort)
        {
            return Db.Fragebogen.Where(x => x.Antwort == antwort).ToList();
        }
    }
}