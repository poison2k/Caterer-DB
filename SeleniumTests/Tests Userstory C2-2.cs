using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Services;
using System;


namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_C2_2")]
    public class Userstory_C2_2 : TestInitialize
    {

        [Test]
        public void PWVergessen1()
        //T_C2-2_F02_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            driver.Navigate().GoToUrl(PWRequestURL);

            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));

            //AGBs Fußzeile
            TestTools.AGBFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Datenschutzbestimmungen Fußzeile
            TestTools.DatenschutzFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //AGBs Dropdown
            TestTools.AGBDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Datenschutzbestimmungen Dropdown
            TestTools.DatenschutzDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Kontakt Dropdown
            TestTools.KontaktDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Impressum Dropdown
            TestTools.ImpressumDropdownLogout(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void PWVergessen2()
        //T_C2-2_F03_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            driver.Navigate().GoToUrl(PWRequestURL);

            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));

            //StartButton
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id(ObjektIDs_Allgemein.LoginButton));
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Login Dropdown
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_LoginButton, driver);
            Assert.AreEqual("Login", TestTools.Label_Text_Zurückgeben("LoginPage", driver));
            driver.Navigate().GoToUrl(PWRequestURL);

            //Registrierung Dropdown
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void PWVergessen3()
        //T_C2-2_F04_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //AGBs Fußzeile
            TestTools.AGBFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Datenschutzbestimmungen Fußzeile
            TestTools.DatenschutzFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //AGBs Dropdown
            TestTools.AGBDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Datenschutzbestimmungen Dropdown
            TestTools.DatenschutzDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Kontakt Dropdown
            TestTools.KontaktDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Impressum Dropdown
            TestTools.ImpressumDropdownLogout(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void PWVergessen5()
        //T_C2-2_F05_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //StartButton
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id(ObjektIDs_Allgemein.LoginButton));
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Login Dropdown
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_LoginButton, driver);
            Assert.AreEqual("Login", TestTools.Label_Text_Zurückgeben("LoginPage", driver));
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));
            TestTools.Daten_In_Textbox_Eingeben("Test@test.de", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Bestätigung, TestTools.Label_Text_Zurückgeben("RegErfolg", driver));

            //Registrierung Dropdown
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Logout_RegisterButton, driver);
            Assert.AreEqual(Hinweise.Registrierungsseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }
        [Test]
        public void PWVergessen6()
        //T_C2-2_F11_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_Allgemein.EMail_Feld, driver));

            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Fehlermeldung.Email_Erforderlich, TestTools.Label_Text_Zurückgeben("PWRecoveryFehler", driver));

            TestTools.Daten_In_Textbox_Eingeben("projekt10test", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Fehlermeldung.Email_Erforderlich, TestTools.Label_Text_Zurückgeben("PWRecoveryFehler", driver));

            TestTools.Daten_In_Textbox_Eingeben("projekt10test@", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Fehlermeldung.Email_Erforderlich, TestTools.Label_Text_Zurückgeben("PWRecoveryFehler", driver));

            TestTools.Daten_In_Textbox_Eingeben("projekt10test@gmail", ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Element_Klicken("PWRecoveryAbschicken", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Fehlermeldung.Email_Ungültig, TestTools.Label_Text_Zurückgeben("PWRecoveryFehler", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

    }
}
