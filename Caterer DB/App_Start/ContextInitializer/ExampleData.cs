using DataAccess.Context;
using DataAccess.Model;

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
            Benutzer caterer = db.Benutzer.Add(new Benutzer
            {
                Mail = "caterer@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Mustermann",
                Vorname = "Max",
                IstEmailVerifiziert = true,
                Firmenname = "AllYouCanEat GmbH",
                Internetadresse = "www.AYCE.de",
                Lieferumkreis = "50km",
                Organisationsform = "Vorhanden",
                Telefon = "01234 - 56789",
                Fax = "01234 - 99999",
                Straße = "Holzweg 1",
                Postleitzahl = "87654",
                Ort = "Woodway",
                Anrede = "Herr",
                FunktionAnsprechpartner = "Chef",
                EMailVerificationCode = "",
                PasswortZeitstempel = System.DateTime.Now
            });

            Benutzer mitarbeiter = db.Benutzer.Add(new Benutzer
            {
                Mail = "mitarbeiter@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Musterfrau",
                Vorname = "Maxim",
                IstEmailVerifiziert = true,
                Firmenname = "-",
                Internetadresse = "-",
                Lieferumkreis = "-",
                Organisationsform = "-",
                Telefon = "-",
                Fax = "-",
                Straße = "-",
                Postleitzahl = "-",
                Ort = "-",
                Anrede = "-",
                FunktionAnsprechpartner = "-",
                EMailVerificationCode = "-",
                PasswortZeitstempel = System.DateTime.Now
            });

            Benutzer admin = db.Benutzer.Add(new Benutzer
            {
                Mail = "admin@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Müller",
                Vorname = "Alex",
                IstEmailVerifiziert = true,
                Firmenname = "-",
                Internetadresse = "-",
                Lieferumkreis = "-",
                Organisationsform = "-",
                Telefon = "-",
                Fax = "-",
                Straße = "-",
                Postleitzahl = "-",
                Ort = "-",
                Anrede = "-",
                FunktionAnsprechpartner = "-",
                EMailVerificationCode = "-",
                PasswortZeitstempel = System.DateTime.Now
            });

            Benutzer testuser = db.Benutzer.Add(new Benutzer
            {
                Mail = "poison2k@gmail.com",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Bünck",
                Vorname = "Sebastian",
                IstEmailVerifiziert = true,
                Firmenname = "AllYouCanEat GmbH",
                Internetadresse = "www.AYCE.de",
                Lieferumkreis = "50km",
                Organisationsform = "Vorhanden",
                Telefon = "01234 - 56789",
                Fax = "01234 - 99999",
                Straße = "Holzweg 1",
                Postleitzahl = "87654",
                Ort = "Woodway",
                Anrede = "Herr",
                FunktionAnsprechpartner = "Chef",
                EMailVerificationCode = "",
                PasswortZeitstempel = System.DateTime.Now
            });

            db.SaveChanges();
        }
    }
}