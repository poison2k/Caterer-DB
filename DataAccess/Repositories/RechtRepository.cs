using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using  Common.Model;
namespace DataAccess.Repositories
{
    public class RechtRepository : IRechtRepository
    {
        protected ICatererContext Db { get; }

        public RechtRepository(ICatererContext db)
        {
            Db = db;
        }

        public void AddRight(Recht recht)
        {
            Db.Recht.Add(recht);
            Db.SaveChanges();
        }

        public void EditRight(Recht recht)
        {
            Db.SetModified(recht);
            Db.SaveChanges();
        }

        public void RemoveRight(Recht recht)
        {
            Db.Set<Recht>().Remove(recht);
            Db.SaveChanges();
        }

        public List<Recht> SearchRight()
        {
            return Db.Recht.ToList();
        }

        public Recht SearchRightByBezeichnung(string bezeichnung)
        {
            return Db.Recht.Where(x => x.Bezeichnung.Contains(bezeichnung)).SingleOrDefault();
        }

        public Recht SearchRightById(int id)
        {
            return Db.Recht.Where(x => x.RechtId == id).SingleOrDefault();
        }

        public List<Recht> SearchRightByRechteGruppe(RechteGruppe rechteGruppe)
        {
            return Db.Recht.Where(x => x.RechteVerwaltungsGruppen.Contains(rechteGruppe)).ToList();
        }
    }
}