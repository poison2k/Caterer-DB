using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Services;
using System;

namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_U1_3")]
    public class Userstory_U1_3 : TestInitialize
    {
        [Test]
        //T_U1-3_F01_B_001
        public void RegistrationsAufruf1()
        {
            //Variante Button
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken("registerLink", driver);

            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id(ObjektIDs_Allgemein.LoginButton));
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);

            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        //T_U1-3_F02_B_001
        public void RegistrationsSeitenLinks()
        {
            //Variante Links
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken("registerLink", driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //AGB
            TestTools.AGBFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Datenschutz
            TestTools.DatenschutzFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Kontakt
            TestTools.KontaktFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Impressum
            TestTools.ImpressumFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //AGBs bei Lesebestätigung
            TestTools.Element_Klicken("RegAGB", driver);
            Assert.AreEqual(Hinweise.AGBseite, TestTools.Label_Text_Zurückgeben("AllgemGeschäftsbedingungen", driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Datenschutz bei Lesebestätigung
            TestTools.Element_Klicken("RegDatenschutz", driver);
            Assert.AreEqual(Hinweise.Datenschutzseite, TestTools.Label_Text_Zurückgeben("Datenschutzbest", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        //T_U1-3_F03_B_001
        public void RegistrationsDropdownLinks()
        {
            //Variante Dropdown
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //AGB
            TestTools.AGBDropdownLogout(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Datenschutz
            TestTools.DatenschutzDropdownLogout(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Kontakt
            TestTools.KontaktDropdownLogout(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Impressum
            TestTools.ImpressumDropdownLogout(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        //T_U1-3_F11_B_001 & T_U1-3_F06_B_001
        public void RegistrationsFehlerEinverständniss()
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken("registerLink", driver);

            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Email befüllen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id(ObjektIDs_Allgemein.EMail_Feld)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.EMail_Feld)).SendKeys("projek1test@gmail.com");

            //Passwort befüllen
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld)).SendKeys("Start#22");

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld_Bestätigung)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld_Bestätigung)).SendKeys("Start#22");

            //Firmenname befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Firmanname)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Firmanname)).SendKeys(NutzerDaten.NutzerDaten_Firmenname);

            //Organisationsform wählen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Organisationsform)).SendKeys("Caterer");

            //Straße befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Straße_Nr)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Straße_Nr)).SendKeys(NutzerDaten.NutzerDaten_Straße_Nr);

            //PLZ befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.PLZ)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.PLZ)).SendKeys(NutzerDaten.NutzerDaten_PLZ);

            //Ort befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ort)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ort)).SendKeys(NutzerDaten.NutzerDaten_Ort);

            //Anrede wählen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Anrede)).SendKeys("Herr");

            //Vorname befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Vorname)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Vorname)).SendKeys(NutzerDaten.NutzerDaten_Vorname);

            //Nachname befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Nachname)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Nachname)).SendKeys(NutzerDaten.NutzerDaten_Nachname);

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ansprechpartner)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ansprechpartner)).SendKeys(NutzerDaten.NutzerDaten_Ansprechpartner);

            //Telefon befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Telefon)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Telefon)).SendKeys(NutzerDaten.NutzerDaten_Telefon);

            //Fax befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Fax)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Fax)).SendKeys(NutzerDaten.NutzerDaten_Telefon);

            //Internetadresse befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Internet)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Internet)).SendKeys("www.test.test");

            //Umkreis wählen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Lieferumkreis)).SendKeys("Bis 30 km");

            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Speichern, driver);

            TestTools.Selenium_Wartet_Eine_Sekunde(driver);

            Assert.AreEqual(Fehlermeldung.Datenschutzbestimmungen_Zustimmung, TestTools.Label_Text_Zurückgeben("DatenschutzValidation-error", driver));
            Assert.AreEqual(Fehlermeldung.AGB_Zustimmung, TestTools.Label_Text_Zurückgeben("AGBValidation-error", driver));

            //AGBs akzeptieren
            TestTools.Element_Klicken("AGBs", driver);
            //AGBs akzeptieren
            TestTools.Element_Klicken("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.Element_Klicken("WeitergabeVonDaten", driver);

            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Speichern, driver);

            TestTools.Selenium_Wartet_Eine_Sekunde(driver);

            Assert.AreEqual("Registrierung erfolgreich", TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Login mit korrekten Daten durchführen und testen der Fehlermeldung für fehlende Email-Verification
            //T_U1-3_F06_B_001
            TestTools.User_Login_Durchführen("projek1test@gmail.com", "Start#22", driver);
            Assert.AreEqual(Hinweise.Reg_Email_Verifikation_Fehlt, TestTools.Label_Text_Zurückgeben("RegMailValidation-error", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }
    }
}