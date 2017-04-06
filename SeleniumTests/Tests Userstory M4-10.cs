using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;


namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_M4_10")]
    public class Userstory_M4_10 : TestInitialize
    {

        [Test]
        public void CatererDatenBearbeiten1()
        //T_M4-10_F02_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            //Als Mitarbeiter einloggen
            TestTools.User_Login_Durchführen(LoginDaten.Mitarbeiter, LoginDaten.PW1, driver);

            //Caterer bearbeiten aufrufen
            TestTools_Userstory_M4_6.Caterer_Bearbeiten_Anzeigen(driver);

            //Daten wieder befüllen
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Firmanname, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Organisationsform))).SelectByIndex(0);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Straße_Nr, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.PLZ, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Ort, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Anrede))).SelectByIndex(0);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Nachname, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Ansprechpartner, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Telefon, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Fax, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs_NutzerDaten.Internet, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Lieferumkreis))).SelectByIndex(0);
            TestTools.Element_Klicken(ObjektIDs_Allgemein.Speichern, driver);

            //Fehlermeldungen überprüfen
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(Fehlermeldung.Firma_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Firmenname, driver));
            Assert.AreEqual(Fehlermeldung.Organisation_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Organisation, driver));
            Assert.AreEqual(Fehlermeldung.Straße_Hausnummer_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Straße_Hnr, driver));
            Assert.AreEqual(Fehlermeldung.PLZ_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.PLZ, driver));
            Assert.AreEqual(Fehlermeldung.Ort_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Ort, driver));
            Assert.AreEqual(Fehlermeldung.Anrede_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Anrede, driver));
            Assert.AreEqual(Fehlermeldung.Vorname_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Vorname, driver));
            Assert.AreEqual(Fehlermeldung.Nachname_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Nachname, driver));
            Assert.AreEqual(Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Ansprechpartner, driver));
            Assert.AreEqual(Fehlermeldung.Telefon_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Telefon, driver));
            Assert.AreEqual(Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.Label_Text_Zurückgeben(ObjektIDs_Fehlermeldungen.Lieferumkreis, driver));

            //Daten wieder befüllen
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Firmenname, ObjektIDs_NutzerDaten.Firmanname, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Organisationsform))).SelectByIndex(1);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Straße_Nr, ObjektIDs_NutzerDaten.Straße_Nr, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_PLZ, ObjektIDs_NutzerDaten.PLZ, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Ort, ObjektIDs_NutzerDaten.Ort, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Anrede))).SelectByIndex(1);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs_NutzerDaten.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Nachname, ObjektIDs_NutzerDaten.Nachname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Ansprechpartner, ObjektIDs_NutzerDaten.Ansprechpartner, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs_NutzerDaten.Telefon, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Fax, ObjektIDs_NutzerDaten.Fax, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Internetadresse, ObjektIDs_NutzerDaten.Internet, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs_NutzerDaten.Lieferumkreis))).SelectByIndex(1);

            //Prüfen ob alle Fehlermeldungen verschwunden sind
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Anrede, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Vorname, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Nachname, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Email, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Firmenname, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Organisation, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Straße_Hnr, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.PLZ, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Ort, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Ansprechpartner, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Telefon, driver));
            Assert.AreEqual(false, TestTools.Fehlermeldung_Sichtbarkeitsprüfung(ObjektIDs_Fehlermeldungen.Lieferumkreis, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        
    }
}
