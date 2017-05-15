using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumTests.Services
{
    public static class TestTools_Userstory_M4_4
    {
        public static void Fragebogen_Fragenübersicht_Aufrufen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Anzeigen_Öffentlicht, driver);
            Assert.AreEqual(Hinweise.Fragen_Übersicht_Öffentlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Übersicht_Öffentlich, driver));
        }

        public static void Fragebogen_Fragenübersicht_Neu_Aufrufen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Anzeigen_Neu, driver);
            Assert.AreEqual(Hinweise.Fragen_Übersicht_Neu, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Übersicht_Neu, driver));
        }

        public static void Fragebogen_Fragen_Erstellen_Aufrufen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragen_Hinzufügen, driver);
            Assert.AreEqual(Hinweise.Fragen_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Erstellen, driver));
        }

        public static void Fragebogen_Kategorie_Aufrufen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Kategorie_Anzeigen, driver);
            Assert.AreEqual(Hinweise.Fragen_Kategorie_Übersicht, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_Übersicht_Seite, driver));
        }

        public static void Fragebogen_Kategorie_Hinzufügen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Kategorie_Hinzufügen, driver);
            Assert.AreEqual(Hinweise.Fragen_Kategorie_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_hinzufügen_Seite, driver));
        }

        public static void Fragebogen_Frage_Bearbeiten_Aufrufen(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://caterer-schulverpflegung-niedersachsen.de/Frage/Edit/8");
            Assert.AreEqual(Hinweise.Fragen_Neu_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Neu_Bearbeiten, driver));
        }

        public static void Fragebogen_Frage_Bearbeiten_Auf_Keine_Änderung_Prüfen_Und_Dann_Ändern(IWebDriver driver)
        {
            Assert.AreEqual(ObjektIDs_FragebogenManagement.Frage_Musterfrage, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Frage_Formulieren_Textbox, driver));
            TestTools.Daten_In_Textbox_Eingeben(ObjektIDs_FragebogenManagement.Frage_Dummyfrage, ObjektIDs_FragebogenManagement.Frage_Formulieren_Textbox, driver);
        }

        public static void Fragebogen_Fragen_Details_Aufrufen(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://caterer-schulverpflegung-niedersachsen.de/Frage/Details/1");
            Assert.AreEqual(Hinweise.Fragen_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Details, driver));
        }

        public static void Fragebogen_Frage_Bearbeiten_Aufrufen_Zum_Löschen(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://caterer-schulverpflegung-niedersachsen.de/Frage/Edit/8");
            Assert.AreEqual(Hinweise.Fragen_Neu_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Neu_Bearbeiten, driver));
        }

        public static void Fragebogen_Veröffentlichte_Frage_Details_Aufrufen_Zum_Löschen(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://caterer-schulverpflegung-niedersachsen.de/Frage/DetailsVeroeffentlicht/9");
            Assert.AreEqual(Hinweise.Fragen_Veröffentlicht_Details, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Fragen_Veröffentlicht_Details, driver));
        }
    }
}