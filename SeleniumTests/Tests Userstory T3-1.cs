using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;



namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_T3_1")]
    public class Userstory_T3_1 : TestInitialize
    {

        [Test]
        public void MitarbeiterBearbeiten1()
        //T_T3-1_F01_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);
            
            //Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Mitarbeiter Editieren aufrufen
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);

            //Neuen Namen eingeben
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Speichern, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Prüfen ob Daten übernommen wurden
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.NutzerDaten_Vorname,TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname,driver));

            //Änderung Rückgängig machen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.Dummy_Daten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Speichern, driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);       

        }
        [Test]
        public void MitarbeiterBearbeiten2()
        //T_T3-1_F02_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Mitarbeiter Editieren aufrufen
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);

            //Neuen Namen eingeben
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Zurück_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Prüfen ob Daten nicht übernommen wurden
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten3()
        //T_T3-1_F03_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Mitarbeiter Editieren aufrufen
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);

            //Neuen Namen eingeben
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            //Änderung via Löschen-Menü abbrechen
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Löschen_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Abbrechen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Prüfen ob Daten nicht übernommen wurden
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten4()
        //T_T3-1_F04_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Mitarbeiter Editieren aufrufen
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);

            //Variante StartButton
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Eigene Daten
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter,driver));

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante PW Ändern
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite,driver));

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Ausloggen
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Mitarbeiter anzeigen
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Mitarbeiter hinzufügen
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Einstellungen
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Einstellungen, driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante AGB Dropdown
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.AGBDropdownLogin(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Datenschutz Dropdown
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.DatenschutzDropdownLogin(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Kontakt Dropdown
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.KontaktDropdownLogin(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Impressum Dropdown
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.ImpressumDropdownLogin(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante AGB Fußzeile
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.AGBFußzeile(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.DatenschutzFußzeile(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Kontakt Fußzeile
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.KontaktFußzeile(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Impressum Fußzeile
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);

            TestTools.ImpressumFußzeile(driver);

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten5()
        //T_T3-1_F06_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Mitarbeiter Editieren aufrufen
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Löschen Abbrechen
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Löschen_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Abbrechen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Löschen mit NEIN Abbrechen
            TestTools_Userstory_T3_1.Mitarbeiter_Vorname_Ändern(driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Löschen_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Nein, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten6()
        //T_T3-1_F07_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Mitarbeiter Details aufrufen
            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Zurückgehen zur Mitarbeiter Übersicht
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Zurück_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter bearbeiten über Details Seite
            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Daten_Bearbeiten, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Zurückgehen zur Details des Mitarbeiter
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Zurück_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter löschen über Details Seite
            driver.Navigate().GoToUrl("http://localhost:60003/Benutzer/Details/10");
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Daten_Bearbeiten, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Löschen_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Ja, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten7()
        //T_T3-1_F08_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Mitarbeiter Details aufrufen
            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Datenschutz Fußzeile
            TestTools.DatenschutzFußzeile(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante AGB Dropdown
            TestTools.AGBDropdownLogin(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Datenschutz Dropdown
            TestTools.DatenschutzDropdownLogin(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Kontakt Dropdown
            TestTools.KontaktDropdownLogin(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Impressum Dropdown
            TestTools.ImpressumDropdownLogin(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante StartButton
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Eigene Daten
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante PW Ändern
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Ausloggen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Mitarbeiter anzeigen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Mitarbeiter hinzufügen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            //Variante Einstellungen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Einstellungen, driver);

            TestTools_Userstory_T3_1.Details_Von_Mitarbeiter_Anzeigen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten8()
        //T_T3-1_F09_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Datenschutz Fußzeile
            TestTools.DatenschutzFußzeile(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante AGB Dropdown
            TestTools.AGBDropdownLogin(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Datenschutz Dropdown
            TestTools.DatenschutzDropdownLogin(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Kontakt Dropdown
            TestTools.KontaktDropdownLogin(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Impressum Dropdown
            TestTools.ImpressumDropdownLogin(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante StartButton
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Eigene Daten
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante PW Ändern
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Ausloggen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Mitarbeiter anzeigen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Mitarbeiter hinzufügen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            //Variante Einstellungen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Einstellungen, driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten9()
        //T_T3-1_F011_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Mitarbeiter Hinzufügen über Liste der Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante AGB Fußzeile
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.AGBFußzeile(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Datenschutz Fußzeile
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.DatenschutzFußzeile(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Kontakt Fußzeile
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.KontaktFußzeile(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Impressum Fußzeile
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.ImpressumFußzeile(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante AGB Dropdown
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.AGBDropdownLogin(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Datenschutz Dropdown
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.DatenschutzDropdownLogin(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Kontakt Dropdown
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.KontaktDropdownLogin(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.ImpressumDropdownLogin(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante StartButton
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Eigene Daten
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante PW Ändern
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Ausloggen
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Mitarbeiter anzeigen
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Mitarbeiter hinzufügen
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            //Variante Einstellungen
            TestTools_Userstory_T3_1.Email_Und_Telefonnummer_Eingeben(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Einstellungen, driver);

            TestTools_Userstory_T3_1.Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten10()
        //T_T3-1_F012_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Mitarbeiter Hinzufügen über Dropdown aufrufen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);

            //Fehlermeldungen überprüfen
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Fehlermeldung.Anrede_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Anrede, driver));
            Assert.AreEqual(Fehlermeldung.Vorname_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Vorname, driver));
            Assert.AreEqual(Fehlermeldung.Nachname_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Nachname, driver));
            Assert.AreEqual(Fehlermeldung.Email_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Email, driver));

            //Alle Felder Befüllen
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname,ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Nachname, ObjektIDs_NutzerDaten.Nachname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Anrede))).SelectByIndex(1);

            //Prüfen ob alle Fehlermeldungen verschwunden sind
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Anrede, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Vorname, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Nachname, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Email, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void MitarbeiterBearbeiten11()
        //T_T3-1_F013_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Bearbeiten von Mitarbeiter über Liste aller Mitarbeiter aufrufen
            TestTools_Userstory_T3_1.Liste_Aller_Mitarbeiter_Anzeigen(driver);
            TestTools_Userstory_T3_1.Bearbeiten_Von_Mitarbeiter_Anzeigen(driver);

            //Alle Felder Leeren
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Nachname, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Anrede))).SelectByIndex(0);

            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Speichern, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);

            //Fehlermeldungen überprüfen
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Fehlermeldung.Anrede_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Anrede, driver));
            Assert.AreEqual(Fehlermeldung.Vorname_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Vorname, driver));
            Assert.AreEqual(Fehlermeldung.Nachname_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Nachname, driver));

            //Alle Felder Befüllen
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Nachname, ObjektIDs_NutzerDaten.Nachname, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Anrede))).SelectByIndex(1);

            //Prüfen ob alle Fehlermeldungen verschwunden sind
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Anrede, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Vorname, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Nachname, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
    }
}
