using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Services;
using System;


namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_U1_2")]
    public class Userstory_U1_2 : TestInitialize
    {

        [Test]
        public void LoginTest1()
        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken(ObjektIDs.LoginButton, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.Name1, ObjektIDs.EMail_Feld_Login, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW1, ObjektIDs.Passwort_Feld, driver);
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void LoginTest2()
        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
        {
            //Variante Dropdown

            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void LoginTest_FalschesPW()
        //T_U1-2_ALF_B_05
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, "Start#21", driver);
            Assert.AreEqual(Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.Label_Text_Zurückgeben("error2", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void LoginTest_FalscheEmail()
        //T_U1-2_ALF_B_06
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen("caterer@test.d", LoginDaten.PW1, driver);
            Assert.AreEqual(Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.Label_Text_Zurückgeben("error2", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void LoginTest_OhnePW()
        //T_U1-2_ALF_B_07
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.Element_Klicken(ObjektIDs.LoginButton, driver);
            TestTools.User_Login_Durchführen(LoginDaten.Name1, "", driver);
            Assert.AreEqual(Fehlermeldung.PW_Erforderlich, TestTools.Label_Text_Zurückgeben("error1", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void LoginTest_OhneEmail()
        //T_U1-2_ALF_B_08
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen("", LoginDaten.PW1, driver);
            Assert.AreEqual(Fehlermeldung.Email_Erforderlich, TestTools.Label_Text_Zurückgeben("Email-error", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

    }
}
