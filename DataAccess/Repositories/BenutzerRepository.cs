using Common.Model;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;

namespace DataAccess.Repositories
{
    public class BenutzerRepository : IBenutzerRepository
    {
        protected ICatererContext Db { get; }

        public BenutzerRepository(ICatererContext db)
        {
            Db = db;
        }

        public List<Benutzer> FindeCatererNachUmkreis(DbGeography geoDaten, int umkreis)
        {
            var query = Db.Benutzer.Where(x => x.Koordinaten.Distance(geoDaten) <= umkreis * 1000).OrderBy(x => x.Koordinaten.Distance(geoDaten) <= umkreis * 1000).ToList();

            return query.ToList();
        }

        public Benutzer SearchUserById(int id)
        {
            return Db.Benutzer.Include(x => x.BenutzerGruppen).Where(x => x.BenutzerId == id).SingleOrDefault();
        }

        public Benutzer SearchUserByIdNoTracking(int id)
        {
            return Db.Benutzer.AsNoTracking().Where(x => x.BenutzerId == id).SingleOrDefault();
        }

        public Benutzer SearchUserByEmailVerify(string verify)
        {
            return Db.Benutzer.Where(x => x.EMailVerificationCode == verify).SingleOrDefault();
        }

        public Benutzer SearchUserByEMail(string eMail)
        {
            return Db.Benutzer.Where(x => x.Mail == eMail).SingleOrDefault();
        }

        public List<Benutzer> SearchUserByCity(string city)
        {
            return Db.Benutzer.Where(x => x.Ort == city).ToList();
        }

        public List<Benutzer> SearchUserByPostcode(string postcode)
        {
            return Db.Benutzer.Where(x => x.Postleitzahl == postcode).ToList();
        }

        public List<Benutzer> SearchUserBySurname(string surname)
        {
            return Db.Benutzer.Where(x => x.Nachname == surname).ToList();
        }

        public List<Benutzer> SearchUser()
        {
            return Db.Benutzer.ToList();
        }

        public List<Benutzer> SearchUser(List<int> ids)
        {
            return Db.Benutzer.Where(x => ids.Contains(x.BenutzerId)).ToList();
        }

        public List<Benutzer> SearchAllUserByUserGroupWithPagingOrderByCategory(int aktuelleSeite, int seitenGroesse, List<string> BenutzerGruppen, string orderBy, int umkreis = -1, DbGeography geoDaten = null, string name = "")
        {
            var query = Db.Benutzer.Include(x => x.BenutzerGruppen);

            if (BenutzerGruppen.Count > 1)
            {
                query = query.Where(y => y.BenutzerGruppen.Contains(Db.BenutzerGruppe.Where(x => x.Bezeichnung == "Administrator").FirstOrDefault()) || y.BenutzerGruppen.Contains(Db.BenutzerGruppe.Where(x => x.Bezeichnung == "Mitarbeiter").FirstOrDefault()));
            }
            else
            {
                query = query.Where(y => y.BenutzerGruppen.Contains(Db.BenutzerGruppe.Where(x => x.Bezeichnung == "Caterer").FirstOrDefault()));
            }

            if (name != "" && name != null)
            {
                query = query.Where(y => y.Firmenname.Contains(name));
            }

            if (name != "" && umkreis != 100 && umkreis != 0 && umkreis != -1 && geoDaten != null)
            {
                query = query.Where(x => x.Koordinaten.Distance(geoDaten) <= umkreis * 1000).OrderBy(x => x.Koordinaten.Distance(geoDaten) <= umkreis * 1000);
                query.Where(x => x.Lieferumkreis <= umkreis);
            }

            query = SortFilter(query, orderBy).Skip((aktuelleSeite - 1) * seitenGroesse).Take(seitenGroesse);

            return query.ToList();
        }

        public List<Benutzer> SearchAllCatererWithPaging(int aktuelleSeite, int seitenGroesse)
        {
            //ToDo BenutzerGruppen als Parameter übergeben
            //Abfrage optimieren nur benötigte Daten abrufen
            var benutzerGruppe = Db.BenutzerGruppe.Where(y => y.Bezeichnung == "Caterer").Single();
            return Db.Benutzer.Include(y => y.BenutzerGruppen)
                .ToList().Where(x => x.BenutzerGruppen.Contains(benutzerGruppe))
                .Skip((aktuelleSeite - 1) * seitenGroesse).Take(seitenGroesse).ToList();
        }

        public int GetMitarbeiterCount()
        {
            //Abfrage optimieren nur benötigte Daten abrufen
            var mitarbeiter = Db.BenutzerGruppe.Single(y => y.Bezeichnung == "Mitarbeiter");
            var administratoren = Db.BenutzerGruppe.Single(y => y.Bezeichnung == "Administrator");
            return Db.Benutzer.Include(y => y.BenutzerGruppen).ToList().Where(x => x.BenutzerGruppen.Contains(mitarbeiter) || x.BenutzerGruppen.Contains(administratoren)).Count();
        }

        public int GetAdminCount()
        {
            //Abfrage optimieren nur benötigte Daten abrufen
            var administratoren = Db.BenutzerGruppe.Single(y => y.Bezeichnung == "Administrator");
            return Db.Benutzer.Include(y => y.BenutzerGruppen).ToList().Where(x => x.BenutzerGruppen.Contains(administratoren)).Count();
        }

        public int GetCatererCount()
        {
            //Abfrage optimieren nur benötigte Daten abrufen
            var caterer = Db.BenutzerGruppe.Single(y => y.Bezeichnung == "Caterer");
            return Db.Benutzer.Include(y => y.BenutzerGruppen).ToList().Where(x => x.BenutzerGruppen.Contains(caterer)).Count();
        }

        public void AddUser(Benutzer benutzer)
        {
            benutzer.PasswortZeitstempel = DateTime.Now;
            benutzer.LetzteÄnderung = DateTime.Now;
            Db.Benutzer.Add(benutzer);
            Db.SaveChanges();
        }

        public void EditUser(Benutzer benutzer)
        {
            Db.SetModified(benutzer);
            Db.SaveChanges();
        }

        public void RemoveUser(Benutzer benutzer)
        {
            Db.Set<Benutzer>().Remove(benutzer);
            Db.SaveChanges();
        }

        private IQueryable<Benutzer> SortFilter(IQueryable<Benutzer> query, string orderBy)
        {
            switch (orderBy)
            {
                case "BenutzerId":
                    query = query.OrderBy(x => x.BenutzerId);
                    break;

                case "BenutzerId_desc":
                    query = query.OrderByDescending(x => x.BenutzerId);
                    break;

                case "Anrede":
                    query = query.OrderBy(x => x.Anrede);
                    break;

                case "Anrede_desc":
                    query = query.OrderByDescending(x => x.Anrede);
                    break;

                case "Nachname":
                    query = query.OrderBy(x => x.Nachname);
                    break;

                case "Nachname_desc":
                    query = query.OrderByDescending(x => x.Nachname);
                    break;

                case "Vorname":
                    query = query.OrderBy(x => x.Vorname);
                    break;

                case "Vorname_desc":
                    query = query.OrderByDescending(x => x.Vorname);
                    break;

                case "PLZ":
                    query = query.OrderBy(x => x.Postleitzahl);
                    break;

                case "PLZ_desc":
                    query = query.OrderByDescending(x => x.Postleitzahl);
                    break;

                case "Ort":
                    query = query.OrderBy(x => x.Ort);
                    break;

                case "Ort_desc":
                    query = query.OrderByDescending(x => x.Ort);
                    break;

                case "Telefon":
                    query = query.OrderBy(x => x.Telefon);
                    break;

                case "Telefon_desc":
                    query = query.OrderByDescending(x => x.Telefon);
                    break;

                case "Strasse":
                    query = query.OrderBy(x => x.Straße);
                    break;

                case "Strasse_desc":
                    query = query.OrderByDescending(x => x.Straße);
                    break;

                case "Organisationsform":
                    query = query.OrderBy(x => x.Organisationsform);
                    break;

                case "Organisationsform_desc":
                    query = query.OrderByDescending(x => x.Organisationsform);
                    break;

                case "Firmenname":
                    query = query.OrderBy(x => x.Firmenname);
                    break;

                case "Firmenname_desc":
                    query = query.OrderByDescending(x => x.Firmenname);
                    break;

                case "FunktionAnsprechpartner":
                    query = query.OrderBy(x => x.FunktionAnsprechpartner);
                    break;

                case "FunktionAnsprechpartner_desc":
                    query = query.OrderByDescending(x => x.FunktionAnsprechpartner);
                    break;

                case "Internetadresse":
                    query = query.OrderBy(x => x.Internetadresse);
                    break;

                case "Internetadresse_desc":
                    query = query.OrderByDescending(x => x.Internetadresse);
                    break;

                case "Lieferumkreis":
                    query = query.OrderBy(x => x.Lieferumkreis);
                    break;

                case "Lieferumkreis_desc":
                    query = query.OrderByDescending(x => x.Lieferumkreis);
                    break;

                case "Mail":
                    query = query.OrderBy(x => x.Mail);
                    break;

                case "Mail_desc":
                    query = query.OrderByDescending(x => x.Mail);
                    break;

                case "Postleitzahl":
                    query = query.OrderBy(x => x.Postleitzahl);
                    break;

                case "Postleitzahl_desc":
                    query = query.OrderByDescending(x => x.Postleitzahl);
                    break;

                case "IstAdmin":
                    query = query.OrderBy(p => p.BenutzerGruppen.Select(r => r.Bezeichnung).FirstOrDefault());

                    break;

                case "IstAdmin_desc":
                    query = query.OrderByDescending(p => p.BenutzerGruppen.Select(r => r.Bezeichnung).FirstOrDefault());
                    break;
            }

            return query;
        }
    }
}