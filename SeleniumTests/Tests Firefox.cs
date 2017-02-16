using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestFixture]
    public class TestFirefox
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:60003/";
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

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }

        [TearDown]
        public void TeardownTest()
        {
        }

        ////Zwingt Selenium bis zu 10 Sekunden nach dem Element zu suchen!
        //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        ////Sucht nach dem Element
        //driver.FindElement(By.Id("Willkommen"));
        ////Erwarteten Wert überprüfen
        //Assert.AreEqual(baseURL, driver.Url.ToString());

        ////Alternative Validierung
        //Assert.AreEqual("Willkommen caterer@test.de", driver.FindElement(By.Id("Willkommen")).Text);

        [Test]
        public void LoginTest1()
        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
        {
            TestTools.ElementKlick("loginLinkbutton", driver);

            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }

        [Test]
        public void LoginTest2()
        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
        {
            //Variante Dropdown

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);

            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }

        [Test]
        public void LoginTest_FalschesPW()
        //T_U1-2_ALF_B_05
        {
            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#21", driver);
            Assert.AreEqual("E-Mail oder Passwort falsch", TestTools.IDTextÜberprüfen("error2", driver));
        }

        [Test]
        public void LoginTest_FalscheEmail()
        //T_U1-2_ALF_B_06
        {
            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("caterer@test.d", "Start#22", driver);
            Assert.AreEqual("E-Mail oder Passwort falsch", TestTools.IDTextÜberprüfen("error2", driver));

        }

        [Test]
        public void LoginTest_OhnePW()
        //T_U1-2_ALF_B_07
        {
            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "", driver);
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", TestTools.IDTextÜberprüfen("error1", driver));

        }

        [Test]
        public void LoginTest_OhneEmail()
        //T_U1-2_ALF_B_08
        {
            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("", "Start#22", driver);
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDTextÜberprüfen("Email-error", driver));

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void KontaktAufruf1()
        //T_U1-4_AL_B_01
        {
            //Variante Knopf
            TestTools.ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDTextÜberprüfen("Ansprechp", driver));

        }

        [Test]
        public void KontaktAufruf2()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownKontaktLogout", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDTextÜberprüfen("Ansprechp", driver));
        }

        [Test]
        public void KontaktAufruf3()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Login
            TestTools.ElementKlick("loginLinkbutton", driver);

            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownKontaktLogin", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDTextÜberprüfen("Ansprechp", driver));

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void DatenschutzAufruf1()
        //T_U1-6_AL_B_01
        {
            //Variante Knopf
            TestTools.ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDTextÜberprüfen("Datenschutzbest", driver));
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf2()
        {
            //Variante Dropdown Logout
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogout", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDTextÜberprüfen("Datenschutzbest", driver));
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf3()
        {
            //Variante Dropdown Login
            TestTools.ElementKlick("loginLinkbutton", driver);

            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogin", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDTextÜberprüfen("Datenschutzbest", driver));

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void AGBAufruf1()
        //T_U1-7_AL_B_01
        {
            //Variante Knopf
            TestTools.ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

        }

        [Test]
        public void AGBAufruf2()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownAGBLogout", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

        }

        [Test]
        public void AGBAufruf3()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Login
            TestTools.ElementKlick("loginLinkbutton", driver);

            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownAGBLogin", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
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
            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);

            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

           TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }
        [Test]
        //T_U1-3_F02_B_001 
        public void RegistrationsSeitenLinks()
        {
            //Variante Links
            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //AGB
            TestTools.ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Datenschutz
            TestTools.ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDTextÜberprüfen("Datenschutzbest", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Kontakt
            TestTools.ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDTextÜberprüfen("Ansprechp", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Impressum
            TestTools.ElementKlick("Impressum", driver);
            Assert.AreEqual("Impressum", TestTools.IDTextÜberprüfen("Impr", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //AGBs bei Lesebestätigung
            TestTools.ElementKlick("RegAGB", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Datenschutz bei Lesebestätigung
            TestTools.ElementKlick("RegDatenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDTextÜberprüfen("Datenschutzbest", driver));

           TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F03_B_001 
        public void RegistrationsDropdownLinks()
        {
            //Variante Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //AGB
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownAGBLogout", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Datenschutz
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogout", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDTextÜberprüfen("Datenschutzbest", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Kontakt
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownKontaktLogout", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDTextÜberprüfen("Ansprechp", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Impressum
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownImpressumLogout", driver);
            Assert.AreEqual("Impressum", TestTools.IDTextÜberprüfen("Impr", driver));

           TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F04_B_001 
        public void RegistrationsFehler()
        {
            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.ElementKlick("btnSpeichern", driver);

            //Account
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDTextÜberprüfen("Mail-error", driver));
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", TestTools.IDTextÜberprüfen("Passwort-error", driver));
            Assert.AreEqual("Das Feld \"Passwort Wiederholung\" ist erforderlich.", TestTools.IDTextÜberprüfen("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual("Das Feld \"Firmenname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Firmenname-error", driver));
            Assert.AreEqual("Das Feld \"Organisationsform\" ist erforderlich.", TestTools.IDTextÜberprüfen("Organisationsform-error", driver));
            Assert.AreEqual("Das Feld \"Straße und Hausnummer\" ist erforderlich.", TestTools.IDTextÜberprüfen("Stra_e-error", driver));
            Assert.AreEqual("Das Feld \"Postleitzahl\" ist erforderlich.", TestTools.IDTextÜberprüfen("Postleitzahl-error", driver));
            Assert.AreEqual("Das Feld \"Ort\" ist erforderlich.", TestTools.IDTextÜberprüfen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual("Das Feld \"Anrede\" ist erforderlich.", TestTools.IDTextÜberprüfen("Anrede-error", driver));
            Assert.AreEqual("Das Feld \"Vorname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Vorname-error", driver));
            Assert.AreEqual("Das Feld \"Nachname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Nachname-error", driver));
            Assert.AreEqual("Das Feld \"Funktion des Ansprechpartners\" ist erforderlich.", TestTools.IDTextÜberprüfen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual("Das Feld \"Telefon\" ist erforderlich.", TestTools.IDTextÜberprüfen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual("Das Feld \"Lieferumkreis\" ist erforderlich.", TestTools.IDTextÜberprüfen("Lieferumkreis-error", driver));

           TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }
        [Test]
        //T_U1-3_F05_B_001 
        public void RegistrationsFehler2()
        {

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            TestTools.ElementKlick("btnSpeichern", driver);

            //Account
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDTextÜberprüfen("Mail-error", driver));
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", TestTools.IDTextÜberprüfen("Passwort-error", driver));
            Assert.AreEqual("Das Feld \"Passwort Wiederholung\" ist erforderlich.", TestTools.IDTextÜberprüfen("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual("Das Feld \"Firmenname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Firmenname-error", driver));
            Assert.AreEqual("Das Feld \"Organisationsform\" ist erforderlich.", TestTools.IDTextÜberprüfen("Organisationsform-error", driver));
            Assert.AreEqual("Das Feld \"Straße und Hausnummer\" ist erforderlich.", TestTools.IDTextÜberprüfen("Stra_e-error", driver));
            Assert.AreEqual("Das Feld \"Postleitzahl\" ist erforderlich.", TestTools.IDTextÜberprüfen("Postleitzahl-error", driver));
            Assert.AreEqual("Das Feld \"Ort\" ist erforderlich.", TestTools.IDTextÜberprüfen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual("Das Feld \"Anrede\" ist erforderlich.", TestTools.IDTextÜberprüfen("Anrede-error", driver));
            Assert.AreEqual("Das Feld \"Vorname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Vorname-error", driver));
            Assert.AreEqual("Das Feld \"Nachname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Nachname-error", driver));
            Assert.AreEqual("Das Feld \"Funktion des Ansprechpartners\" ist erforderlich.", TestTools.IDTextÜberprüfen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual("Das Feld \"Telefon\" ist erforderlich.", TestTools.IDTextÜberprüfen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual("Das Feld \"Lieferumkreis\" ist erforderlich.", TestTools.IDTextÜberprüfen("Lieferumkreis-error", driver));

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
            driver.FindElement(By.Id("Firmenname")).SendKeys("Testfirma");
            Assert.AreEqual(false, TestTools.FehlerID("Firmenname-error", driver));

            //Organisationsform wählen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");
            Assert.AreEqual(false, TestTools.FehlerID("Organisationsform-error", driver));

            //Straße befüllen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys("Teststraße 0");
            Assert.AreEqual(false, TestTools.FehlerID("Stra_e-error", driver));

            //PLZ befüllen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys("12345");
            Assert.AreEqual(false, TestTools.FehlerID("Postleitzahl-error", driver));

            //Ort befüllen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys("Testen");
            Assert.AreEqual(false, TestTools.FehlerID("Ort-error", driver));

            //Anrede wählen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");
            Assert.AreEqual(false, TestTools.FehlerID("Anrede-error", driver));

            //Vorname befüllen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys("Test");
            Assert.AreEqual(false, TestTools.FehlerID("Vorname-error", driver));

            //Nachname befüllen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys("Teste");
            Assert.AreEqual(false, TestTools.FehlerID("Nachname-error",driver));

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys("Tester");
            Assert.AreEqual(false, TestTools.FehlerID("FunktionAnsprechpartner-error",driver));

            //Telefon befüllen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys("09876/54321");
            Assert.AreEqual(false, TestTools.FehlerID("Telefon-error",driver));

            //Umkreis wählen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");
            Assert.AreEqual(false, TestTools.FehlerID("Lieferumkreis-error",driver));
            
            TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F08_B_001 
        public void RegistrationsFehlerDoppelMail()
        {

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Email befüllen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys("Caterer@test.de");

            //Passwort befüllen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");

            //Firmenname befüllen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys("Testfirma");

            //Organisationsform wählen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");

            //Straße befüllen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys("Teststraße 0");

            //PLZ befüllen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys("12345");

            //Ort befüllen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys("Testen");

            //Anrede wählen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");

            //Vorname befüllen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys("Test");

            //Nachname befüllen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys("Teste");

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys("Tester");

            //Telefon befüllen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys("09876/54321");

            //Umkreis wählen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");

            //AGBs akzeptieren
            TestTools.ElementKlick("AGBs", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("WeitergabeVonDaten", driver);

            TestTools.ElementKlick("btnSpeichern", driver);

            Assert.AreEqual("E-Mail ist bereits registriert",TestTools.IDTextÜberprüfen("VallidationSummary", driver));
            
           TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F11_B_001 & T_U1-3_F06_B_001
        public void RegistrationsFehlerEinverständniss()
        {

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));

            //Email befüllen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys("projek10test@gmail.com");

            //Passwort befüllen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");

            //Passwort wiederholen befüllen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");

            //Firmenname befüllen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys("Testfirma");

            //Organisationsform wählen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");

            //Straße befüllen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys("Teststraße 0");

            //PLZ befüllen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys("12345");

            //Ort befüllen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys("Testen");

            //Anrede wählen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");

            //Vorname befüllen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys("Test");

            //Nachname befüllen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys("Teste");

            //FunktionAnprechpartner befüllen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys("Tester");

            //Telefon befüllen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys("09876/54321");

            //Fax befüllen
            driver.FindElement(By.Id("Fax")).Clear();
            driver.FindElement(By.Id("Fax")).SendKeys("09876/54321");

            //Internetadresse befüllen
            driver.FindElement(By.Id("Internetadresse")).Clear();
            driver.FindElement(By.Id("Internetadresse")).SendKeys("www.test.test");

            //Umkreis wählen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");

            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.FehlerID("xxx", driver,1);

            Assert.AreEqual("Datenschutzbestimmungen müssen zugestimmt werden", TestTools.IDTextÜberprüfen("DatenschutzValidation-error", driver));
            Assert.AreEqual("Sie müssen die AGBs akzeptieren", TestTools.IDTextÜberprüfen("AGBValidation-error", driver));

            //AGBs akzeptieren
            TestTools.ElementKlick("AGBs", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("WeitergabeVonDaten", driver);


            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.FehlerID("xxx", driver, 1);

            Assert.AreEqual("Registrierung erfolgreich", TestTools.IDTextÜberprüfen("RegErfolg",driver));

            //Login mit korrekten Daten durchführen und testen der Fehlermeldung für fehlende Email-Verification
            //T_U1-3_F06_B_001
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("projek10test@gmail.com", "12345678", driver);
            Assert.AreEqual("Registrierung noch nicht abgeschlossen", TestTools.IDTextÜberprüfen("RegMailValidation-error", driver));


            TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }

        [Test]
        public void PersDatenÄndern()
        //T_C2-1_F01_B_001 
        {
            
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Meine Daten")).Click();


            //Leeren aller Daten
            TestTools.DatenEingeben("", "Firmenname",driver);
            //TestTools.DatenEingeben("Bitte wählen...", "Organisationsform", driver);
            new SelectElement(driver.FindElement(By.Id("Organisationsform"))).SelectByIndex(0);
            TestTools.DatenEingeben("", "Stra_e", driver);
            TestTools.DatenEingeben("", "Postleitzahl", driver);
            TestTools.DatenEingeben("", "Ort", driver);
            //TestTools.DatenEingeben("Bitte wählen...", "Anrede", driver);
            new SelectElement(driver.FindElement(By.Id("Anrede"))).SelectByIndex(0);
            TestTools.DatenEingeben("", "Vorname", driver);
            TestTools.DatenEingeben("", "Nachname", driver);
            TestTools.DatenEingeben("", "FunktionAnsprechpartner", driver);
            TestTools.DatenEingeben("", "Telefon", driver);
            TestTools.DatenEingeben("", "Fax", driver);
            TestTools.DatenEingeben("", "Internetadresse", driver);
            //TestTools.DatenEingeben("Bitte wählen...", "Lieferumkreis", driver);
            new SelectElement(driver.FindElement(By.Id("Lieferumkreis"))).SelectByIndex(0);

            TestTools.ElementKlick("btnSpeichern", driver);

            //Fehlermeldungen überprüfen
            //Firma
            Assert.AreEqual("Das Feld \"Firmenname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Firmenname-error", driver));
            Assert.AreEqual("Das Feld \"Organisationsform\" ist erforderlich.", TestTools.IDTextÜberprüfen("Organisationsform-error", driver));
            Assert.AreEqual("Das Feld \"Straße\" ist erforderlich.", TestTools.IDTextÜberprüfen("Stra_e-error", driver));
            Assert.AreEqual("Das Feld \"Postleitzahl\" ist erforderlich.", TestTools.IDTextÜberprüfen("Postleitzahl-error", driver));
            Assert.AreEqual("Das Feld \"Ort\" ist erforderlich.", TestTools.IDTextÜberprüfen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual("Das Feld \"Anrede\" ist erforderlich.", TestTools.IDTextÜberprüfen("Anrede-error", driver));
            Assert.AreEqual("Das Feld \"Vorname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Vorname-error", driver));
            Assert.AreEqual("Das Feld \"Nachname\" ist erforderlich.", TestTools.IDTextÜberprüfen("Nachname-error", driver));
            Assert.AreEqual("Das Feld \"Funktion des Ansprechpartners\" ist erforderlich.", TestTools.IDTextÜberprüfen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual("Das Feld \"Telefon\" ist erforderlich.", TestTools.IDTextÜberprüfen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual("Das Feld \"Lieferumkreis\" ist erforderlich.", TestTools.IDTextÜberprüfen("Lieferumkreis-error", driver));
            
            //Löschen unbestätigt abbrechen
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Meine Daten")).Click();

            TestTools.FehlerID("xxx", driver, 1);

            //Prüfen ob alte Daten vorhanden sind
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxTextÜberprüfen("Firmenname", driver));
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Organisationsform", driver));
            Assert.AreEqual("Holzweg 1", TestTools.TextboxTextÜberprüfen("Stra_e", driver));
            Assert.AreEqual("87654", TestTools.TextboxTextÜberprüfen("Postleitzahl", driver));
            Assert.AreEqual("Woodway", TestTools.TextboxTextÜberprüfen("Ort", driver));
            Assert.AreEqual("Herr", TestTools.TextboxTextÜberprüfen("Anrede", driver));
            Assert.AreEqual("Max", TestTools.TextboxTextÜberprüfen("Vorname", driver));
            Assert.AreEqual("Mustermann", TestTools.TextboxTextÜberprüfen("Nachname", driver));
            Assert.AreEqual("Chef", TestTools.TextboxTextÜberprüfen("FunktionAnsprechpartner", driver));
            Assert.AreEqual("01234 - 56789", TestTools.TextboxTextÜberprüfen("Telefon", driver));
            Assert.AreEqual("01234 - 99999", TestTools.TextboxTextÜberprüfen("Fax", driver));
            Assert.AreEqual("www.AYCE.de", TestTools.TextboxTextÜberprüfen("Internetadresse", driver));
            Assert.AreEqual("", TestTools.TextboxTextÜberprüfen("Lieferumkreis", driver));

            //Daten ändern
            TestTools.DatenEingeben("Testfirma", "Firmenname", driver);
            new SelectElement(driver.FindElement(By.Id("Organisationsform"))).SelectByIndex(1);
            TestTools.DatenEingeben("Teststraße 0", "Stra_e", driver);
            TestTools.DatenEingeben("12345", "Postleitzahl", driver);
            TestTools.DatenEingeben("Testen", "Ort", driver);
            new SelectElement(driver.FindElement(By.Id("Anrede"))).SelectByIndex(1);
            TestTools.DatenEingeben("Test", "Vorname", driver);
            TestTools.DatenEingeben("Teste", "Nachname", driver);
            TestTools.DatenEingeben("Tester", "FunktionAnsprechpartner", driver);
            TestTools.DatenEingeben("09876/54321", "Telefon", driver);
            TestTools.DatenEingeben("09876/54321", "Fax", driver);
            TestTools.DatenEingeben("www.test.test", "Internetadresse", driver);
            new SelectElement(driver.FindElement(By.Id("Lieferumkreis"))).SelectByIndex(1);

            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Meine Daten")).Click();

            //Prüfen ob alte Daten geändert worden
            Assert.AreEqual("Testfirma", TestTools.TextboxTextÜberprüfen("Firmenname", driver));
            Assert.AreEqual("Mensaverein", TestTools.TextboxTextÜberprüfen("Organisationsform", driver));
            Assert.AreEqual("Teststraße 0", TestTools.TextboxTextÜberprüfen("Stra_e", driver));
            Assert.AreEqual("12345", TestTools.TextboxTextÜberprüfen("Postleitzahl", driver));
            Assert.AreEqual("Testen", TestTools.TextboxTextÜberprüfen("Ort", driver));
            Assert.AreEqual("Herr", TestTools.TextboxTextÜberprüfen("Anrede", driver));
            Assert.AreEqual("Test", TestTools.TextboxTextÜberprüfen("Vorname", driver));
            Assert.AreEqual("Teste", TestTools.TextboxTextÜberprüfen("Nachname", driver));
            Assert.AreEqual("Tester", TestTools.TextboxTextÜberprüfen("FunktionAnsprechpartner", driver));
            Assert.AreEqual("09876/54321", TestTools.TextboxTextÜberprüfen("Telefon", driver));
            Assert.AreEqual("09876/54321", TestTools.TextboxTextÜberprüfen("Fax", driver));
            Assert.AreEqual("www.test.test", TestTools.TextboxTextÜberprüfen("Internetadresse", driver));
            Assert.AreEqual("Nur im eigenen Stadtgebiet", TestTools.TextboxTextÜberprüfen("Lieferumkreis", driver));

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);
            
            TestTools.FehlerID("xxx", driver, 1);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);


        }








    }
}