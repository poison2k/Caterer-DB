using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Services;


namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_C2_3")]
    public class Userstory_C2_3 : TestInitialize
    {

        [Test]
        public void FrageAntwort1()
        //T_C2-3_F02_B_001
        {
            //Variante Knopf
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Caterer einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            //Fragebogen_Bearbeiten aufrufen
            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante StartButton
            TestTools.Element_Klicken(ObjektIDs_Allgemein.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante Eigene Daten
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Eigene_Daten)).Click();
            Assert.AreEqual(Hinweise.Eigene_Datenseite_Caterer, TestTools.Label_Text_Zurückgeben(ObjektIDs_DatenManagement.Eigene_Daten_Seite_Caterer, driver));

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante PW Ändern
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs_Dropdown.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs_Allgemein.PW_Ändern_Seite, driver));

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);
            
            //Variante Ausloggen
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login, driver);
            TestTools.Element_Klicken(ObjektIDs_Dropdown.Dropdown_Login_Ausloggen, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante AGB Dropdown
            TestTools.AGBDropdownLogin(driver);

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante Datenschutz Dropdown
            TestTools.DatenschutzDropdownLogin(driver);

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante Kontakt Dropdown
            TestTools.KontaktDropdownLogin(driver);

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante Impressum Dropdown
            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            TestTools.ImpressumDropdownLogin(driver);

            //Variante AGB Fußzeile
            TestTools.AGBFußzeile(driver);

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante Datenschutz Fußzeile
            TestTools.DatenschutzFußzeile(driver);

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante Kontakt Fußzeile
             TestTools.KontaktFußzeile(driver);

            TestTools_Userstory_C2_3.Fragebogen_Bearbeiten_Aufrufen(driver);

            //Variante Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }


      

    }
}
