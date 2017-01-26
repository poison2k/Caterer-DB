using DataAccess.Interfaces;
using DataAccess.Model;
using System.Linq;

namespace DataAccess.Repositories
{
    public class BenutzerRepository : IBenutzerRepository
    {
        protected ICatererContext Db { get; }

        protected BenutzerRepository(ICatererContext db)
        {
            Db = db;
        }

        public Benutzer SearchUserById(int id) {

            return Db.Benutzer.Where(x => x.BenutzerId == id).SingleOrDefault();

        }

        public Benutzer SearchUserByEMail(string eMail)
        {

            return Db.Benutzer.Where(x => x.Mail == eMail).SingleOrDefault();

        }

    }
}
