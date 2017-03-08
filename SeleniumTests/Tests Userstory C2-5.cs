using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Services;


namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_C2_5")]
    public class Userstory_C2_5 : TestInitialize
    {

        [Test]
        public void DatenLöschen1()
        //T_C2-5_F02_B_001 
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();

            TestTools.Element_Klicken("LöschenButton", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben("LöschenBest", driver));

            TestTools.Element_Klicken("btnModalCancel", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Eigene_Datenseite, TestTools.Label_Text_Zurückgeben("RegSeite", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void DatenLöschen2()
        //T_C2-5_F03_B_001 
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();

            TestTools.Element_Klicken("LöschenButton", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben("LöschenBest", driver));

            TestTools.Element_Klicken("LöschenCancel", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Eigene_Datenseite, TestTools.Label_Text_Zurückgeben("RegSeite", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void DatenLöschen3()
        //T_C2-5_F04_B_001 
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name2, LoginDaten.PW2, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();

            TestTools.Element_Klicken("LöschenButton", driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Account_Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben("LöschenBest", driver));

            TestTools.Element_Klicken("btnModalDelete", driver);
            Assert.AreEqual(Hinweise.Account_Gelöscht, TestTools.Label_Text_Zurückgeben("Gelöscht", driver));

            TestTools.User_Login_Durchführen(LoginDaten.Name2, LoginDaten.PW2, driver);
            Assert.AreEqual(Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.Label_Text_Zurückgeben("error2", driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

    }
}
