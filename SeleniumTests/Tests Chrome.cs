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
            Assert.AreEqual(Services.Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.IDTextÜberprüfen("error2", driver));
            
            TestTools.TestEnde(driver);
        }

        [Test]
        public void LoginTest_FalscheEmail()
        //T_U1-2_ALF_B_06
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben("caterer@test.d", Services.LoginDaten.PW1, driver);
            Assert.AreEqual(Services.Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.IDTextÜberprüfen("error2", driver));

            TestTools.TestEnde(driver);

        }

        [Test]
        public void LoginTest_OhnePW()
        //T_U1-2_ALF_B_07
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, "", driver);
            Assert.AreEqual(Services.Fehlermeldung.PW_Erforderlich, TestTools.IDTextÜberprüfen("error1", driver));
            
            TestTools.TestEnde(driver);

        }

        [Test]
        public void LoginTest_OhneEmail()
        //T_U1-2_ALF_B_08
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben("", Services.LoginDaten.PW1, driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDTextÜberprüfen("Email-error", driver));

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

            TestTools.KontaktFußzeile(driver);

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

            TestTools.DatenschutzFußzeile(driver);

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

            TestTools.AGBFußzeile(driver);

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

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
            
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F02_B_001 
        public void RegistrationsSeitenLinks()
        {
            //Variante Links
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //AGB
            TestTools.AGBFußzeile(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Datenschutz
            TestTools.DatenschutzFußzeile(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Kontakt
            TestTools.KontaktFußzeile(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Impressum
            TestTools.ImpressumFußzeile(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //AGBs bei Lesebestätigung
            TestTools.ElementKlick("RegAGB", driver);
            Assert.AreEqual(Services.Hinweise.AGBseite, TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Datenschutz bei Lesebestätigung
            TestTools.ElementKlick("RegDatenschutz", driver);
            Assert.AreEqual(Services.Hinweise.Datenschutzseite, TestTools.IDTextÜberprüfen("Datenschutzbest", driver));

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
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //AGB
            TestTools.AGBDropdownLogout(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Datenschutz
            TestTools.DatenschutzDropdownLogout(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Kontakt
            TestTools.KontaktDropdownLogout(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

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

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.ElementKlick("btnSpeichern", driver);

            //Account
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDTextÜberprüfen("Mail-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PW_Erforderlich, TestTools.IDTextÜberprüfen("Passwort-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PW_Wiederholung_Erforderlich, TestTools.IDTextÜberprüfen("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual(Services.Fehlermeldung.Firma_Erforderlich, TestTools.IDTextÜberprüfen("Firmenname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Organisation_Erforderlich, TestTools.IDTextÜberprüfen("Organisationsform-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Straße_Hausnummer_Erforderlich, TestTools.IDTextÜberprüfen("Stra_e-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PLZ_Erforderlich, TestTools.IDTextÜberprüfen("Postleitzahl-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ort_Erforderlich, TestTools.IDTextÜberprüfen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Services.Fehlermeldung.Anrede_Erforderlich, TestTools.IDTextÜberprüfen("Anrede-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Vorname_Erforderlich, TestTools.IDTextÜberprüfen("Vorname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Nachname_Erforderlich, TestTools.IDTextÜberprüfen("Nachname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.IDTextÜberprüfen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Services.Fehlermeldung.Telefon_Erforderlich, TestTools.IDTextÜberprüfen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Services.Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.IDTextÜberprüfen("Lieferumkreis-error", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F05_B_001 
        public void RegistrationsFehler2()
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.ElementKlick("btnSpeichern", driver);

            //Account
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDTextÜberprüfen("Mail-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PW_Erforderlich, TestTools.IDTextÜberprüfen("Passwort-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PW_Wiederholung_Erforderlich, TestTools.IDTextÜberprüfen("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual(Services.Fehlermeldung.Firma_Erforderlich, TestTools.IDTextÜberprüfen("Firmenname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Organisation_Erforderlich, TestTools.IDTextÜberprüfen("Organisationsform-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Straße_Hausnummer_Erforderlich, TestTools.IDTextÜberprüfen("Stra_e-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PLZ_Erforderlich, TestTools.IDTextÜberprüfen("Postleitzahl-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ort_Erforderlich, TestTools.IDTextÜberprüfen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Services.Fehlermeldung.Anrede_Erforderlich, TestTools.IDTextÜberprüfen("Anrede-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Vorname_Erforderlich, TestTools.IDTextÜberprüfen("Vorname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Nachname_Erforderlich, TestTools.IDTextÜberprüfen("Nachname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.IDTextÜberprüfen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Services.Fehlermeldung.Telefon_Erforderlich, TestTools.IDTextÜberprüfen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Services.Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.IDTextÜberprüfen("Lieferumkreis-error", driver));

            //Email befüllen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys("XXX@xxx.xx");
            Assert.AreEqual(false, TestTools.FehlerID("Mail-error", driver));

            //Passwort befüllen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");
            Assert.AreEqual(false, TestTools.FehlerID("Passwort-error", driver));

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");
            Assert.AreEqual(false, TestTools.FehlerID("PasswortVerification-error", driver));

            //Firmenname befüllen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys(Services.NutzerDaten.NutzerDaten_Firmenname);
            Assert.AreEqual(false, TestTools.FehlerID("Firmenname-error", driver));

            //Organisationsform wählen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");
            Assert.AreEqual(false, TestTools.FehlerID("Organisationsform-error", driver));

            //Straße befüllen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys(Services.NutzerDaten.NutzerDaten_Straße_Nr);
            Assert.AreEqual(false, TestTools.FehlerID("Stra_e-error", driver));

            //PLZ befüllen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys(Services.NutzerDaten.NutzerDaten_PLZ);
            Assert.AreEqual(false, TestTools.FehlerID("Postleitzahl-error", driver));

            //Ort befüllen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys(Services.NutzerDaten.NutzerDaten_Ort);
            Assert.AreEqual(false, TestTools.FehlerID("Ort-error", driver));

            //Anrede wählen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");
            Assert.AreEqual(false, TestTools.FehlerID("Anrede-error", driver));

            //Vorname befüllen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys(Services.NutzerDaten.NutzerDaten_Vorname);
            Assert.AreEqual(false, TestTools.FehlerID("Vorname-error", driver));

            //Nachname befüllen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys(Services.NutzerDaten.NutzerDaten_Name);
            Assert.AreEqual(false, TestTools.FehlerID("Nachname-error", driver));

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys(Services.NutzerDaten.NutzerDaten_Ansprechpartner);
            Assert.AreEqual(false, TestTools.FehlerID("FunktionAnsprechpartner-error", driver));

            //Telefon befüllen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys(Services.NutzerDaten.NutzerDaten_Telefon);
            Assert.AreEqual(false, TestTools.FehlerID("Telefon-error", driver));

            //Umkreis wählen
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

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Email befüllen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys(Services.LoginDaten.Name1);

            //Passwort befüllen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");

            //Firmenname befüllen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys(Services.NutzerDaten.NutzerDaten_Firmenname);

            //Organisationsform wählen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");

            //Straße befüllen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys(Services.NutzerDaten.NutzerDaten_Straße_Nr);

            //PLZ befüllen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys(Services.NutzerDaten.NutzerDaten_PLZ);

            //Ort befüllen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys(Services.NutzerDaten.NutzerDaten_Ort);

            //Anrede wählen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");

            //Vorname befüllen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys(Services.NutzerDaten.NutzerDaten_Vorname);

            //Nachname befüllen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys(Services.NutzerDaten.NutzerDaten_Name);

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys(Services.NutzerDaten.NutzerDaten_Ansprechpartner);

            //Telefon befüllen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys(Services.NutzerDaten.NutzerDaten_Telefon);

            //Umkreis wählen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");

            //AGBs akzeptieren
            TestTools.ElementKlick("AGBs", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("WeitergabeVonDaten", driver);

            TestTools.ElementKlick("btnSpeichern", driver);

            Assert.AreEqual(Services.Fehlermeldung.Email_Bereits_Vorhanden, TestTools.IDTextÜberprüfen("VallidationSummary", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        //T_U1-3_F11_B_001 & T_U1-3_F06_B_001
        public void RegistrationsFehlerEinverständniss()
        {
            TestTools.TestStart(driver);

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Email befüllen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys("projek1test@gmail.com");

            //Passwort befüllen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");

            //Firmenname befüllen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys(Services.NutzerDaten.NutzerDaten_Firmenname);

            //Organisationsform wählen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");

            //Straße befüllen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys(Services.NutzerDaten.NutzerDaten_Straße_Nr);

            //PLZ befüllen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys(Services.NutzerDaten.NutzerDaten_PLZ);

            //Ort befüllen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys(Services.NutzerDaten.NutzerDaten_Ort);

            //Anrede wählen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");

            //Vorname befüllen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys(Services.NutzerDaten.NutzerDaten_Vorname);

            //Nachname befüllen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys(Services.NutzerDaten.NutzerDaten_Name);

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys(Services.NutzerDaten.NutzerDaten_Ansprechpartner);

            //Telefon befüllen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys(Services.NutzerDaten.NutzerDaten_Telefon);

            //Fax befüllen
            driver.FindElement(By.Id("Fax")).Clear();
            driver.FindElement(By.Id("Fax")).SendKeys(Services.NutzerDaten.NutzerDaten_Telefon);

            //Internetadresse befüllen
            driver.FindElement(By.Id("Internetadresse")).Clear();
            driver.FindElement(By.Id("Internetadresse")).SendKeys("www.test.test");

            //Umkreis wählen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");

            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.EineSekundeWarten(driver);

            Assert.AreEqual(Services.Fehlermeldung.Datenschutzbestimmungen_Zustimmung, TestTools.IDTextÜberprüfen("DatenschutzValidation-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.AGB_Zustimmung, TestTools.IDTextÜberprüfen("AGBValidation-error", driver));

            //AGBs akzeptieren
            TestTools.ElementKlick("AGBs", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("WeitergabeVonDaten", driver);


            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.EineSekundeWarten(driver);

            Assert.AreEqual("Registrierung erfolgreich", TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //Login mit korrekten Daten durchführen und testen der Fehlermeldung für fehlende Email-Verification
            //T_U1-3_F06_B_001
            TestTools.LoginDatenEingeben("projek1test@gmail.com", "12345678", driver);
            Assert.AreEqual(Services.Hinweise.Reg_Email_Verifikation_Fehlt, TestTools.IDTextÜberprüfen("RegMailValidation-error", driver));

            TestTools.TestEnde(driver);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void PersDatenÄndern()
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

            //Fehlermeldungen überprüfen
            //Firma
            Assert.AreEqual(Services.Fehlermeldung.Firma_Erforderlich, TestTools.IDTextÜberprüfen("Firmenname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Organisation_Erforderlich, TestTools.IDTextÜberprüfen("Organisationsform-error", driver));
            Assert.AreEqual("Das Feld \"Straße\" ist erforderlich.", TestTools.IDTextÜberprüfen("Stra_e-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.PLZ_Erforderlich, TestTools.IDTextÜberprüfen("Postleitzahl-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ort_Erforderlich, TestTools.IDTextÜberprüfen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual(Services.Fehlermeldung.Anrede_Erforderlich, TestTools.IDTextÜberprüfen("Anrede-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Vorname_Erforderlich, TestTools.IDTextÜberprüfen("Vorname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Nachname_Erforderlich, TestTools.IDTextÜberprüfen("Nachname-error", driver));
            Assert.AreEqual(Services.Fehlermeldung.Ansprechpartner_Erforderlich, TestTools.IDTextÜberprüfen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual(Services.Fehlermeldung.Telefon_Erforderlich, TestTools.IDTextÜberprüfen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual(Services.Fehlermeldung.Lieferumkreis_Erforderlich, TestTools.IDTextÜberprüfen("Lieferumkreis-error", driver));

            //Löschen unbestätigt abbrechen
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.EineSekundeWarten(driver);

            //Prüfen ob alte Daten vorhanden sind
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));
            Assert.AreEqual("Holzweg 1", TestTools.TextboxTextÜberprüfen("Stra_e", driver));
            Assert.AreEqual("87654", TestTools.TextboxTextÜberprüfen("Postleitzahl", driver));
            Assert.AreEqual("Woodway", TestTools.TextboxTextÜberprüfen("Ort", driver));
            Assert.AreEqual("Herr", TestTools.TextboxTextÜberprüfen("Anrede", driver));
            Assert.AreEqual("Max", TestTools.TextboxTextÜberprüfen("Vorname", driver));
            Assert.AreEqual("Mustermann", TestTools.TextboxTextÜberprüfen("Nachname", driver));
            Assert.AreEqual("Chef", TestTools.TextboxTextÜberprüfen("FunktionAnsprechpartner", driver));
            Assert.AreEqual("01234 - 56789", TestTools.TextboxTextÜberprüfen("Telefon", driver));
            Assert.AreEqual("01234 - 99999", TestTools.TextboxTextÜberprüfen("Fax", driver));

            //Daten ändern
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Firmenname, "Firmenname", driver);
            new SelectElement(driver.FindElement(By.Id("Organisationsform"))).SelectByIndex(1);
            TestTools.DatenEingeben(Services.NutzerDaten.NutzerDaten_Straße_Nr, "Stra_e", driver);
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

            //Prüfen ob alte Daten geändert worden
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Firmenname, TestTools.TextboxTextÜberprüfen("Firmenname", driver));
            Assert.AreEqual("Mensaverein", TestTools.TextboxTextÜberprüfen("Organisationsform", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Straße_Nr, TestTools.TextboxTextÜberprüfen("Stra_e", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_PLZ, TestTools.TextboxTextÜberprüfen("Postleitzahl", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Ort, TestTools.TextboxTextÜberprüfen("Ort", driver));
            Assert.AreEqual("Herr", TestTools.TextboxTextÜberprüfen("Anrede", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Vorname, TestTools.TextboxTextÜberprüfen("Vorname", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Name, TestTools.TextboxTextÜberprüfen("Nachname", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Ansprechpartner, TestTools.TextboxTextÜberprüfen("FunktionAnsprechpartner", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Telefon, TestTools.TextboxTextÜberprüfen("Telefon", driver));
            Assert.AreEqual(Services.NutzerDaten.NutzerDaten_Telefon, TestTools.TextboxTextÜberprüfen("Fax", driver));
            Assert.AreEqual("Bis 10 km", TestTools.TextboxTextÜberprüfen("Lieferumkreis", driver));

            TestTools.EineSekundeWarten(driver);

            //Daten wieder auf Ursprung zurück setzen
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
        public void PersDatenÄndern2()
        //T_C2-1_F02_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            //Daten ändern über AGB Fußzeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.AGBFußzeile(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über Datenschutzbestimmungen Fußzeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.DatenschutzFußzeile(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über Kontakt Fußzeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.KontaktFußzeile(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über Impressum Fußzeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ImpressumFußzeile(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über AGB Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.AGBDropdownLogin(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über Datenschutzbestimmungen Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.DatenschutzDropdownLogin(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über Kontakt Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.KontaktDropdownLogin(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über Impressum Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ImpressumDropdownLogin(driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über Eigene Daten abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über StartButton abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            driver.Navigate().GoToUrl(baseURL);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            //Daten ändern über Logout abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.NutzerAusloggen(driver);
            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));

            TestTools.TestEnde(driver);

        }

        [Test]
        public void PWVÄndern()
        //T_C2-1_F03_B_001
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //AGBs Fußzeile
            TestTools.AGBFußzeile(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Datenschutzbestimmungen Fußzeile
            TestTools.DatenschutzFußzeile(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //AGBs Dropdown
            TestTools.AGBDropdownLogin(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Datenschutzbestimmungen Dropdown
            TestTools.DatenschutzDropdownLogin(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Kontakt Dropdown
            TestTools.KontaktDropdownLogin(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Impressum Dropdown
            TestTools.ImpressumDropdownLogin(driver);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            //Änderung durchführen
            TestTools.NutzerAusloggen(driver);

            TestTools.LoginDatenEingeben("caterer1@test.de", Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort ändern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDTextÜberprüfen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);
            TestTools.ElementKlick("Abschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Erfolgreich, TestTools.IDTextÜberprüfen("Passwort", driver));

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

            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));

            //AGBs Fußzeile
            TestTools.AGBFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Datenschutzbestimmungen Fußzeile
            TestTools.DatenschutzFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);
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

            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
            driver.Navigate().GoToUrl(PWRequestURL);

            //Login Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            Assert.AreEqual("Login", TestTools.IDTextÜberprüfen("LoginPage", driver));
            driver.Navigate().GoToUrl(PWRequestURL);

            //Registrierung Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        public void PWVergessen3()
        //T_C2-2_F04_B_001
        {
            TestTools.TestStart(driver);

            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //AGBs Fußzeile
            TestTools.AGBFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //Datenschutzbestimmungen Fußzeile
            TestTools.DatenschutzFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //Kontakt Fußzeile
            TestTools.KontaktFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //Impressum Fußzeile
            TestTools.ImpressumFußzeile(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //AGBs Dropdown
            TestTools.AGBDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //Datenschutzbestimmungen Dropdown
            TestTools.DatenschutzDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //Kontakt Dropdown
            TestTools.KontaktDropdownLogout(driver);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

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
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual(Services.Hinweise.Startseite, driver.Title);
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //Login Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            Assert.AreEqual("Login", TestTools.IDTextÜberprüfen("LoginPage", driver));
            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual(Services.Hinweise.PW_Änderung_Bestätigung, TestTools.IDTextÜberprüfen("RegErfolg", driver));

            //Registrierung Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual(Services.Hinweise.Registrierungsseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }
        [Test]
        public void PWVergessen6()
        //T_C2-2_F11_B_001
        {
            TestTools.TestStart(driver);

            driver.Navigate().GoToUrl(PWRequestURL);
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Mail", driver));

            TestTools.DatenEingeben("", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDTextÜberprüfen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDTextÜberprüfen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test@", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Erforderlich, TestTools.IDTextÜberprüfen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test@gmail", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Fehlermeldung.Email_Ungültig, TestTools.IDTextÜberprüfen("PWRecoveryFehler", driver));

            TestTools.TestEnde(driver);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void DatenLöschen1()
        //T_C2-5_F02_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("LöschenButton", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Account_Löschen_Bestätigen, TestTools.IDTextÜberprüfen("LöschenBest", driver));

            TestTools.ElementKlick("btnModalCancel", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Eigene_Datenseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }

        [Test]
        public void DatenLöschen2()
        //T_C2-5_F03_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name1, Services.LoginDaten.PW1, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("LöschenButton", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Account_Löschen_Bestätigen, TestTools.IDTextÜberprüfen("LöschenBest", driver));

            TestTools.ElementKlick("LöschenCancel", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Eigene_Datenseite, TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.TestEnde(driver);

        }

        [Test]
        public void XXDatenLöschen3()
        //T_C2-5_F04_B_001 
        {
            TestTools.TestStart(driver);

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name2, Services.LoginDaten.PW2, driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("LöschenButton", driver);
            TestTools.EineSekundeWarten(driver);
            Assert.AreEqual(Services.Hinweise.Account_Löschen_Bestätigen, TestTools.IDTextÜberprüfen("LöschenBest", driver));

            TestTools.ElementKlick("btnModalDelete", driver);
            Assert.AreEqual(Services.Hinweise.Account_Gelöscht, TestTools.IDTextÜberprüfen("Gelöscht", driver));

            TestTools.LoginDatenEingeben(Services.LoginDaten.Name2, Services.LoginDaten.PW2, driver);
            Assert.AreEqual(Services.Fehlermeldung.LoginSeite_Email_PW_Fehler, TestTools.IDTextÜberprüfen("error2", driver));

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







