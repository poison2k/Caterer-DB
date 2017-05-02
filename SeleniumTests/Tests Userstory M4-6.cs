using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;

namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_M4_6")]
    public class Userstory_M4_6 : TestInitialize
    {
        [Test]
        public void CatererAnlegen1()
        //T_M4-6_F04_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Caterer Übersicht aufrufen
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);

            //Caterer Bearbeiten aufrufen
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Anzeigen(driver);

            //Daten bearbeiten
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Firmenname, ObjektIDs_NutzerDaten.Firmanname, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Organisationsform))).SelectByIndex(1);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Straße_Nr, ObjektIDs_NutzerDaten.Straße_Nr, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_PLZ, ObjektIDs_NutzerDaten.PLZ, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Ort, ObjektIDs_NutzerDaten.Ort, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Anrede))).SelectByIndex(1);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Nachname, ObjektIDs_NutzerDaten.Nachname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Ansprechpartner, ObjektIDs_NutzerDaten.Ansprechpartner, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Fax, ObjektIDs_NutzerDaten.Fax, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Internetadresse, ObjektIDs_NutzerDaten.Internet, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Lieferumkreis))).SelectByIndex(1);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Speichern, driver);

            //Caterer Bearbeiten aufrufen
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Anzeigen(driver);

            //Pürfen ob Daten übernommen wurden
            Assert.AreEqual(NutzerDaten.NutzerDaten_Firmenname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));
            Assert.AreEqual("Mensaverein", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Organisationsform, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Straße_Nr, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Straße_Nr, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_PLZ, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.PLZ, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Ort, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Ort, driver));
            Assert.AreEqual("Herr", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Anrede, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Nachname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Nachname, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Ansprechpartner, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Ansprechpartner, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Telefon, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Telefon, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Telefon, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Fax, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Internetadresse, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Internet, driver));
            Assert.AreEqual("5", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Lieferumkreis, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void CatererAnlegen2()
        //T_M4-6_F05_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Caterer Übersicht aufrufen
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Variante Fragen anzeigen
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Anzeigen_Neu, driver);
            Assert.AreEqual(Hinweise.Fragen_Übersicht_Neu, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Übersicht_Neu, driver));

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_6.Caterer_Übersicht_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragen_Hinzufügen, driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void CatererAnlegen3()
        //T_M4-6_F06_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Caterer Details aufrufen
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Variante Fragen anzeigen
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Anzeigen_Neu, driver);
            Assert.AreEqual(Hinweise.Fragen_Übersicht_Neu, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Übersicht_Neu, driver));

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_6.Details_Von_Caterer_Anzeigen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragen_Hinzufügen, driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void CatererAnlegen4()
        //T_M4-6_F07_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Variante AGB Fußzeile
            driver.Navigate().GoToUrl("http://caterer-schulverpflegung-niedersachsen.de/Benutzer/EditCaterer/1");
            Assert.AreEqual(Hinweise.Caterer_Bearbeiten_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_CatererManagement.Caterer_Bearbeiten_Seite, driver));

            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Firmenname, ObjektIDs_NutzerDaten.Firmanname, driver);

            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Variante Fragen anzeigen
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Anzeigen_Neu, driver);
            Assert.AreEqual(Hinweise.Fragen_Übersicht_Neu, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Übersicht_Neu, driver));

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragen_Hinzufügen, driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void CatererAnlegen5()
        //T_M4-6_F08_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Variante AGB Fußzeile
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Variante Fragen anzeigen
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Anzeigen_Neu, driver);
            Assert.AreEqual(Hinweise.Fragen_Übersicht_Neu, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Übersicht_Neu, driver));

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_6.Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragen_Hinzufügen, driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }
    }
}