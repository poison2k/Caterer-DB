using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Services;

namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_C2_1")]
    public class Userstory_C2_1 : TestInitialize
    {
        [Test]
        public void PersDatenÄndern2()
        //T_C2-1_F02_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Caterer1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();

            //Daten ändern über AGB Fußzeile abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.AGBFußzeile(driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über Datenschutzbestimmungen Fußzeile abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.DatenschutzFußzeile(driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über Kontakt Fußzeile abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.KontaktFußzeile(driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über Impressum Fußzeile abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.ImpressumFußzeile(driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über AGB Dropdown abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.AGBDropdownLogin(driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über Datenschutzbestimmungen Dropdown abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.DatenschutzDropdownLogin(driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über Kontakt Dropdown abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.KontaktDropdownLogin(driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über Impressum Dropdown abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.ImpressumDropdownLogin(driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über Eigene Daten abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über StartButton abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            driver.Navigate().GoToUrl(baseURL);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            //Daten ändern über Logout abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs_NutzerDaten.Firmanname, driver);
            TestTools.Nutzer_Ausloggen(driver);
            TestTools.User_Login_Durchführen(LoginDaten.Caterer1, LoginDaten.PW1, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }
    }
}