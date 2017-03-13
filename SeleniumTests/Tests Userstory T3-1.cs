using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;
using System;


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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            
            //Mitarbeiter Editieren aufrufen
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Neuen Namen eingeben
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Speichern, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Prüfen ob Daten übernommen wurden
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.NutzerDaten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter Editieren aufrufen
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));
           
            //Neuen Namen eingeben
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Zurück_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Prüfen ob Daten nicht übernommen wurden
            driver.Navigate().GoToUrl(MAEditURL);
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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter Editieren aufrufen
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Neuen Namen eingeben
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            //Änderung via Löschen-Menü abbrechen
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Löschen_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Abbrechen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Prüfen ob Daten nicht übernommen wurden

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter Editieren aufrufen
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Variante StartButton
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Eigene Daten
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter,driver));

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante PW Ändern
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite,driver));

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Ausloggen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Mitarbeiter anzeigen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Mitarbeiter hinzufügen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Einstellungen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Einstellungen, driver);
            
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante AGB Dropdown
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.AGBDropdownLogin(driver);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Datenschutz Dropdown
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.DatenschutzDropdownLogin(driver);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Kontakt Dropdown
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.KontaktDropdownLogin(driver);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Impressum Dropdown
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.ImpressumDropdownLogin(driver);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante AGB Fußzeile
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.AGBFußzeile(driver);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Datenschutz Fußzeile
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.DatenschutzFußzeile(driver);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Kontakt Fußzeile
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.KontaktFußzeile(driver);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Impressum Fußzeile
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);

            TestTools.ImpressumFußzeile(driver);

            driver.Navigate().GoToUrl(MAEditURL);
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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter Editieren aufrufen
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Variante Löschen Abbrechen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Löschen_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Abbrechen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.Dummy_Daten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Vorname, driver));

            //Variante Löschen mit NEIN Abbrechen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Löschen_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Nein, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            driver.Navigate().GoToUrl(MAEditURL);
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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter Details aufrufen
            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Zurückgehen zur Mitarbeiter Übersicht
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Zurück_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter bearbeiten über Details Seite
            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));
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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter Details aufrufen
            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Datenschutz Fußzeile
            TestTools.DatenschutzFußzeile(driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante AGB Dropdown
            TestTools.AGBDropdownLogin(driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Datenschutz Dropdown
            TestTools.DatenschutzDropdownLogin(driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Kontakt Dropdown
            TestTools.KontaktDropdownLogin(driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Impressum Dropdown
            TestTools.ImpressumDropdownLogin(driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));
            
            //Variante StartButton
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));
            
            //Variante Eigene Daten
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante PW Ändern
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Ausloggen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Mitarbeiter anzeigen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Mitarbeiter hinzufügen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

            //Variante Einstellungen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Einstellungen, driver);

            driver.Navigate().GoToUrl(MADetailURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));

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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Datenschutz Fußzeile
            TestTools.DatenschutzFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante AGB Dropdown
            TestTools.AGBDropdownLogin(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Datenschutz Dropdown
            TestTools.DatenschutzDropdownLogin(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Kontakt Dropdown
            TestTools.KontaktDropdownLogin(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Impressum Dropdown
            TestTools.ImpressumDropdownLogin(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante StartButton
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Eigene Daten
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante PW Ändern
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Ausloggen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Mitarbeiter anzeigen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Mitarbeiter hinzufügen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Variante Einstellungen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Einstellungen, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

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
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante AGB Fußzeile
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.AGBFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Datenschutz Fußzeile
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.DatenschutzFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Kontakt Fußzeile
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.KontaktFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Impressum Fußzeile
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.ImpressumFußzeile(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante AGB Dropdown
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.AGBDropdownLogin(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Datenschutz Dropdown
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.DatenschutzDropdownLogin(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Kontakt Dropdown
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.KontaktDropdownLogin(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Impressum Dropdown
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.ImpressumDropdownLogin(driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante StartButton
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Eigene Daten
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Mitarbeiter, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Mitarbeiter, driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante PW Ändern
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Ausloggen
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Mitarbeiter anzeigen
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Mitarbeiter hinzufügen
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAHinzufügen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            //Variante Einstellungen
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Einstellungen, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Mitarbeiter_Anlegen_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
    }
}
