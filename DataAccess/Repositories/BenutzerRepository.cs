using DataAccess.Interfaces;
using DataAccess.Model;
using System.Collections.Generic;
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

        public Benutzer SearchUserById(int id)
        {

            return Db.Benutzer.Where(x => x.BenutzerId == id).SingleOrDefault();

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

            return Db.Benutzer.Where(x => x.Plz == postcode).ToList();

        }

        public List<Benutzer> SearchUserBySurname(string surname)
        {

            return Db.Benutzer.Where(x => x.Nachname == surname).ToList();

        }

        public List<Benutzer> SearchUser()
        {

            return Db.Benutzer.ToList();

        }

        public void AddUser(Benutzer benutzer)
        {
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
            Db.Benutzer.Remove(benutzer);
            Db.SaveChanges();

        }

    }
}
