using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;


namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_M4_4")]
    public class Userstory_M4_4 : TestInitialize
    {
        [Test]
        public void FragenBearbeiten1()
        //T_M4-4_F01_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Neue Fragen Übersicht aufrufen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Variante veröffentlichte Fragen anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);

            //Variante Kategorien anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Aufrufen(driver);

            //Variante Kategorien hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void FragenBearbeiten4()
        //T_M4-4_F04_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Frage hinzufügen aufrufen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Variante neue Fragen anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);

            //Variante Kategorien anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Aufrufen(driver);

            //Variante Kategorien hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void FragenBearbeiten5()
        //T_M4-4_F05_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Fragendetails aufrufen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Variante neue Fragen anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);

            //Variante Kategorien anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Aufrufen(driver);

            //Variante Kategorien hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Details_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void FragenBearbeiten7()
        //T_M4-4_F07_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Frage bearbeiten aufrufen
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);

            //Auf Änderung prüfen und dann ändern
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Variante neue Fragen anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);

            //Variante Kategorien anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Aufrufen(driver);

            //Variante Kategorien hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void FragenBearbeiten8()
        //T_M4-4_F08_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Fragenübersicht aufrufen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Name3, LoginDaten.PW1, driver);

            //Variante neue Fragen anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Neu_Aufrufen(driver);

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Fragen_Erstellen_Aufrufen(driver);

            //Variante Kategorien anzeigen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Aufrufen(driver);

            //Variante Kategorien hinzufügen
            TestTools_Userstory_M4_4.Fragebogen_Fragenübersicht_Aufrufen(driver);
            TestTools_Userstory_M4_4.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

    }
}
