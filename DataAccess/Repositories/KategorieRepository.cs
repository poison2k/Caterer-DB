using Common.Model;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class KategorieRepository : IKategorieRepository
    {
        protected ICatererContext Db { get; }

        public KategorieRepository(ICatererContext db)
        {
            Db = db;
        }

        public Kategorie SearchKategorieIdById(int id)
        {
            return Db.Kategorie.Where(x => x.KategorieId == id).SingleOrDefault();
        }

        public void AddKategorie(Kategorie kategorie)
        {
            Db.Kategorie.Add(kategorie);
            Db.SaveChanges();
        }

        public void EditKategorie(Kategorie kategorie)
        {
            Db.SetModified(kategorie);
            Db.SaveChanges();
        }

        public void RemoveKategorie(Kategorie kategorie)
        {
            Db.Set<Kategorie>().Remove(kategorie);
            Db.SaveChanges();
        }

        public List<Kategorie> SearchKategorie()
        {
            return Db.Kategorie.OrderBy(x => x.Bezeichnung).ToList();
        }

        public Kategorie SearchKategorieByName(string name)
        {
            return Db.Kategorie.Where(x => x.Bezeichnung == name).SingleOrDefault();
        }
    }
}