using DataAccess.Interfaces;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using System;

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
        
    }
}
