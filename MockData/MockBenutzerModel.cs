using Caterer_DB.Resources;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockData
{
    public static class MockBenutzerModel
    {

        public static  Benutzer EinCaterer()
        {
            return new Benutzer
            {
                Mail = "citygrilluelzen@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Panzer",
                Vorname = "Paul",
                IstEmailVerifiziert = true,
                Firmenname = "City Grill Uelzen",
                Internetadresse = "citygrilluelzen.de",
                Lieferumkreis = 40,
                Organisationsform = "Caterer",
                Telefon = "05026/54682",
                Fax = "05026/54687",
                Straße = "Bahnhofsstraße 9",
                Postleitzahl = "29525 ",
                Ort = "Uelzen",
                Anrede = "Herr",
                FunktionAnsprechpartner = "Geschäftsführer",
                EMailVerificationCode = "-",
                _AntwortIDs = "4, 5, 9, 11, 18, 23, 25, 28",
                PasswortZeitstempel = System.DateTime.Now,
                LetzteÄnderung = System.DateTime.Now,
                Koordinaten = DbGeography.FromText("Point( 10.555055 52.966940 )"),
                BenutzerGruppen = new List<BenutzerGruppe>() 
            };
        }


    }

}

