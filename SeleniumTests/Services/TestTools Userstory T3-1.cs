using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumTests.Services
{
    public static class TestTools_Userstory_T3_1
    {
        public static void Liste_Aller_Mitarbeiter_Anzeigen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
        }

        public static void Mitarbeiter_Hinzufügen_Über_Liste_Der_Mitarbeiter_Anzeigen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Konfiguration_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.DropdownMAAnzeigen, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Seite, driver));
            TestTools.Element_Klicken(ObjektIDs_DatenManagement.Neuer_Mitarbeiter, driver);
            Assert.AreEqual(Hinweise.Mitarbeiter_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Hinzufügen, driver));
        }

        public static void Details_Von_Mitarbeiter_Anzeigen(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:60003/Benutzer/Details/6");
            Assert.AreEqual(Hinweise.Mitarbeiter_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Details, driver));
        }

        public static void Bearbeiten_Von_Mitarbeiter_Anzeigen(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:60003/Benutzer/Edit/6");
            Assert.AreEqual(Hinweise.Mitarbeiter_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Mitarbeiter_Bearbeiten, driver));
        }

        public static void Mitarbeiter_Vorname_Ändern(IWebDriver driver)
        {
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
        }

        public static void Email_Und_Telefonnummer_Eingeben(IWebDriver driver)
        {
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Email, ObjektIDs_Allgemein.EMail_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);
        }
    }
}