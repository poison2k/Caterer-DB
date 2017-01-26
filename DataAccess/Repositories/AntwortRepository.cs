using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Repositories
{
    public class AntwortRepository : IAntwortRepository
    {
        protected ICatererContext Db { get; }

        protected AntwortRepository(ICatererContext db)
        {
            Db = db;
        }

        public Antwort SearchAntwortById(int id)
        {
            return Db.Antwort.Where(x => x.AntwortId == id).SingleOrDefault();
        }

        public List<Antwort> SearchAntwortByFrage(Frage frage)
        {
            return Db.Antwort.Where(x => x.Frage == frage).ToList();
        }
    }
}
