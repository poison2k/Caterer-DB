using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Services;

namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_M4_9")]
    public class Userstory_M4_9 : TestInitialize
    {
        [Test]
        public void Kategorien1()
        //T_M4-9_F01_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Administrator einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Kategorie Übersicht aufrufen
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Aufrufen(driver);

            TestTools.Element_Klicken(ObjektIDs_FragebogenManagement.Kategorie_Neu_Button, driver);
            Assert.AreEqual(Hinweise.Fragen_Kategorie_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_hinzufügen_Seite, driver));

            //Kategorie Hinzufügen aufrufen
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);

            //Neue Kategorie erstellen
            TestTools.Daten_In_Textbox_Eingeben("Lecker", ObjektIDs_FragebogenManagement.Kategorie_Formulieren_Textbox, driver);
            TestTools.Element_Klicken(ObjektIDs_FragebogenManagement.Kategorie_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Fragen_Kategorie_Übersicht, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_Übersicht_Seite, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void Kategorien3()
        //T_M4-9_F03_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Administrator einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Kategorie Übersicht aufrufen
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Caterer, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Variante Fragen anzeigen
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Anzeigen_Neu, driver);
            Assert.AreEqual(Hinweise.Fragen_Übersicht_Neu, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Übersicht_Neu, driver));

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_9.Fragebogen_Kategorie_Hinzufügen(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragen_Hinzufügen, driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void Kategorien4()
        //T_M4-9_F04_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Administrator einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Kategorie bearbeiten aufrufen
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite(driver);

            //Kategorie umbenennen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_FragebogenManagement.Kategorie_Formulieren_Textbox, driver);
            TestTools.Daten_In_Textbox_Eingeben(ObjektIDs_FragebogenManagement.Kategorie_Dummykategorie, ObjektIDs_FragebogenManagement.Kategorie_Formulieren_Textbox, driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Speichern, driver);

            //Kategorie bearbeiten aufrufen
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite(driver);
            Assert.AreEqual(ObjektIDs_FragebogenManagement.Kategorie_Dummykategorie, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_Formulieren_Textbox, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void Kategorien5()
        //T_M4-9_F05_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Administrator einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Kategorie bearbeiten aufrufen
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite(driver);

            //Kategorie umbenennen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_FragebogenManagement.Kategorie_Formulieren_Textbox, driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);
            TestTools.DatenschutzFußzeile(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);
            TestTools.KontaktFußzeile(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);
            TestTools.ImpressumFußzeile(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);
            TestTools.AGBDropdownLogin(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);
            TestTools.DatenschutzDropdownLogin(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);
            TestTools.KontaktDropdownLogin(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);
            TestTools.ImpressumDropdownLogin(driver);

            //Variante StartButton
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            //Variante Eigene Daten
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Caterer, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            //Variante PW Ändern
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            //Variante Ausloggen
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Variante Fragen anzeigen
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Anzeigen_Neu, driver);
            Assert.AreEqual(Hinweise.Fragen_Übersicht_Neu, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Übersicht_Neu, driver));

            //Variante Fragen hinzufügen
            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragen_Hinzufügen, driver);

            TestTools_Userstory_M4_9.Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }
    }
}