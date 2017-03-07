using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;
using System;
using System.Text; 

namespace SeleniumTests
{
    [TestFixture]
    public class TestChrome
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private string PWRequestURL;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:60003/";
            PWRequestURL = "http://localhost:60003/Account/PasswordRequest";
            verificationErrors = new StringBuilder();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [SetUp]
        public void SetupTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
        }

        [TearDown]
        public void TeardownTest()
        {
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////---SPRINT 1---//////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void LoginTest1()
        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.DatenEingeben(Services.LoginDaten.Name1, "Email", driver);
            TestTools.DatenEingeben(Services.LoginDaten.PW1, "Passwort", driver);
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            TestTools.TestEnde(driver);
        }

        [Test]
        public void LoginTest2()
        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
        {
            //Variante Dropdown

            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            TestTools.TestEnde(driver);
        }

        [Test]
        public void LoginTest_FalschesPW()
        //T_U1-2_ALF_B_05
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, "Start#21", driver);
            Assert.AreEqual(Services.Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.IDText�berpr�fen("error2", driver));
            
            TestTools.TestEnde(driver);
        }

        [Test]
        public void LoginTest_FalscheEmail()
        //T_U1-2_ALF_B_06
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben("caterer@test.d", Services.LoginDaten.PW1, driver);
            Assert.AreEqual(Services.Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.IDText�berpr�fen("error2", driver));

            TestTools.TestEnde(driver);

        }

        [Test]
        public void LoginTest_OhnePW()
        //T_U1-2_ALF_B_07
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, "", driver);
            Assert.AreEqual(Services.Fehlermeldung.PW_Erforderlich, TestTools.IDText�berpr�fen("error1", driver));
            
            TestTools.TestEnde(driver);

        }

        [Test]
        public void LoginTest_OhneEmail()
        //T_U1-2_ALF_B_08
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben("", Services.LoginDaten.PW1, driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDText�berpr�fen("Email-error", driver));

            TestTools.TestEnde(driver);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void KontaktAufruf1()
        //T_U1-4_AL_B_01
        {
            //Variante Knopf
            TestTools.TestStart(driver);

            TestTools.KontaktFu�zeile(driver);

            TestTools.TestEnde(driver);

        }

        [Test]
        public void KontaktAufruf2()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.TestStart(driver);

            TestTools.KontaktDropdownLogout(driver);

            TestTools.TestEnde(driver);
        }

        [Test]
        public void KontaktAufruf3()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Login
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.KontaktDropdownLogin(driver);

            TestTools.TestEnde(driver);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void DatenschutzAufruf1()
        //T_U1-6_AL_B_01
        {
            //Variante Knopf
            TestTools.TestStart(driver);

            TestTools.DatenschutzFu�zeile(driver);

            TestTools.TestEnde(driver);
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf2()
        {
            //Variante Dropdown Logout
            TestTools.TestStart(driver);

            TestTools.DatenschutzDropdownLogout(driver);

            TestTools.TestEnde(driver);
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf3()
        {
            //Variante Dropdown Login
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.DatenschutzDropdownLogin(driver);

            TestTools.TestEnde(driver);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void AGBAufruf1()
        //T_U1-7_AL_B_01
        {
            //Variante Knopf
            TestTools.TestStart(driver);

            TestTools.AGBFu�zeile(driver);

            TestTools.TestEnde(driver);

        }

        [Test]
        public void AGBAufruf2()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.TestStart(driver);

            TestTools.AGBDropdownLogout(driver);

            TestTools.TestEnde(driver);

        }

        [Test]
        public void AGBAufruf3()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Login
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.AGBDropdownLogin(driver);

            TestTools.TestEnde(driver);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////---SPRINT 2---//////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        //T_U1-3_F01_B_001 
        public void RegistrationsAufruf1()
        {
            //Variante Button
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
            
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F02_B_001 
        public void RegistrationsSeitenLinks()
        {
            //Variante Links
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //AGB
            TestTools.AGBFu�zeile(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Datenschutz
            TestTools.DatenschutzFu�zeile(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Kontakt
            TestTools.KontaktFu�zeile(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Impressum
            TestTools.ImpressumFu�zeile(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //AGBs bei Lesebest�tigung
            TestTools.ElementKlick("RegAGB", driver);
            Assert.AreEqual(Services.Hinweise.AGBseite, TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Datenschutz bei Lesebest�tigung
            TestTools.ElementKlick("RegDatenschutz", driver);
            Assert.AreEqual(Services.Hinweise.Datenschutzseite, TestTools.IDText�berpr�fen("Datenschutzbest", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F03_B_001 
        public void RegistrationsDropdownLinks()
        {
            //Variante Dropdown
            TestTools.TestStart(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //AGB
            TestTools.AGBDropdownLogout(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Datenschutz
            TestTools.DatenschutzDropdownLogout(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Kontakt
            TestTools.KontaktDropdownLogout(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Impressum
            TestTools.ImpressumDropdownLogout(driver);

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F04_B_001 
        public void RegistrationsFehler()
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.ElementKlick("btnSpeichern", driver);

            //Account
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDText�berpr�fen("Mail-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PW_Erforderlich, TestTools.IDText�berpr�fen("Passwort-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PW_Wiederholung_Erforderlich, TestTools.IDText�berpr�fen("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual(Services.Fehlermeldung.Firma_Erforderlich, TestTools.IDText�berpr�fen("Firmenname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Organisation_Erforderlich, TestTools.IDText�berpr�fen("Organisationsform-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Stra�e_Hausnummer_Erforderlich, TestTools.IDText�berpr�fen("Stra_e-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PLZ_Erforderlich, TestTools.IDText�berpr�fen("Postleitzahl-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ort_Erforderlich, TestTools.IDText�berpr�fen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Services.Fehlermeldung.Anrede_Erforderlich, TestTools.IDText�berpr�fen("Anrede-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Vorname_Erforderlich, TestTools.IDText�berpr�fen("Vorname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Nachname_Erforderlich, TestTools.IDText�berpr�fen("Nachname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.IDText�berpr�fen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Services.Fehlermeldung.Telefon_Erforderlich, TestTools.IDText�berpr�fen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Services.Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.IDText�berpr�fen("Lieferumkreis-error", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F05_B_001 
        public void RegistrationsFehler2()
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.ElementKlick("btnSpeichern", driver);

            //Account
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDText�berpr�fen("Mail-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PW_Erforderlich, TestTools.IDText�berpr�fen("Passwort-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PW_Wiederholung_Erforderlich, TestTools.IDText�berpr�fen("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual(Services.Fehlermeldung.Firma_Erforderlich, TestTools.IDText�berpr�fen("Firmenname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Organisation_Erforderlich, TestTools.IDText�berpr�fen("Organisationsform-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Stra�e_Hausnummer_Erforderlich, TestTools.IDText�berpr�fen("Stra_e-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PLZ_Erforderlich, TestTools.IDText�berpr�fen("Postleitzahl-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ort_Erforderlich, TestTools.IDText�berpr�fen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Services.Fehlermeldung.Anrede_Erforderlich, TestTools.IDText�berpr�fen("Anrede-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Vorname_Erforderlich, TestTools.IDText�berpr�fen("Vorname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Nachname_Erforderlich, TestTools.IDText�berpr�fen("Nachname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.IDText�berpr�fen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Services.Fehlermeldung.Telefon_Erforderlich, TestTools.IDText�berpr�fen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Services.Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.IDText�berpr�fen("Lieferumkreis-error", driver));

            //Email bef�llen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys("XXX@xxx.xx");
            Assert.AreEqual(false, TestTools.FehlerID("Mail-error", driver));

            //Passwort bef�llen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");
            Assert.AreEqual(false, TestTools.FehlerID("Passwort-error", driver));

            //Passwort wiederholen bef�llen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");
            Assert.AreEqual(false, TestTools.FehlerID("PasswortVerification-error", driver));

            //Firmenname bef�llen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys(Services.NutzerDaten.NutzerDaten_Firmenname);
            Assert.AreEqual(false, TestTools.FehlerID("Firmenname-error", driver));

            //Organisationsform w�hlen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");
            Assert.AreEqual(false, TestTools.FehlerID("Organisationsform-error", driver));

            //Stra�e bef�llen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys(Services.NutzerDaten.NutzerDaten_Stra�e_Nr);
            Assert.AreEqual(false, TestTools.FehlerID("Stra_e-error", driver));

            //PLZ bef�llen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys(Services.NutzerDaten.NutzerDaten_PLZ);
            Assert.AreEqual(false, TestTools.FehlerID("Postleitzahl-error", driver));

            //Ort bef�llen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys(Services.NutzerDaten.NutzerDaten_Ort);
            Assert.AreEqual(false, TestTools.FehlerID("Ort-error", driver));

            //Anrede w�hlen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");
            Assert.AreEqual(false, TestTools.FehlerID("Anrede-error", driver));

            //Vorname bef�llen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys(Services.NutzerDaten.NutzerDaten_Vorname);
            Assert.AreEqual(false, TestTools.FehlerID("Vorname-error", driver));

            //Nachname bef�llen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys(Services.NutzerDaten.NutzerDaten_Name);
            Assert.AreEqual(false, TestTools.FehlerID("Nachname-error", driver));

            //FunktionAnprechpartner bef�llen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys(Services.NutzerDaten.NutzerDaten_Ansprechpartner);
            Assert.AreEqual(false, TestTools.FehlerID("FunktionAnsprechpartner-error", driver));

            //Telefon bef�llen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys(Services.NutzerDaten.NutzerDaten_Telefon);
            Assert.AreEqual(false, TestTools.FehlerID("Telefon-error", driver));

            //Umkreis w�hlen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");
            Assert.AreEqual(false, TestTools.FehlerID("Lieferumkreis-error", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F08_B_001 
        public void RegistrationsFehlerDoppelMail()
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Email bef�llen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys(Services.LoginDaten.Name1);

            //Passwort bef�llen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");

            //Passwort wiederholen bef�llen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");

            //Firmenname bef�llen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys(Services.NutzerDaten.NutzerDaten_Firmenname);

            //Organisationsform w�hlen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");

            //Stra�e bef�llen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys(Services.NutzerDaten.NutzerDaten_Stra�e_Nr);

            //PLZ bef�llen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys(Services.NutzerDaten.NutzerDaten_PLZ);

            //Ort bef�llen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys(Services.NutzerDaten.NutzerDaten_Ort);

            //Anrede w�hlen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");

            //Vorname bef�llen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys(Services.NutzerDaten.NutzerDaten_Vorname);

            //Nachname bef�llen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys(Services.NutzerDaten.NutzerDaten_Name);

            //FunktionAnprechpartner bef�llen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys(Services.NutzerDaten.NutzerDaten_Ansprechpartner);

            //Telefon bef�llen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys(Services.NutzerDaten.NutzerDaten_Telefon);

            //Umkreis w�hlen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");

            //AGBs akzeptieren
            TestTools.ElementKlick("AGBs", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("WeitergabeVonDaten", driver);

            TestTools.ElementKlick("btnSpeichern", driver);

            Assert.AreEqual(Services.Fehlermeldung.Email_Bereits_Vorhanden, TestTools.IDText�berpr�fen("VallidationSummary", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F11_B_001 & T_U1-3_F06_B_001
        public void RegistrationsFehlerEinverst�ndniss()
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            //Email bef�llen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys("projek1test@gmail.com");

            //Passwort bef�llen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");

            //Passwort wiederholen bef�llen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");

            //Firmenname bef�llen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys(Services.NutzerDaten.NutzerDaten_Firmenname);

            //Organisationsform w�hlen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");

            //Stra�e bef�llen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys(Services.NutzerDaten.NutzerDaten_Stra�e_Nr);

            //PLZ bef�llen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys(Services.NutzerDaten.NutzerDaten_PLZ);

            //Ort bef�llen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys(Services.NutzerDaten.NutzerDaten_Ort);

            //Anrede w�hlen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");

            //Vorname bef�llen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys(Services.NutzerDaten.NutzerDaten_Vorname);

            //Nachname bef�llen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys(Services.NutzerDaten.NutzerDaten_Name);

            //FunktionAnprechpartner bef�llen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys(Services.NutzerDaten.NutzerDaten_Ansprechpartner);

            //Telefon bef�llen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys(Services.NutzerDaten.NutzerDaten_Telefon);

            //Fax bef�llen
            driver.FindElement(By.Id("Fax")).Clear();
            driver.FindElement(By.Id("Fax")).SendKeys(Services.NutzerDaten.NutzerDaten_Telefon);

            //Internetadresse bef�llen
            driver.FindElement(By.Id("Internetadresse")).Clear();
            driver.FindElement(By.Id("Internetadresse")).SendKeys("www.test.test");

            //Umkreis w�hlen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");

            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.EineSekundeWarten(driver);

            Assert.AreEqual(Services.Fehlermeldung.Datenschutzbestimmungen_Zustimmung, TestTools.IDText�berpr�fen("DatenschutzValidation-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.AGB_Zustimmung, TestTools.IDText�berpr�fen("AGBValidation-error", driver));

            //AGBs akzeptieren
            TestTools.ElementKlick("AGBs", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("WeitergabeVonDaten", driver);


            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.EineSekundeWarten(driver);

            Assert.AreEqual("Registrierung erfolgreich", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Login mit korrekten Daten durchf�hren und testen der Fehlermeldung f�r fehlende Email-Verification
            //T_U1-3_F06_B_001
            TestTools.LoginDatenEingeben("projek1test@gmail.com", "12345678", driver);
            Assert.AreEqual(Services.Hinweise.Reg_Email_Verifikation_Fehlt, TestTools.IDText�berpr�fen("RegMailValidation-error", driver));

            TestTools.TestEnde(driver);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void PersDaten�ndern()
        //T_C2-1_F01_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();


            //Leeren aller Daten
            TestTools.DatenEingeben("", "Firmenname", driver);
            new SelectElement(driver.FindElement(By.Id("Organisationsform"))).SelectByIndex(0);
            TestTools.DatenEingeben("", "Stra_e", driver);
            TestTools.DatenEingeben("", "Postleitzahl", driver);
            TestTools.DatenEingeben("", "Ort", driver);
            new SelectElement(driver.FindElement(By.Id("Anrede"))).SelectByIndex(0);
            TestTools.DatenEingeben("", "Vorname", driver);
            TestTools.DatenEingeben("", "Nachname", driver);
            TestTools.DatenEingeben("", "FunktionAnsprechpartner", driver);
            TestTools.DatenEingeben("", "Telefon", driver);
            TestTools.DatenEingeben("", "Fax", driver);
            TestTools.DatenEingeben("", "Internetadresse", driver);
            new SelectElement(driver.FindElement(By.Id("Lieferumkreis"))).SelectByIndex(0);

            TestTools.ElementKlick("btnSpeichern", driver);

            //Fehlermeldungen �berpr�fen
            //Firma
            Assert.AreEqual(Services.Fehlermeldung.Firma_Erforderlich, TestTools.IDText�berpr�fen("Firmenname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Organisation_Erforderlich, TestTools.IDText�berpr�fen("Organisationsform-error", driver));
            Assert.AreEqual("Das Feld \"Stra�e\" ist erforderlich.", TestTools.IDText�berpr�fen("Stra_e-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PLZ_Erforderlich, TestTools.IDText�berpr�fen("Postleitzahl-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ort_Erforderlich, TestTools.IDText�berpr�fen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Services.Fehlermeldung.Anrede_Erforderlich, TestTools.IDText�berpr�fen("Anrede-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Vorname_Erforderlich, TestTools.IDText�berpr�fen("Vorname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Nachname_Erforderlich, TestTools.IDText�berpr�fen("Nachname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.IDText�berpr�fen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Services.Fehlermeldung.Telefon_Erforderlich, TestTools.IDText�berpr�fen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Services.Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.IDText�berpr�fen("Lieferumkreis-error", driver));

            //L�schen unbest�tigt abbrechen
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.EineSekundeWarten(driver);

            //Pr�fen ob alte Daten vorhanden sind
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));
            Assert.AreEqual("Holzweg 1", TestTools.TextboxText�berpr�fen("Stra_e", driver));
            Assert.AreEqual("87654", TestTools.TextboxText�berpr�fen("Postleitzahl", driver));
            Assert.AreEqual("Woodway", TestTools.TextboxText�berpr�fen("Ort", driver));
            Assert.AreEqual("Herr", TestTools.TextboxText�berpr�fen("Anrede", driver));
            Assert.AreEqual("Max", TestTools.TextboxText�berpr�fen("Vorname", driver));
            Assert.AreEqual("Mustermann", TestTools.TextboxText�berpr�fen("Nachname", driver));
            Assert.AreEqual("Chef", TestTools.TextboxText�berpr�fen("FunktionAnsprechpartner", driver));
            Assert.AreEqual("01234 - 56789", TestTools.TextboxText�berpr�fen("Telefon", driver));
            Assert.AreEqual("01234 - 99999", TestTools.TextboxText�berpr�fen("Fax", driver));

            //Daten �ndern
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Firmenname, "Firmenname", driver);
            new SelectElement(driver.FindElement(By.Id("Organisationsform"))).SelectByIndex(1);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Stra�e_Nr, "Stra_e", driver);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_PLZ, "Postleitzahl", driver);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Ort, "Ort", driver);
            new SelectElement(driver.FindElement(By.Id("Anrede"))).SelectByIndex(1);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Vorname, "Vorname", driver);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Name, "Nachname", driver);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Ansprechpartner, "FunktionAnsprechpartner", driver);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Telefon, "Telefon", driver);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Telefon, "Fax", driver);
            new SelectElement(driver.FindElement(By.Id("Lieferumkreis"))).SelectByIndex(1);

            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            //Pr�fen ob alte Daten ge�ndert worden
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Firmenname, TestTools.TextboxText�berpr�fen("Firmenname", driver));
            Assert.AreEqual("Mensaverein", TestTools.TextboxText�berpr�fen("Organisationsform", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Stra�e_Nr, TestTools.TextboxText�berpr�fen("Stra_e", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_PLZ, TestTools.TextboxText�berpr�fen("Postleitzahl", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Ort, TestTools.TextboxText�berpr�fen("Ort", driver));
            Assert.AreEqual("Herr", TestTools.TextboxText�berpr�fen("Anrede", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Vorname, TestTools.TextboxText�berpr�fen("Vorname", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Name, TestTools.TextboxText�berpr�fen("Nachname", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Ansprechpartner, TestTools.TextboxText�berpr�fen("FunktionAnsprechpartner", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Telefon, TestTools.TextboxText�berpr�fen("Telefon", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Telefon, TestTools.TextboxText�berpr�fen("Fax", driver));
            Assert.AreEqual("Bis 10 km", TestTools.TextboxText�berpr�fen("Lieferumkreis", driver));

            TestTools.EineSekundeWarten(driver);

            //Daten wieder auf Ursprung zur�ck setzen
            TestTools.DatenEingeben("AllYouCanEat GmbH", "Firmenname", driver);
            TestTools.DatenEingeben("Holzweg 1", "Stra_e", driver);
            TestTools.DatenEingeben("87654", "Postleitzahl", driver);
            TestTools.DatenEingeben("Woodway", "Ort", driver);
            TestTools.DatenEingeben("Max", "Vorname", driver);
            TestTools.DatenEingeben("Mustermann", "Nachname", driver);
            TestTools.DatenEingeben("Chef", "FunktionAnsprechpartner", driver);
            TestTools.DatenEingeben("01234 - 56789", "Telefon", driver);
            TestTools.DatenEingeben("01234 - 99999", "Fax", driver);

            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.TestEnde(driver);

        }

        [Test]
        public void PersDaten�ndern2()
        //T_C2-1_F02_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            //Daten �ndern �ber AGB Fu�zeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.AGBFu�zeile(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Datenschutzbestimmungen Fu�zeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.DatenschutzFu�zeile(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Kontakt Fu�zeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.KontaktFu�zeile(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Impressum Fu�zeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ImpressumFu�zeile(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber AGB Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.AGBDropdownLogin(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Datenschutzbestimmungen Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.DatenschutzDropdownLogin(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Kontakt Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.KontaktDropdownLogin(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Impressum Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ImpressumDropdownLogin(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Eigene Daten abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber StartButton abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            driver.Navigate().GoToUrl(baseURL);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Logout abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.NutzerAusloggen(driver);
            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            TestTools.TestEnde(driver);

        }

        [Test]
        public void PWV�ndern()
        //T_C2-1_F03_B_001
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //AGBs Fu�zeile
            TestTools.AGBFu�zeile(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Datenschutzbestimmungen Fu�zeile
            TestTools.DatenschutzFu�zeile(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Kontakt Fu�zeile
            TestTools.KontaktFu�zeile(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Impressum Fu�zeile
            TestTools.ImpressumFu�zeile(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //AGBs Dropdown
            TestTools.AGBDropdownLogin(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Datenschutzbestimmungen Dropdown
            TestTools.DatenschutzDropdownLogin(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Kontakt Dropdown
            TestTools.KontaktDropdownLogin(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Impressum Dropdown
            TestTools.ImpressumDropdownLogin(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            //�nderung durchf�hren
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben("caterer1@test.de", Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);
            TestTools.ElementKlick("Abschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Erfolgreich, TestTools.IDText�berpr�fen("Passwort", driver));

            TestTools.TestEnde(driver);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void PWVergessen1()
        //T_C2-2_F02_B_001
        {
            TestTools.TestStart(driver);

            driver.Navigate().GoToUrl(PWRequestURL);

            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));

            //AGBs Fu�zeile
            TestTools.AGBFu�zeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Datenschutzbestimmungen Fu�zeile
            TestTools.DatenschutzFu�zeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Kontakt Fu�zeile
            TestTools.KontaktFu�zeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Impressum Fu�zeile
            TestTools.ImpressumFu�zeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //AGBs Dropdown
            TestTools.AGBDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Datenschutzbestimmungen Dropdown
            TestTools.DatenschutzDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Kontakt Dropdown
            TestTools.KontaktDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Impressum Dropdown
            TestTools.ImpressumDropdownLogout(driver);

            TestTools.TestEnde(driver);

        }

        [Test]
        public void PWVergessen2()
        //T_C2-2_F03_B_001
        {
            TestTools.TestStart(driver);

            driver.Navigate().GoToUrl(PWRequestURL);

            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Login Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            Assert.AreEqual("Login", TestTools.IDText�berpr�fen("LoginPage", driver));
            driver.Navigate().GoToUrl(PWRequestURL);

            //Registrierung Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        public void PWVergessen3()
        //T_C2-2_F04_B_001
        {
            TestTools.TestStart(driver);

            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //AGBs Fu�zeile
            TestTools.AGBFu�zeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Datenschutzbestimmungen Fu�zeile
            TestTools.DatenschutzFu�zeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Kontakt Fu�zeile
            TestTools.KontaktFu�zeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Impressum Fu�zeile
            TestTools.ImpressumFu�zeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //AGBs Dropdown
            TestTools.AGBDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Datenschutzbestimmungen Dropdown
            TestTools.DatenschutzDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Kontakt Dropdown
            TestTools.KontaktDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Impressum Dropdown
            TestTools.ImpressumDropdownLogout(driver);

            TestTools.TestEnde(driver);

        }
        [Test]
        public void PWVergessen5()
        //T_C2-2_F05_B_001
        {
            TestTools.TestStart(driver);

            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Login Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            Assert.AreEqual("Login", TestTools.IDText�berpr�fen("LoginPage", driver));
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_�nderung_Best�tigung, TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Registrierung Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        public void PWVergessen6()
        //T_C2-2_F11_B_001
        {
            TestTools.TestStart(driver);

            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));

            TestTools.DatenEingeben("", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDText�berpr�fen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDText�berpr�fen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test@", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDText�berpr�fen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test@gmail", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Ung�ltig, TestTools.IDText�berpr�fen("PWRecoveryFehler", driver));

            TestTools.TestEnde(driver);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void DatenL�schen1()
        //T_C2-5_F02_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("L�schenButton", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Account_L�schen_Best�tigen, TestTools.IDText�berpr�fen("L�schenBest", driver));

            TestTools.ElementKlick("btnModalCancel", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Eigene_Datenseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }

        [Test]
        public void DatenL�schen2()
        //T_C2-5_F03_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("L�schenButton", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Account_L�schen_Best�tigen, TestTools.IDText�berpr�fen("L�schenBest", driver));

            TestTools.ElementKlick("L�schenCancel", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Eigene_Datenseite, TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }

        [Test]
        public void XXDatenL�schen3()
        //T_C2-5_F04_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name2, Services.LoginDaten.PW2, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("L�schenButton", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Account_L�schen_Best�tigen, TestTools.IDText�berpr�fen("L�schenBest", driver));

            TestTools.ElementKlick("btnModalDelete", driver);
            Assert.AreEqual(Services.Hinweise.Account_Gel�scht, TestTools.IDText�berpr�fen("Gel�scht", driver));

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name2, Services.LoginDaten.PW2, driver);
            Assert.AreEqual(Services.Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.IDText�berpr�fen("error2", driver));

            TestTools.TestEnde(driver);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////---SPRINT 3---//////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}







