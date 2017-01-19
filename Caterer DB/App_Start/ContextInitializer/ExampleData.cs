using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.App_Start.ContextInitializer
{
    public class ExampleData
    {
        public static void CreateExampleData(ICatererContext db)
        {
            CreateUserData(db);
        }

        private static void CreateUserData(ICatererContext db)
        {
            throw new NotImplementedException();

            //Benutzer ersterBenutzer = db.Benutzer.Add(new Benutzer
            //{
            //    Anrede = "Herr",
            //    Vorname = "Rico",
            //    Nachname = "Giacu",
            //    NachnameOhneUmlaut = "Giacu",
            //    Kurzname = "RicoGiacu",
            //    Uid = "RicoGiacu",
            //    Personalnummer = "10009811",
            //    Pk = "250270G42518",
            //    DienstgradKurz = "StFw",
            //    DienstgradLang = "Stabsfeldwebel",
            //    Dienststelle = "LwUstgGrpLw WAHN",
            //    Mail = "ricogiacu@bundesehr.org",
            //    Taetigkeit = "Anwendungsentwickler"
            //});
        }
    }
}