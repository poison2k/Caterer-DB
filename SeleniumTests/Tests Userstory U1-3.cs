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
        //T_U1-3_F04_B_001 
        public void RegistrationsFehler()
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken("registerLink", driver);

            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools.Element_Klicken("btnSpeichern", driver);

            //Account
            Assert.AreEqual(Fehlermeldung.Email_Erforderlich, TestTools.Label_Text_Zurückgeben("Mail-error", driver));
            Assert.AreEqual(Fehlermeldung.PW_Erforderlich, TestTools.Label_Text_Zurückgeben("Passwort-error", driver));
            Assert.AreEqual(Fehlermeldung.PW_Wiederholung_Erforderlich, TestTools.Label_Text_Zurückgeben("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual(Fehlermeldung.Firma_Erforderlich, TestTools.Label_Text_Zurückgeben("Firmenname-error", driver));
            Assert.AreEqual(Fehlermeldung.Organisation_Erforderlich, TestTools.Label_Text_Zurückgeben("Organisationsform-error", driver));
            Assert.AreEqual(Fehlermeldung.Straße_Hausnummer_Erforderlich, TestTools.Label_Text_Zurückgeben("Stra_e-error", driver));
            Assert.AreEqual(Fehlermeldung.PLZ_Erforderlich, TestTools.Label_Text_Zurückgeben("Postleitzahl-error", driver));
            Assert.AreEqual(Fehlermeldung.Ort_Erforderlich, TestTools.Label_Text_Zurückgeben("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Fehlermeldung.Anrede_Erforderlich, TestTools.Label_Text_Zurückgeben("Anrede-error", driver));
            Assert.AreEqual(Fehlermeldung.Vorname_Erforderlich, TestTools.Label_Text_Zurückgeben("Vorname-error", driver));
            Assert.AreEqual(Fehlermeldung.Nachname_Erforderlich, TestTools.Label_Text_Zurückgeben("Nachname-error", driver));
            Assert.AreEqual(Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.Label_Text_Zurückgeben("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Fehlermeldung.Telefon_Erforderlich, TestTools.Label_Text_Zurückgeben("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.Label_Text_Zurückgeben("Lieferumkreis-error", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        //T_U1-3_F05_B_001 
        public void RegistrationsFehler2()
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken("registerLink", driver);

            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools.Element_Klicken("btnSpeichern", driver);

            //Account
            Assert.AreEqual(Fehlermeldung.Email_Erforderlich, TestTools.Label_Text_Zurückgeben("Mail-error", driver));
            Assert.AreEqual(Fehlermeldung.PW_Erforderlich, TestTools.Label_Text_Zurückgeben("Passwort-error", driver));
            Assert.AreEqual(Fehlermeldung.PW_Wiederholung_Erforderlich, TestTools.Label_Text_Zurückgeben("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual(Fehlermeldung.Firma_Erforderlich, TestTools.Label_Text_Zurückgeben("Firmenname-error", driver));
            Assert.AreEqual(Fehlermeldung.Organisation_Erforderlich, TestTools.Label_Text_Zurückgeben("Organisationsform-error", driver));
            Assert.AreEqual(Fehlermeldung.Straße_Hausnummer_Erforderlich, TestTools.Label_Text_Zurückgeben("Stra_e-error", driver));
            Assert.AreEqual(Fehlermeldung.PLZ_Erforderlich, TestTools.Label_Text_Zurückgeben("Postleitzahl-error", driver));
            Assert.AreEqual(Fehlermeldung.Ort_Erforderlich, TestTools.Label_Text_Zurückgeben("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Fehlermeldung.Anrede_Erforderlich, TestTools.Label_Text_Zurückgeben("Anrede-error", driver));
            Assert.AreEqual(Fehlermeldung.Vorname_Erforderlich, TestTools.Label_Text_Zurückgeben("Vorname-error", driver));
            Assert.AreEqual(Fehlermeldung.Nachname_Erforderlich, TestTools.Label_Text_Zurückgeben("Nachname-error", driver));
            Assert.AreEqual(Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.Label_Text_Zurückgeben("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Fehlermeldung.Telefon_Erforderlich, TestTools.Label_Text_Zurückgeben("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.Label_Text_Zurückgeben("Lieferumkreis-error", driver));

            //Email befüllen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id(ObjektIDs_Allgemein.EMail_Feld)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.EMail_Feld)).SendKeys("XXX@xxx.xx");
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Mail-error", driver));

            //Passwort befüllen
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld)).SendKeys("12345678");
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Passwort-error", driver));

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld_Bestätigung)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld_Bestätigung)).SendKeys("12345678");
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("PasswortVerification-error", driver));

            //Firmenname befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Firmanname)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Firmanname)).SendKeys(NutzerDaten.NutzerDaten_Firmenname);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Firmenname-error", driver));

            //Organisationsform wählen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Organisationsform)).SendKeys("Caterer");
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Organisationsform-error", driver));

            //Straße befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Straße_Nr)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Straße_Nr)).SendKeys(NutzerDaten.NutzerDaten_Straße_Nr);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Stra_e-error", driver));

            //PLZ befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.PLZ)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.PLZ)).SendKeys(NutzerDaten.NutzerDaten_PLZ);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Postleitzahl-error", driver));

            //Ort befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ort)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ort)).SendKeys(NutzerDaten.NutzerDaten_Ort);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Ort-error", driver));

            //Anrede wählen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Anrede)).SendKeys("Herr");
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Anrede-error", driver));

            //Vorname befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Vorname)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Vorname)).SendKeys(NutzerDaten.NutzerDaten_Vorname);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Vorname-error", driver));

            //Nachname befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Nachname)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Nachname)).SendKeys(NutzerDaten.NutzerDaten_Name);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Nachname-error", driver));

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ansprechpartner)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ansprechpartner)).SendKeys(NutzerDaten.NutzerDaten_Ansprechpartner);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("FunktionAnsprechpartner-error", driver));

            //Telefon befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Telefon)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Telefon)).SendKeys(NutzerDaten.NutzerDaten_Telefon);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Telefon-error", driver));

            //Umkreis wählen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Lieferumkreis)).SendKeys("Bis 30 km");
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung("Lieferumkreis-error", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        //T_U1-3_F08_B_001 
        public void RegistrationsFehlerDoppelMail()
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken("registerLink", driver);

            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            //Email befüllen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id(ObjektIDs_Allgemein.EMail_Feld)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.EMail_Feld)).SendKeys(LoginDaten.Name1);

            //Passwort befüllen
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld)).SendKeys("12345678");

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld_Bestätigung)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld_Bestätigung)).SendKeys("12345678");

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
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Nachname)).SendKeys(NutzerDaten.NutzerDaten_Name);

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ansprechpartner)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Ansprechpartner)).SendKeys(NutzerDaten.NutzerDaten_Ansprechpartner);

            //Telefon befüllen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Telefon)).Clear();
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Telefon)).SendKeys(NutzerDaten.NutzerDaten_Telefon);

            //Umkreis wählen
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Lieferumkreis)).SendKeys("Bis 30 km");

            //AGBs akzeptieren
            TestTools.Element_Klicken("AGBs", driver);
            //AGBs akzeptieren
            TestTools.Element_Klicken("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.Element_Klicken("WeitergabeVonDaten", driver);

            TestTools.Element_Klicken("btnSpeichern", driver);

            Assert.AreEqual(Fehlermeldung.Email_Bereits_Vorhanden, TestTools.Label_Text_Zurückgeben("VallidationSummary", driver));

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
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld)).SendKeys("12345678");

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld_Bestätigung)).Clear();
            driver.FindElement(By.Id(ObjektIDs_Allgemein.Passwort_Feld_Bestätigung)).SendKeys("12345678");

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
            driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Nachname)).SendKeys(NutzerDaten.NutzerDaten_Name);

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

            TestTools.Element_Klicken("btnSpeichern", driver);

            TestTools.Selenium_Wartet_Eine_Sekunde(driver);

            Assert.AreEqual(Fehlermeldung.Datenschutzbestimmungen_Zustimmung, TestTools.Label_Text_Zurückgeben("DatenschutzValidation-error", driver));
            Assert.AreEqual(Fehlermeldung.AGB_Zustimmung, TestTools.Label_Text_Zurückgeben("AGBValidation-error", driver));

            //AGBs akzeptieren
            TestTools.Element_Klicken("AGBs", driver);
            //AGBs akzeptieren
            TestTools.Element_Klicken("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.Element_Klicken("WeitergabeVonDaten", driver);


            TestTools.Element_Klicken("btnSpeichern", driver);

            TestTools.Selenium_Wartet_Eine_Sekunde(driver);

            Assert.AreEqual("Registrierung erfolgreich", TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Login mit korrekten Daten durchführen und testen der Fehlermeldung für fehlende Email-Verification
            //T_U1-3_F06_B_001
            TestTools.User_Login_Durchführen("projek1test@gmail.com", "12345678", driver);
            Assert.AreEqual(Hinweise.Reg_Email_Verifikation_Fehlt, TestTools.Label_Text_Zurückgeben("RegMailValidation-error", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

    }
}
