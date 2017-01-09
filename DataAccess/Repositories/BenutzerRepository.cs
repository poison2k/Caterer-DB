using DataAccess.Context;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BenutzerRepository
    {
        public DbContext DB = new DbContext();



        public Benutzer SucheBenutzerNachID(int Id) {


            return DB.Benutzer.Where(x => x.BenutzerId == Id).SingleOrDefault();


            
        }

    }
}
