using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;


namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_C2_1")]
    public class Userstory_C2_1 : TestInitialize
    {

        [Test]
        public void PersDatenÄndern()
        //T_C2-1_F01_B_001 
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            

            //Leeren aller Daten
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Firmanname, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs.Organisationsform))).SelectByIndex(0);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Straße_Nr, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.PLZ, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Ort, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs.Anrede))).SelectByIndex(0);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Nachname, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Ansprechpartner, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Telefon, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Fax, driver);
            TestTools.Daten_In_Textbox_Eingeben("", ObjektIDs.Internet, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs.Lieferumkreis))).SelectByIndex(0);

            TestTools.Element_Klicken("btnSpeichern", driver);

            //Fehlermeldungen überprüfen
            //Firma
            Assert.AreEqual(Fehlermeldung.Firma_Erforderlich, TestTools.Label_Text_Zurückgeben("Firmenname-error", driver));
            Assert.AreEqual(Fehlermeldung.Organisation_Erforderlich, TestTools.Label_Text_Zurückgeben("Organisationsform-error", driver));
            Assert.AreEqual(Fehlermeldung.Straße_Hausnummer_Erforderlich, TestTools.Label_Text_Zurückgeben("Stra_e-error", driver));
            Assert.AreEqual(Fehlermeldung.PLZ_Erforderlich, TestTools.Label_Text_Zurückgeben("Postleitzahl-error", driver));
            Assert.AreEqual(Fehlermeldung.Ort_Erforderlich, TestTools.Label_Text_Zurückgeben("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Fehlermeldung.Anrede_Erforderlich, TestTools.Label_Text_Zurückgeben("Anrede-error", driver));
            Assert.AreEqual(Fehlermeldung.Vorname_Erforderlich, TestTools.Label_Text_Zurückgeben("Vorname-error", driver));
            Assert.AreEqual(Fehlermeldung.Nachname_Erforderlich, TestTools.Label_Text_Zurückgeben("Nachname-error", driver));
            Assert.AreEqual(Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.Label_Text_Zurückgeben("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Fehlermeldung.Telefon_Erforderlich, TestTools.Label_Text_Zurückgeben("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.Label_Text_Zurückgeben("Lieferumkreis-error", driver));

            //Löschen unbestätigt abbrechen
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();

            TestTools.Selenium_Wartet_Eine_Sekunde(driver);

            //Prüfen ob alte Daten vorhanden sind
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));
            Assert.AreEqual("Holzweg 1", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Straße_Nr, driver));
            Assert.AreEqual("87654", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.PLZ, driver));
            Assert.AreEqual("Woodway", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Ort, driver));
            Assert.AreEqual("Herr", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Anrede, driver));
            Assert.AreEqual("Max", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Vorname, driver));
            Assert.AreEqual("Mustermann", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Nachname, driver));
            Assert.AreEqual("Chef", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Ansprechpartner, driver));
            Assert.AreEqual("01234 - 56789", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Telefon, driver));
            Assert.AreEqual("01234 - 99999", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Fax, driver));

            //Daten ändern
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Firmenname, ObjektIDs.Firmanname, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs.Organisationsform))).SelectByIndex(1);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Straße_Nr, ObjektIDs.Straße_Nr, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_PLZ, ObjektIDs.PLZ, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Ort, ObjektIDs.Ort, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs.Anrede))).SelectByIndex(1);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Vorname, ObjektIDs.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Name, ObjektIDs.Nachname, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Ansprechpartner, ObjektIDs.Ansprechpartner, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs.Telefon, driver);
            TestTools.Daten_In_Textbox_Eingeben(NutzerDaten.NutzerDaten_Telefon, ObjektIDs.Fax, driver);
            new SelectElement(driver.FindElement(By.Id(ObjektIDs.Lieferumkreis))).SelectByIndex(1);

            TestTools.Element_Klicken("btnSpeichern", driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();

            //Prüfen ob alte Daten geändert worden
            Assert.AreEqual(NutzerDaten.NutzerDaten_Firmenname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));
            Assert.AreEqual("Mensaverein", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Organisationsform, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Straße_Nr, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Straße_Nr, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_PLZ, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.PLZ, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Ort, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Ort, driver));
            Assert.AreEqual("Herr", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Anrede, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Vorname, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Vorname, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Name, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Nachname, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Ansprechpartner, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Ansprechpartner, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Telefon, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Telefon, driver));
            Assert.AreEqual(NutzerDaten.NutzerDaten_Telefon, TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Fax, driver));
            Assert.AreEqual("Bis 10 km", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Lieferumkreis, driver));

            TestTools.Selenium_Wartet_Eine_Sekunde(driver);

            //Daten wieder auf Ursprung zurück setzen
            TestTools.Daten_In_Textbox_Eingeben("AllYouCanEat GmbH", ObjektIDs.Firmanname, driver);
            TestTools.Daten_In_Textbox_Eingeben("Holzweg 1", ObjektIDs.Straße_Nr, driver);
            TestTools.Daten_In_Textbox_Eingeben("87654", ObjektIDs.PLZ, driver);
            TestTools.Daten_In_Textbox_Eingeben("Woodway", ObjektIDs.Ort, driver);
            TestTools.Daten_In_Textbox_Eingeben("Max", ObjektIDs.Vorname, driver);
            TestTools.Daten_In_Textbox_Eingeben("Mustermann", ObjektIDs.Nachname, driver);
            TestTools.Daten_In_Textbox_Eingeben("Chef", ObjektIDs.Ansprechpartner, driver);
            TestTools.Daten_In_Textbox_Eingeben("01234 - 56789", ObjektIDs.Telefon, driver);
            TestTools.Daten_In_Textbox_Eingeben("01234 - 99999", ObjektIDs.Fax, driver);

            TestTools.Element_Klicken("btnSpeichern", driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void PersDatenÄndern2()
        //T_C2-1_F02_B_001 
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();

            //Daten ändern über AGB Fußzeile abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.AGBFußzeile(driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über Datenschutzbestimmungen Fußzeile abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.DatenschutzFußzeile(driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über Kontakt Fußzeile abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.KontaktFußzeile(driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über Impressum Fußzeile abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.ImpressumFußzeile(driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über AGB Dropdown abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.AGBDropdownLogin(driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über Datenschutzbestimmungen Dropdown abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.DatenschutzDropdownLogin(driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über Kontakt Dropdown abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.KontaktDropdownLogin(driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über Impressum Dropdown abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.ImpressumDropdownLogin(driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über Eigene Daten abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            TestTools.Selenium_Wartet_Eine_Sekunde(driver);
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über StartButton abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            driver.Navigate().GoToUrl(baseURL);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            //Daten ändern über Logout abbrechen
            TestTools.Daten_In_Textbox_Eingeben("Test", ObjektIDs.Firmanname, driver);
            TestTools.Nutzer_Ausloggen(driver);
            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);
            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Eigene_Daten)).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.Textbox_Text_Zurückgeben(ObjektIDs.Firmanname, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

        [Test]
        public void PWÄndern()
        //T_C2-1_F03_B_001
        {
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //AGBs Fußzeile
            TestTools.AGBFußzeile(driver);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //Datenschutzbestimmungen Fußzeile
            TestTools.DatenschutzFußzeile(driver);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //AGBs Dropdown
            TestTools.AGBDropdownLogin(driver);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //Datenschutzbestimmungen Dropdown
            TestTools.DatenschutzDropdownLogin(driver);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //Kontakt Dropdown
            TestTools.KontaktDropdownLogin(driver);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //Impressum Dropdown
            TestTools.ImpressumDropdownLogin(driver);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);

            //StartButton
            TestTools.Element_Klicken(ObjektIDs.StartButton, driver);
            Assert.AreEqual(Hinweise.Startseite, driver.Title);
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            //Änderung durchführen
            TestTools.Nutzer_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name2, LoginDaten.PW1, driver);

            TestTools.Element_Klicken(ObjektIDs.Dropdown_Login, driver);
            driver.FindElement(By.LinkText(ObjektIDs.Dropdown_Login_PW_Ändern)).Click();
            Assert.AreEqual(Hinweise.PW_Ändern_Seite, TestTools.Label_Text_Zurückgeben(ObjektIDs.PW_Ändern_Seite, driver));
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld, driver);
            TestTools.Daten_In_Textbox_Eingeben(LoginDaten.PW2, ObjektIDs.Passwort_Feld_Bestätigung, driver);
            TestTools.Element_Klicken("Abschicken", driver);
            Assert.AreEqual(Hinweise.PW_Änderung_Erfolgreich, TestTools.Label_Text_Zurückgeben(ObjektIDs.Passwort_Feld, driver));

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);

        }

    }
}
