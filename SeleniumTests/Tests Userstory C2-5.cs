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

            TestTools.User_Login_Durchführen(LoginDaten.Caterer1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();

            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben("LöschenBest", driver));

            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Nein, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Caterer, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void DatenLöschen2()
        //T_C2-5_F03_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Caterer1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();

            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Button, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Löschen_Bestätigen, TestTools.Label_Text_Zurückgeben("LöschenBest", driver));

            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Löschen_Abbrechen, driver);
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Caterer, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }
    }
}