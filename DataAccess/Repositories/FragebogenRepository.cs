using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Model;

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

        public List<Fragebogen> SearchFragebogenByAntwort(Antwort antwort)
        {
            return Db.Fragebogen.Where(x => x.Antwort == antwort).ToList();
        }

        public List<Fragebogen> SearchFragebogenByBenutzer(Benutzer benutzer)
        {
            return Db.Fragebogen.Where(x => x.Benutzer == benutzer).ToList();
        }

        public List<Fragebogen> SearchFragebogenByFrage(Frage frage)
        {
            return Db.Fragebogen.Where(x => x.Frage == frage).ToList();
        }
    }
}
