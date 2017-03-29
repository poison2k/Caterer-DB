using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumTests.Services
{
    public static class TestTools_Userstory_M4_6
    {
        public static void Caterer_Übersicht_Aufrufen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Caterer, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Caterer_Anzeigen, driver);
            Assert.AreEqual(Hinweise.Catererseite, TestTools.Label_Text_Zurückgeben(ObjektIDs_CatererManagement.Caterer_Übersicht_Seite, driver));
        }

        public static void Caterer_Bearbeiten_Anzeigen(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:60003/Benutzer/EditCaterer/35");
            Assert.AreEqual(Hinweise.Caterer_Bearbeiten_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_CatererManagement.Caterer_Bearbeiten_Seite, driver));
        }

        public static void Details_Von_Caterer_Anzeigen(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:60003/Benutzer/DetailsCaterer/1");
            Assert.AreEqual(Hinweise.Caterer_Details_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_CatererManagement.Caterer_Details_Seite, driver));
        }

        public static void Caterer_Bearbeiten_Seite_Firmanamen_Prüfen_Und_Ändern(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:60003/Benutzer/EditCaterer/1");
            Assert.AreEqual(Hinweise.Caterer_Bearbeiten_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_CatererManagement.Caterer_Bearbeiten_Seite, driver));

            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs_NutzerDaten.Firmanname, driver));
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Firmenname, ObjektIDs_NutzerDaten.Firmanname, driver);
        }

        public static void Caterer_Hinzufügen_Seite_Firmanamen_Eintragen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Caterer, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Caterer_Hinzufügen, driver);
            Assert.AreEqual(Hinweise.Caterer_Hinzufügen_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_CatererManagement.Caterer_Hinzufügen_Seite, driver));

            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Firmenname, ObjektIDs_NutzerDaten.Firmanname, driver);
        }
    }
}