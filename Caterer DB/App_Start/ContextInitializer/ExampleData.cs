﻿using DataAccess.Context;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Caterer_DB.App_Start.ContextInitializer
{
    public class ExampleData
    {
        public static void CreateExampleData(CatererContext db)
        {
            CreateRechteGruppenData(db);
            CreateBenutzerGruppenData(db);
            CreateUserData(db);
        }


        private static void CreateRechteGruppenData(CatererContext db) {
            RechteGruppe AdminRechte = db.RechteGruppe.Add(new RechteGruppe {
                Bezeichnung = "AdminRechte",
                Rechte = new List<Recht>(){ new Recht() { Bezeichnung = "Testblock1", Beschreibung = "Zeigt Block 1 an " } }
            });

        
            RechteGruppe CatererRechte = db.RechteGruppe.Add(new RechteGruppe
            {
                Bezeichnung = "CatererRechte",
                Rechte = new List<Recht>() { new Recht() { Bezeichnung = "Testblock3", Beschreibung = "Zeigt Block 3 an " } }
            });

            RechteGruppe MitarbeiterRechte = db.RechteGruppe.Add(new RechteGruppe
            {
                Bezeichnung = "MitarbeiterRechte",
                Rechte = new List<Recht>() { new Recht() { Bezeichnung = "Testblock2", Beschreibung= "Zeigt Block 2 an " } }
            });

            db.SaveChanges();
        }


        private static void CreateBenutzerGruppenData(CatererContext db) {

            BenutzerGruppe Admin = db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = "Administratoren",
                RechteGruppe =  db.RechteGruppe.Single(x => x.Bezeichnung == "AdminRechte") 
            });

            BenutzerGruppe Mitarbeiter = db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = "Mitarbeiter",
                 RechteGruppe = db.RechteGruppe.Single(x => x.Bezeichnung == "MitarbeiterRechte")
            });

            BenutzerGruppe Caterer = db.BenutzerGruppe.Add(new BenutzerGruppe
            {
                Bezeichnung = "Caterer",
                RechteGruppe = db.RechteGruppe.Single(x => x.Bezeichnung == "CatererRechte")
            });

            db.SaveChanges();
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
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() {db.BenutzerGruppe.Single(x => x.Bezeichnung == "Caterer")}
                
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
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new  List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == "Mitarbeiter") }
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
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == "Administratoren") }
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
                PasswortZeitstempel = System.DateTime.Now,
                BenutzerGruppen = new List<BenutzerGruppe>() { db.BenutzerGruppe.Single(x => x.Bezeichnung == "Administratoren") }

            });

            db.SaveChanges();
        }
    }
}