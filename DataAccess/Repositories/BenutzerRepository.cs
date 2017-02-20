using DataAccess.Interfaces;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;

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

        public void AddUser(Benutzer benutzer)
        {
            benutzer.PasswortZeitstempel = DateTime.Now;
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

    
    }
}
