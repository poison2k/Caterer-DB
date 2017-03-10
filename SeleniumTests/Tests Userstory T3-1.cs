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
            
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs.DropdownMAAnzeigen, driver);
            Assert.AreEqual("Mitarbeiter", TestTools.Label_Text_Zurückgeben(ObjektIDs.Mitarbeiter_Seite, driver));
            
            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual("Mitarbeiter bearbeiten", TestTools.Label_Text_Zurückgeben(ObjektIDs.Mitarbeiter_Bearbeiten, driver));

            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Vorname, driver);
            TestTools.Element_Klicken(ObjektIDs.Speichern, driver);
            Assert.AreEqual("Mitarbeiter bearbeiten", TestTools.Label_Text_Zurückgeben(ObjektIDs.Mitarbeiter_Bearbeiten, driver));

            driver.Navigate().GoToUrl(MAEditURL);
            Assert.AreEqual("Mitarbeiter bearbeiten", TestTools.Label_Text_Zurückgeben(ObjektIDs.Mitarbeiter_Bearbeiten, driver));



        }

        }
}
