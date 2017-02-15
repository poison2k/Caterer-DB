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
        ////Erwarteten Wert �berpr�fen
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
            Assert.AreEqual("E-Mail oder Passwort falsch", TestTools.IDText�berpr�fen("error2", driver));
        }

        [Test]
        public void LoginTest_FalscheEmail()
        //T_U1-2_ALF_B_06
        {
            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("caterer@test.d", "Start#22", driver);
            Assert.AreEqual("E-Mail oder Passwort falsch", TestTools.IDText�berpr�fen("error2", driver));

        }

        [Test]
        public void LoginTest_OhnePW()
        //T_U1-2_ALF_B_07
        {
            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "", driver);
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", TestTools.IDText�berpr�fen("error1", driver));

        }

        [Test]
        public void LoginTest_OhneEmail()
        //T_U1-2_ALF_B_08
        {
            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("", "Start#22", driver);
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDText�berpr�fen("Email-error", driver));

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
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));

        }

        [Test]
        public void KontaktAufruf2()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownKontaktLogout", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
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
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));

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
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf2()
        {
            //Variante Dropdown Logout
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogout", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
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
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));

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
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

        }

        [Test]
        public void AGBAufruf2()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownAGBLogout", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

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
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

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

            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);

            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

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

            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //AGB
            TestTools.ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Datenschutz
            TestTools.ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Kontakt
            TestTools.ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Impressum
            TestTools.ElementKlick("Impressum", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //AGBs bei Lesebest�tigung
            TestTools.ElementKlick("RegAGB", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Datenschutz bei Lesebest�tigung
            TestTools.ElementKlick("RegDatenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));

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
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //AGB
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownAGBLogout", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Datenschutz
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogout", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Kontakt
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownKontaktLogout", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Impressum
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownImpressumLogout", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));

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

            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.ElementKlick("btnSpeichern", driver);

            //Account
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDText�berpr�fen("Mail-error", driver));
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", TestTools.IDText�berpr�fen("Passwort-error", driver));
            Assert.AreEqual("Das Feld \"Passwort Wiederholung\" ist erforderlich.", TestTools.IDText�berpr�fen("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual("Das Feld \"Firmenname\" ist erforderlich.", TestTools.IDText�berpr�fen("Firmenname-error", driver));
            Assert.AreEqual("Das Feld \"Organisationsform\" ist erforderlich.", TestTools.IDText�berpr�fen("Organisationsform-error", driver));
            Assert.AreEqual("Das Feld \"Stra�e und Hausnummer\" ist erforderlich.", TestTools.IDText�berpr�fen("Stra_e-error", driver));
            Assert.AreEqual("Das Feld \"Postleitzahl\" ist erforderlich.", TestTools.IDText�berpr�fen("Postleitzahl-error", driver));
            Assert.AreEqual("Das Feld \"Ort\" ist erforderlich.", TestTools.IDText�berpr�fen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual("Das Feld \"Anrede\" ist erforderlich.", TestTools.IDText�berpr�fen("Anrede-error", driver));
            Assert.AreEqual("Das Feld \"Vorname\" ist erforderlich.", TestTools.IDText�berpr�fen("Vorname-error", driver));
            Assert.AreEqual("Das Feld \"Nachname\" ist erforderlich.", TestTools.IDText�berpr�fen("Nachname-error", driver));
            Assert.AreEqual("Das Feld \"Funktion des Ansprechpartners\" ist erforderlich.", TestTools.IDText�berpr�fen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual("Das Feld \"Telefon\" ist erforderlich.", TestTools.IDText�berpr�fen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual("Das Feld \"Lieferumkreis\" ist erforderlich.", TestTools.IDText�berpr�fen("Lieferumkreis-error", driver));

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

            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.ElementKlick("btnSpeichern", driver);

            //Account
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDText�berpr�fen("Mail-error", driver));
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", TestTools.IDText�berpr�fen("Passwort-error", driver));
            Assert.AreEqual("Das Feld \"Passwort Wiederholung\" ist erforderlich.", TestTools.IDText�berpr�fen("PasswortVerification-error", driver));

            //Firma
            Assert.AreEqual("Das Feld \"Firmenname\" ist erforderlich.", TestTools.IDText�berpr�fen("Firmenname-error", driver));
            Assert.AreEqual("Das Feld \"Organisationsform\" ist erforderlich.", TestTools.IDText�berpr�fen("Organisationsform-error", driver));
            Assert.AreEqual("Das Feld \"Stra�e und Hausnummer\" ist erforderlich.", TestTools.IDText�berpr�fen("Stra_e-error", driver));
            Assert.AreEqual("Das Feld \"Postleitzahl\" ist erforderlich.", TestTools.IDText�berpr�fen("Postleitzahl-error", driver));
            Assert.AreEqual("Das Feld \"Ort\" ist erforderlich.", TestTools.IDText�berpr�fen("Ort-error", driver));

            //Ansprechpartner
            Assert.AreEqual("Das Feld \"Anrede\" ist erforderlich.", TestTools.IDText�berpr�fen("Anrede-error", driver));
            Assert.AreEqual("Das Feld \"Vorname\" ist erforderlich.", TestTools.IDText�berpr�fen("Vorname-error", driver));
            Assert.AreEqual("Das Feld \"Nachname\" ist erforderlich.", TestTools.IDText�berpr�fen("Nachname-error", driver));
            Assert.AreEqual("Das Feld \"Funktion des Ansprechpartners\" ist erforderlich.", TestTools.IDText�berpr�fen("FunktionAnsprechpartner-error", driver));

            //Erreichbarkeit
            Assert.AreEqual("Das Feld \"Telefon\" ist erforderlich.", TestTools.IDText�berpr�fen("Telefon-error", driver));

            //Sonstiges
            Assert.AreEqual("Das Feld \"Lieferumkreis\" ist erforderlich.", TestTools.IDText�berpr�fen("Lieferumkreis-error", driver));

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
            driver.FindElement(By.Id("Firmenname")).SendKeys("Testfirma");
            Assert.AreEqual(false, TestTools.FehlerID("Firmenname-error", driver));

            //Organisationsform w�hlen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");
            Assert.AreEqual(false, TestTools.FehlerID("Organisationsform-error", driver));

            //Stra�e bef�llen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys("Teststra�e 0");
            Assert.AreEqual(false, TestTools.FehlerID("Stra_e-error", driver));

            //PLZ bef�llen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys("12345");
            Assert.AreEqual(false, TestTools.FehlerID("Postleitzahl-error", driver));

            //Ort bef�llen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys("Testen");
            Assert.AreEqual(false, TestTools.FehlerID("Ort-error", driver));

            //Anrede w�hlen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");
            Assert.AreEqual(false, TestTools.FehlerID("Anrede-error", driver));

            //Vorname bef�llen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys("Test");
            Assert.AreEqual(false, TestTools.FehlerID("Vorname-error", driver));

            //Nachname bef�llen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys("Teste");
            Assert.AreEqual(false, TestTools.FehlerID("Nachname-error",driver));

            //FunktionAnprechpartner bef�llen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys("Tester");
            Assert.AreEqual(false, TestTools.FehlerID("FunktionAnsprechpartner-error",driver));

            //Telefon bef�llen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys("09876/54321");
            Assert.AreEqual(false, TestTools.FehlerID("Telefon-error",driver));

            //Umkreis w�hlen
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

            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Email bef�llen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys("Caterer@test.de");

            //Passwort bef�llen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");

            //Passwort wiederholen bef�llen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");

            //Firmenname bef�llen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys("Testfirma");

            //Organisationsform w�hlen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");

            //Stra�e bef�llen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys("Teststra�e 0");

            //PLZ bef�llen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys("12345");

            //Ort bef�llen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys("Testen");

            //Anrede w�hlen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");

            //Vorname bef�llen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys("Test");

            //Nachname bef�llen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys("Teste");

            //FunktionAnprechpartner bef�llen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys("Tester");

            //Telefon bef�llen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys("09876/54321");

            //Umkreis w�hlen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");

            //AGBs akzeptieren
            TestTools.ElementKlick("AGBs", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("WeitergabeVonDaten", driver);

            TestTools.ElementKlick("btnSpeichern", driver);

            Assert.AreEqual("E-Mail ist bereits registriert",TestTools.IDText�berpr�fen("VallidationSummary", driver));
            
           TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F11_B_001 
        public void RegistrationsFehlerEinverst�ndniss()
        {

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

            //Email bef�llen
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail")).Clear();
            driver.FindElement(By.Id("Mail")).SendKeys("projek10test@gmail.com");

            //Passwort bef�llen
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("12345678");

            //Passwort wiederholen bef�llen
            driver.FindElement(By.Id("PasswortVerification")).Clear();
            driver.FindElement(By.Id("PasswortVerification")).SendKeys("12345678");

            //Firmenname bef�llen
            driver.FindElement(By.Id("Firmenname")).Clear();
            driver.FindElement(By.Id("Firmenname")).SendKeys("Testfirma");

            //Organisationsform w�hlen
            driver.FindElement(By.Id("Organisationsform")).SendKeys("Caterer");

            //Stra�e bef�llen
            driver.FindElement(By.Id("Stra_e")).Clear();
            driver.FindElement(By.Id("Stra_e")).SendKeys("Teststra�e 0");

            //PLZ bef�llen
            driver.FindElement(By.Id("Postleitzahl")).Clear();
            driver.FindElement(By.Id("Postleitzahl")).SendKeys("12345");

            //Ort bef�llen
            driver.FindElement(By.Id("Ort")).Clear();
            driver.FindElement(By.Id("Ort")).SendKeys("Testen");

            //Anrede w�hlen
            driver.FindElement(By.Id("Anrede")).SendKeys("Herr");

            //Vorname bef�llen
            driver.FindElement(By.Id("Vorname")).Clear();
            driver.FindElement(By.Id("Vorname")).SendKeys("Test");

            //Nachname bef�llen
            driver.FindElement(By.Id("Nachname")).Clear();
            driver.FindElement(By.Id("Nachname")).SendKeys("Teste");

            //FunktionAnprechpartner bef�llen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys("Tester");

            //Telefon bef�llen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys("09876/54321");

            //Fax bef�llen
            driver.FindElement(By.Id("Fax")).Clear();
            driver.FindElement(By.Id("Fax")).SendKeys("09876/54321");

            //Internetadresse bef�llen
            driver.FindElement(By.Id("Internetadresse")).Clear();
            driver.FindElement(By.Id("Internetadresse")).SendKeys("www.test.test");

            //Umkreis w�hlen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");

            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.FehlerID("xxx", driver,1);

            Assert.AreEqual("Datenschutzbestimmungen m�ssen zugestimmt werden", TestTools.IDText�berpr�fen("DatenschutzValidation-error", driver));
            Assert.AreEqual("Sie m�ssen die AGBs akzeptieren", TestTools.IDText�berpr�fen("AGBValidation-error", driver));

            //AGBs akzeptieren
            TestTools.ElementKlick("AGBs", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("Datensch.", driver);
            //AGBs akzeptieren
            TestTools.ElementKlick("WeitergabeVonDaten", driver);


            TestTools.ElementKlick("btnSpeichern", driver);

            TestTools.FehlerID("xxx", driver, 1);

            Assert.AreEqual("Registrierung erfolgreich", TestTools.IDText�berpr�fen("RegErfolg",driver));

           TestTools.ElementKlick("StartButton", driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }









    }
}