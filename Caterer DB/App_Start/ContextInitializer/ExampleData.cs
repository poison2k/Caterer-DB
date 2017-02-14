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
                EMailVerificationCode = "b",
                IstEmailVerifiziert = true
            });

            Benutzer mitarbeiter = db.Benutzer.Add(new Benutzer
            {
                Mail = "mitarbeiter@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Musterfrau",
                Vorname = "Maxim",
                EMailVerificationCode = "a",
                IstEmailVerifiziert = true
            });

            Benutzer admin = db.Benutzer.Add(new Benutzer
            {
                Mail = "admin@test.de",
                Passwort = "AF6WTsIXVQnb+mfScpc2kSFMkFby3q4JBwEjmEV2zjGiiKLp1HSO/d+Yxnjx5ief3A==",
                Nachname = "Müller",
                Vorname = "Alex",
                EMailVerificationCode = "c",
                IstEmailVerifiziert = true
            });

            db.SaveChanges();
        }
    }
}