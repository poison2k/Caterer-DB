using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumTests.Services
{
    public static class TestTools_Userstory_C2_3
    {
        public static void Fragebogen_Bearbeiten_Aufrufen(IWebDriver driver)
        {
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Manage_Fragebogen_Bearbeiten, driver);
            Assert.AreEqual(true, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_FragebogenManagement.Fragebogen, driver));
        }
    }
}