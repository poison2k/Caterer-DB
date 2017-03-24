using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;
using System.Data.Entity;
using System;

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

        public List<List<Frage>> GetAllFragenSortetByKategorienInDifferntLists(List<Kategorie> kategorien)
        {

            var fragen = new List<List<Frage>>();
            foreach (Kategorie kategorie in kategorien)
            {
                var fragenFürKategorie = Db.Frage.Include(y => y.Kategorie).Where(x => x.IstVeröffentlicht == true).Where(x => x.Kategorie.Bezeichnung == kategorie.Bezeichnung).ToList();
                if (fragenFürKategorie.Count != 0)
                {
                    fragen.Add(Db.Frage.Include(y => y.Kategorie).Where(x => x.IstVeröffentlicht == true).Where(x => x.Kategorie.Bezeichnung == kategorie.Bezeichnung).ToList());
                }
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
            var test = Db.Frage.Include(x => x.Antworten).Include(x => x.Kategorie).Where(x => x.FrageId == frage.FrageId).SingleOrDefault();
            var neueAntworten = new List<Antwort>();
            var deleteAntworten = new List<Antwort>();
            //Alte Antworten Löschen
            foreach (Antwort antwort in test.Antworten) {
                bool istVorhanden = false;
                foreach (Antwort newAntwort in frage.Antworten) {
                    if (newAntwort.AntwortId == antwort.AntwortId) {
                        istVorhanden = true;
                    }
                }
                if (istVorhanden) {
                    neueAntworten.Add(antwort);
                }else
                {
                    deleteAntworten.Add(antwort);
                }
            }

            deleteAntworten.ToList().ForEach(x =>  Db.Antwort.Remove(x));

            //Neue Antworten hinzufügen
            foreach (Antwort antwort in frage.Antworten) {
                bool istVorhanden = false;
                foreach (Antwort newAntworten in neueAntworten) {
                    if (newAntworten.AntwortId != 0 && newAntworten.AntwortId == antwort.AntwortId) {
                        istVorhanden = true;
                    }
                    
                }
                if (!istVorhanden) {
                    neueAntworten.Add(antwort);
                }
            }
            test.Kategorie = frage.Kategorie;
            test.IstMultiSelect = frage.IstMultiSelect;
            test.IstVeröffentlicht = frage.IstVeröffentlicht;
            test.Bezeichnung = frage.Bezeichnung;                     
            test.Antworten = neueAntworten;
                     
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
            return Db.Frage.Include(x => x.Antworten).Include(x => x.Kategorie).ToList();
        }

        public List<Frage> GetFragenOfKategorieByKategorieId(int kategorieId)
        {

            return Db.Frage.Where(x => x.Kategorie.KategorieId == kategorieId).ToList();
            {


            }
        }

        public List<Frage> SearchAllFrageNeuWithPagingOrderByCategory(int aktuelleSeite, int seitenGroesse, string orderBy)
        {
            var frageQuery = Db.Frage.Include(x => x.Kategorie).Include(x => x.Antworten);
            frageQuery = frageQuery.Where(y => y.IstVeröffentlicht  == false);
            frageQuery = SortFilter(frageQuery, orderBy).Skip((aktuelleSeite - 1) * seitenGroesse).Take(seitenGroesse);
            return frageQuery.ToList();
        }

        public List<Frage> SearchAllFrageVeröffentlichtWithPagingOrderByCategory(int aktuelleSeite, int seitenGroesse, string orderBy)
        {
            var frageQuery = Db.Frage.Include(x => x.Kategorie).Include(x => x.Antworten);
            frageQuery = frageQuery.Where(y => y.IstVeröffentlicht == true);
            frageQuery = SortFilter(frageQuery, orderBy).Skip((aktuelleSeite - 1) * seitenGroesse).Take(seitenGroesse);
            return frageQuery.ToList();
        }

        public int GetFrageNeuCount()
        {
            return Db.Frage.Where(x => x.IstVeröffentlicht == false).Count();
        }

        public int GetFrageVeröffentlichtCount()
        {
            return Db.Frage.Where(x => x.IstVeröffentlicht == true).Count();
        }


        private IQueryable<Frage> SortFilter(IQueryable<Frage> query, string orderBy)
        {

            switch (orderBy)
            {
                case "Bezeichnung":
                    query = query.OrderBy(x => x.Bezeichnung);
                    break;
                case "Bezeichnung_desc":
                    query = query.OrderByDescending(x => x.Bezeichnung);
                    break;
                case "Kategorie":
                    query = query.OrderBy(x => x.Kategorie.Bezeichnung);
                    break;
                case "Kategorie_desc":
                    query = query.OrderByDescending(x => x.Kategorie.Bezeichnung);
                    break;
                case "Antworten":
                    query = query.OrderBy(x => x.Antworten.Count);
                    break;
                case "Antworten_desc":
                    query = query.OrderByDescending(x => x.Antworten.Count);
                    break;
                case "IstMultiSelect":
                    query = query.OrderBy(x => x.IstMultiSelect);
                    break;
                case "IstMultiSelect_desc":
                    query = query.OrderByDescending(x => x.IstMultiSelect);
                    break;
            }

            return query;
        }

    }
}

