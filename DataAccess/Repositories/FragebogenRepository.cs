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

     
        public List<Fragebogen> SearchFragebogenByBenutzer(Benutzer benutzer)
        {
            return Db.Fragebogen.Where(x => x.Benutzer == benutzer).ToList();
        }
    }
}
