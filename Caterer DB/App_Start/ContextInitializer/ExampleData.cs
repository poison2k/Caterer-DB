using Caterer_DB;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.App_Start.ContextInitializer
{
    public class ExampleData
    {



        public static void CreateExampleData(CatererContext db)
        {
            CreateUserData(db);
        }

        private static void CreateUserData(CatererContext db)
        {

            Benutzer caterer = db.Benutzer.Add(new Benutzer {
                
                Mail = "caterer@test.de",
                Passwort ="Start#22",
                Nachname = "Mustermann",
                Vorname = "Max"

                
            });

            Benutzer mitarbeiter = db.Benutzer.Add(new Benutzer {
            

                Mail = "mitarbeiter@test.de",
                Passwort ="Start#22",
                Nachname = "Musterfrau",
                Vorname = "Maxim"
            });

            Benutzer admin = db.Benutzer.Add(new Benutzer {
            

                Mail = "admin@test.de",
                Passwort ="Start#22",
                Nachname = "Müller",
                Vorname = "Alex"
            });

            db.SaveChanges();
        }
    }
}