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
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            
            //Mitarbeiter Editieren aufrufen
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Neuen Namen eingeben
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_Allgemein.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_Allgemein.Vorname, driver);
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Speichern, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Prüfen ob Daten übernommen wurden
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(NutzerDaten.NutzerDaten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.Vorname, driver));

            //Änderung Rückgängig machen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_Allgemein.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben("Sebastian", ObjektIDs_Allgemein.Vorname, driver);
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
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter Editieren aufrufen
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));
           
            //Neuen Namen eingeben
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_Allgemein.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_Allgemein.Vorname, driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Zurück_Button, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Prüfen ob Daten nicht übernommen wurden
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual("Sebastian", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.Vorname, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        //[Test]
        //public void MitarbeiterBearbeiten3()
        ////T_T3-1_F03_B_001 
        //{

        //    TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

        //    //Als Admin anmelden
        //    TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

        //    //Liste der Mitarbeiter aufrufen
        //    TestTools.Element_Klicken(ObjektIDs_Allgemein.Dropdown_Konfiguration_Login, driver);
        //    TestTools.Element_Klicken(ObjektIDs_Allgemein.DropdownMAAnzeigen, driver);
        //    Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

        //    //Mitarbeiter Editieren aufrufen
        //    driver.Navigate().GoToUrl(MAEditURL);
        //    Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

        //    //Neuen Namen eingeben
        //    TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_Allgemein.Vorname, driver);
        //    TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_Allgemein.Vorname, driver);

        //    //Änderung via Löschen-Menü abbrechen
        //    TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
        //    Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Löschen_Seite, driver));
        //    TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Abbrechen, driver);
        //    Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

        //    //Prüfen ob Daten nicht übernommen wurden
        //    driver.Navigate().GoToUrl(MAEditURL);
        //    Assert.AreEqual("Sebastian", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.Vorname, driver));

        //    TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        //}
        [Test]
        public void MitarbeiterBearbeiten4()
        //T_T3-1_F04_B_001 
        {

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Admin anmelden
            TestTools.User_Login_Durchführen(LoginDaten.Admin, LoginDaten.AdminPW, driver);

            //Liste der Mitarbeiter aufrufen
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));

            //Mitarbeiter Editieren aufrufen
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));

            //Variante StartButton
            //Neuen Namen eingeben
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_Allgemein.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_Allgemein.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual("Sebastian", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.Vorname, driver));

            //Variante StartButton
            //Neuen Namen eingeben
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_Allgemein.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_Allgemein.Vorname, driver);

            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual("Sebastian", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.Vorname, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

    }
}
