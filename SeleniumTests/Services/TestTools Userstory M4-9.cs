using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;


namespace SeleniumTests.Services
{
    public static class TestTools_Userstory_M4_9
    {

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

        public static void Fragebogen_Kategorie_Hinzufügen_Inkl_Kategoriename_Eingeben(IWebDriver driver)
        {

            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Kategorie_Hinzufügen, driver);
            Assert.AreEqual(Hinweise.Fragen_Kategorie_Hinzufügen, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_hinzufügen_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben("Lecker", ObjektIDs_FragebogenManagement.Kategorie_Formulieren_Textbox, driver);

        }

        public static void Kategorie_Bearbeiten_Seite(IWebDriver driver)
        {

            driver.Navigate().GoToUrl("http://caterer-schulverpflegung-niedersachsen.de/Kategorie/Edit/3");
            Assert.AreEqual(Hinweise.Fragen_Kategorie_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_Bearbeiten_Seite, driver));

        }

        public static void Kategorie_Bearbeiten_Seite_Auf_Keine_Kategorieänderung_Prüfen_Und_Ändern(IWebDriver driver)
        {

            driver.Navigate().GoToUrl("http://caterer-schulverpflegung-niedersachsen.de/Kategorie/Edit/3");
            Assert.AreEqual(Hinweise.Fragen_Kategorie_Bearbeiten, TestTools.Label_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_Bearbeiten_Seite, driver));
            Assert.AreEqual(ObjektIDs_FragebogenManagement.Kategorie_Dummykategorie, TestTools.Textbox_Text_Zurückgeben(ObjektIDs_FragebogenManagement.Kategorie_Formulieren_Textbox, driver));
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_FragebogenManagement.Kategorie_Formulieren_Textbox, driver);

        }




    }
    }

