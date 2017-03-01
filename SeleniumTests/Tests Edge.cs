using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestFixture]
    public class TestEdge
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new EdgeDriver();
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
            TestTools.Login�berpr�fen(driver);

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

            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);

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
        public void LoginTest_FalschesPW()
        //T_U1-2_ALF_B_05
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#21", driver);
            Assert.AreEqual("E-Mail oder Passwort falsch", TestTools.IDText�berpr�fen("error2", driver));
        }

        [Test]
        public void LoginTest_FalscheEmail()
        //T_U1-2_ALF_B_06
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("caterer@test.d", "Start#22", driver);
            Assert.AreEqual("E-Mail oder Passwort falsch", TestTools.IDText�berpr�fen("error2", driver));

        }

        [Test]
        public void LoginTest_OhnePW()
        //T_U1-2_ALF_B_07
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("loginLinkbutton", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "", driver);
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", TestTools.IDText�berpr�fen("error1", driver));

        }

        [Test]
        public void LoginTest_OhneEmail()
        //T_U1-2_ALF_B_08
        {
            TestTools.Login�berpr�fen(driver);

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
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));

        }

        [Test]
        public void KontaktAufruf2()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownKontaktLogout", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
        }

        [Test]
        public void KontaktAufruf3()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Login
            TestTools.Login�berpr�fen(driver);

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
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf2()
        {
            //Variante Dropdown Logout
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogout", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf3()
        {
            //Variante Dropdown Login
            TestTools.Login�berpr�fen(driver);

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
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

        }

        [Test]
        public void AGBAufruf2()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownAGBLogout", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));

        }

        [Test]
        public void AGBAufruf3()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Login
            TestTools.Login�berpr�fen(driver);

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
            TestTools.Login�berpr�fen(driver);

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
            TestTools.Login�berpr�fen(driver);

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
            TestTools.Login�berpr�fen(driver);

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
            TestTools.Login�berpr�fen(driver);

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
            TestTools.Login�berpr�fen(driver);

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
            Assert.AreEqual(false, TestTools.FehlerID("Nachname-error", driver));

            //FunktionAnprechpartner bef�llen
            driver.FindElement(By.Id("FunktionAnsprechpartner")).Clear();
            driver.FindElement(By.Id("FunktionAnsprechpartner")).SendKeys("Tester");
            Assert.AreEqual(false, TestTools.FehlerID("FunktionAnsprechpartner-error", driver));

            //Telefon bef�llen
            driver.FindElement(By.Id("Telefon")).Clear();
            driver.FindElement(By.Id("Telefon")).SendKeys("09876/54321");
            Assert.AreEqual(false, TestTools.FehlerID("Telefon-error", driver));

            //Umkreis w�hlen
            driver.FindElement(By.Id("Lieferumkreis")).SendKeys("Bis 30 km");
            Assert.AreEqual(false, TestTools.FehlerID("Lieferumkreis-error", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }
        [Test]
        //T_U1-3_F08_B_001 
        public void RegistrationsFehlerDoppelMail()
        {
            TestTools.Login�berpr�fen(driver);

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

            Assert.AreEqual("E-Mail ist bereits registriert", TestTools.IDText�berpr�fen("VallidationSummary", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }
        [Test]
        //T_U1-3_F11_B_001 & T_U1-3_F06_B_001
        public void RegistrationsFehlerEinverst�ndniss()
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("registerLink", driver);

            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));

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

            TestTools.FehlerID("xxx", driver, 1);

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

            Assert.AreEqual("Registrierung erfolgreich", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Login mit korrekten Daten durchf�hren und testen der Fehlermeldung f�r fehlende Email-Verification
            //T_U1-3_F06_B_001
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("projek1test@gmail.com", "12345678", driver);
            Assert.AreEqual("Registrierung noch nicht abgeschlossen", TestTools.IDText�berpr�fen("RegMailValidation-error", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void PersDaten�ndern()
        //T_C2-1_F01_B_001 
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();


            //Leeren aller Daten
            TestTools.DatenEingeben("", "Firmenname", driver);
            //TestTools.DatenEingeben("Bitte w�hlen...", "Organisationsform", driver);
            new SelectElement(driver.FindElement(By.Id("Organisationsform"))).SelectByIndex(0);
            TestTools.DatenEingeben("", "Stra_e", driver);
            TestTools.DatenEingeben("", "Postleitzahl", driver);
            TestTools.DatenEingeben("", "Ort", driver);
            //TestTools.DatenEingeben("Bitte w�hlen...", "Anrede", driver);
            new SelectElement(driver.FindElement(By.Id("Anrede"))).SelectByIndex(0);
            TestTools.DatenEingeben("", "Vorname", driver);
            TestTools.DatenEingeben("", "Nachname", driver);
            TestTools.DatenEingeben("", "FunktionAnsprechpartner", driver);
            TestTools.DatenEingeben("", "Telefon", driver);
            TestTools.DatenEingeben("", "Fax", driver);
            TestTools.DatenEingeben("", "Internetadresse", driver);
            //TestTools.DatenEingeben("Bitte w�hlen...", "Lieferumkreis", driver);
            new SelectElement(driver.FindElement(By.Id("Lieferumkreis"))).SelectByIndex(0);

            TestTools.ElementKlick("btnSpeichern", driver);

            //Fehlermeldungen �berpr�fen
            //Firma
            Assert.AreEqual("Das Feld \"Firmenname\" ist erforderlich.", TestTools.IDText�berpr�fen("Firmenname-error", driver));
            Assert.AreEqual("Das Feld \"Organisationsform\" ist erforderlich.", TestTools.IDText�berpr�fen("Organisationsform-error", driver));
            Assert.AreEqual("Das Feld \"Stra�e\" ist erforderlich.", TestTools.IDText�berpr�fen("Stra_e-error", driver));
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

            //L�schen unbest�tigt abbrechen
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.FehlerID("xxx", driver, 1);

            //Pr�fen ob alte Daten vorhanden sind
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));
            //Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Organisationsform", driver));
            Assert.AreEqual("Holzweg 1", TestTools.TextboxText�berpr�fen("Stra_e", driver));
            Assert.AreEqual("87654", TestTools.TextboxText�berpr�fen("Postleitzahl", driver));
            Assert.AreEqual("Woodway", TestTools.TextboxText�berpr�fen("Ort", driver));
            Assert.AreEqual("Herr", TestTools.TextboxText�berpr�fen("Anrede", driver));
            Assert.AreEqual("Max", TestTools.TextboxText�berpr�fen("Vorname", driver));
            Assert.AreEqual("Mustermann", TestTools.TextboxText�berpr�fen("Nachname", driver));
            Assert.AreEqual("Chef", TestTools.TextboxText�berpr�fen("FunktionAnsprechpartner", driver));
            Assert.AreEqual("01234 - 56789", TestTools.TextboxText�berpr�fen("Telefon", driver));
            Assert.AreEqual("01234 - 99999", TestTools.TextboxText�berpr�fen("Fax", driver));
            Assert.AreEqual("www.AYCE.de", TestTools.TextboxText�berpr�fen("Internetadresse", driver));
            //Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Lieferumkreis", driver));

            //Daten �ndern
            TestTools.DatenEingeben("Testfirma", "Firmenname", driver);
            new SelectElement(driver.FindElement(By.Id("Organisationsform"))).SelectByIndex(1);
            TestTools.DatenEingeben("Teststra�e 0", "Stra_e", driver);
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
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            //Pr�fen ob alte Daten ge�ndert worden
            Assert.AreEqual("Testfirma", TestTools.TextboxText�berpr�fen("Firmenname", driver));
            Assert.AreEqual("Mensaverein", TestTools.TextboxText�berpr�fen("Organisationsform", driver));
            Assert.AreEqual("Teststra�e 0", TestTools.TextboxText�berpr�fen("Stra_e", driver));
            Assert.AreEqual("12345", TestTools.TextboxText�berpr�fen("Postleitzahl", driver));
            Assert.AreEqual("Testen", TestTools.TextboxText�berpr�fen("Ort", driver));
            Assert.AreEqual("Herr", TestTools.TextboxText�berpr�fen("Anrede", driver));
            Assert.AreEqual("Test", TestTools.TextboxText�berpr�fen("Vorname", driver));
            Assert.AreEqual("Teste", TestTools.TextboxText�berpr�fen("Nachname", driver));
            Assert.AreEqual("Tester", TestTools.TextboxText�berpr�fen("FunktionAnsprechpartner", driver));
            Assert.AreEqual("09876/54321", TestTools.TextboxText�berpr�fen("Telefon", driver));
            Assert.AreEqual("09876/54321", TestTools.TextboxText�berpr�fen("Fax", driver));
            Assert.AreEqual("www.test.test", TestTools.TextboxText�berpr�fen("Internetadresse", driver));
            Assert.AreEqual("Bis 10 km", TestTools.TextboxText�berpr�fen("Lieferumkreis", driver));

            TestTools.FehlerID("xxx", driver, 1);

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
            TestTools.DatenEingeben("www.AYCE.de", "Internetadresse", driver);

            TestTools.ElementKlick("btnSpeichern", driver);


            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);
            TestTools.FehlerID("xxx", driver, 1);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }

        [Test]
        public void PersDaten�ndern2()
        //T_C2-1_F02_B_001 
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            //Daten �ndern �ber AGB Fu�zeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Datenschutzbestimmungen Fu�zeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Kontakt Fu�zeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Impressum Fu�zeile abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("Impressum", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber AGB Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownAGBLogin", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Datenschutzbestimmungen Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogin", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Kontakt Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownKontaktLogin", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Impressum Dropdown abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownImpressumLogin", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Eigene Daten abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber StartButton abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            driver.Navigate().GoToUrl(baseURL);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));

            //Daten �ndern �ber Logout abbrechen
            TestTools.DatenEingeben("Test", "Firmenname", driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);
            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();
            Assert.AreEqual("AllYouCanEat GmbH", TestTools.TextboxText�berpr�fen("Firmenname", driver));


            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);
            TestTools.FehlerID("xxx", driver, 1);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }

        [Test]
        public void PWV�ndern()
        //T_C2-1_F03_B_001
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //AGBs Fu�zeile
            TestTools.ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Datenschutzbestimmungen Fu�zeile
            TestTools.ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Kontakt Fu�zeile
            TestTools.ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Impressum Fu�zeile
            TestTools.ElementKlick("Impressum", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //AGBs Dropdown
            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownAGBLogin", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Datenschutzbestimmungen Dropdown
            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogin", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Kontakt Dropdown
            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownKontaktLogin", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //Impressum Dropdown
            TestTools.ElementKlick("DropdownServiceLogin", driver);
            TestTools.ElementKlick("DropdownImpressumLogin", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            //�nderung durchf�hren
            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer1@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Passwort �ndern")).Click();
            Assert.AreEqual("Neues Passwort", TestTools.IDText�berpr�fen("PasswortChange", driver));
            TestTools.DatenEingeben("ZZZZZZZZ", "Passwort", driver);
            TestTools.DatenEingeben("ZZZZZZZZ", "PasswortVerification", driver);
            TestTools.ElementKlick("Abschicken", driver);
            Assert.AreEqual("Ihr Passwort wurde erfolgreich ge�ndert!", TestTools.IDText�berpr�fen("Passwort", driver));


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
        public void PWVergessen1()
        //T_C2-2_F02_B_001
        {
            TestTools.Login�berpr�fen(driver);

            //TestTools.ElementKlick("DropdownLogout", driver);
            //TestTools.ElementKlick("loginLinkhead", driver);
            //TestTools.ElementKlick("PWVergessen", driver);
            //driver.FindElement(By.LinkText("Passwort vergessen")).Click();


            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));

            //AGBs Fu�zeile
            TestTools.ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //Datenschutzbestimmungen Fu�zeile
            TestTools.ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //Kontakt Fu�zeile
            TestTools.ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //Impressum Fu�zeile
            TestTools.ElementKlick("Impressum", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //AGBs Dropdown
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownAGBLogout", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //Datenschutzbestimmungen Dropdown
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogout", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //Kontakt Dropdown
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownKontaktLogout", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //Impressum Dropdown
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownImpressumLogout", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);


        }

        [Test]
        public void PWVergessen2()
        //T_C2-2_F03_B_001
        {
            TestTools.Login�berpr�fen(driver);

            //TestTools.ElementKlick("DropdownLogout", driver);
            //TestTools.ElementKlick("loginLinkhead", driver);
            //TestTools.ElementKlick("PWVergessen", driver);


            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //Login Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            Assert.AreEqual("Login", TestTools.IDText�berpr�fen("LoginPage", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");

            //Registrierung Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);


        }
        [Test]
        public void PWVergessen3()
        //T_C2-2_F04_B_001
        {
            TestTools.Login�berpr�fen(driver);

            //TestTools.ElementKlick("DropdownLogout", driver);
            //TestTools.ElementKlick("loginLinkhead", driver);
            //TestTools.ElementKlick("PWVergessen", driver);

            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //AGBs Fu�zeile
            TestTools.ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Datenschutzbestimmungen Fu�zeile
            TestTools.ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Kontakt Fu�zeile
            TestTools.ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Impressum Fu�zeile
            TestTools.ElementKlick("Impressum", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //AGBs Dropdown
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownAGBLogout", driver);
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", TestTools.IDText�berpr�fen("AllgemGesch�ftsbedingungen", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Datenschutzbestimmungen Dropdown
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownDatenschutzLogout", driver);
            Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDText�berpr�fen("Datenschutzbest", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Kontakt Dropdown
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownKontaktLogout", driver);
            Assert.AreEqual("Ansprechpartner", TestTools.IDText�berpr�fen("Ansprechp", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Impressum Dropdown
            TestTools.ElementKlick("DropdownServiceLogout", driver);
            TestTools.ElementKlick("DropdownImpressumLogout", driver);
            Assert.AreEqual("Impressum", TestTools.IDText�berpr�fen("Impr", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);


        }
        [Test]
        public void PWVergessen5()
        //T_C2-2_F05_B_001
        {
            TestTools.Login�berpr�fen(driver);

            //TestTools.ElementKlick("DropdownLogout", driver);
            //TestTools.ElementKlick("loginLinkhead", driver);
            //TestTools.ElementKlick("PWVergessen", driver);

            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //StartButton
            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Login Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            Assert.AreEqual("Login", TestTools.IDText�berpr�fen("LoginPage", driver));
            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));
            TestTools.DatenEingeben("Test@test.de", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            Assert.AreEqual("Best�tigung der Passwort�nderung", TestTools.IDText�berpr�fen("RegErfolg", driver));

            //Registrierung Dropdown
            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("registerLinkhead", driver);
            Assert.AreEqual("Registrierung", TestTools.IDText�berpr�fen("RegSeite", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);


        }
        [Test]
        public void PWVergessen6()
        //T_C2-2_F11_B_001
        {
            TestTools.Login�berpr�fen(driver);

            //TestTools.ElementKlick("DropdownLogout", driver);
            //TestTools.ElementKlick("loginLinkhead", driver);
            //TestTools.ElementKlick("PWVergessen", driver);

            driver.Navigate().GoToUrl("http://localhost:60003/Account/PasswordRequest");
            Assert.AreEqual("", TestTools.TextboxText�berpr�fen("Mail", driver));

            TestTools.DatenEingeben("", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDText�berpr�fen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDText�berpr�fen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test@", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", TestTools.IDText�berpr�fen("PWRecoveryFehler", driver));

            TestTools.DatenEingeben("projekt10test@gmail", "Mail", driver);
            TestTools.ElementKlick("PWRecoveryAbschicken", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("Das Feld E-Mail enth�lt keine g�ltige E-Mail-Adresse.", TestTools.IDText�berpr�fen("PWRecoveryFehler", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void DatenL�schen1()
        //T_C2-5_F02_B_001 
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("L�schenButton", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("L�schen best�tigen", TestTools.IDText�berpr�fen("L�schenBest", driver));

            TestTools.ElementKlick("btnModalCancel", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("Eigene Daten", TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);
            TestTools.FehlerID("xxx", driver, 1);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }

        [Test]
        public void DatenL�schen2()
        //T_C2-5_F03_B_001 
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer@test.de", "Start#22", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("L�schenButton", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("L�schen best�tigen", TestTools.IDText�berpr�fen("L�schenBest", driver));

            TestTools.ElementKlick("L�schenCancel", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("Eigene Daten", TestTools.IDText�berpr�fen("RegSeite", driver));

            TestTools.ElementKlick("DropdownLogin", driver);
            TestTools.ElementKlick("Ausloggen", driver);
            TestTools.FehlerID("xxx", driver, 1);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }

        [Test]
        public void XXDatenL�schen3()
        //T_C2-5_F04_B_001 
        {
            TestTools.Login�berpr�fen(driver);

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer1@test.de", "ZZZZZZZZ", driver);

            TestTools.ElementKlick("DropdownLogin", driver);
            driver.FindElement(By.LinkText("Eigene Daten")).Click();

            TestTools.ElementKlick("L�schenButton", driver);
            TestTools.FehlerID("xxx", driver, 1);
            Assert.AreEqual("L�schen best�tigen", TestTools.IDText�berpr�fen("L�schenBest", driver));

            TestTools.ElementKlick("btnModalDelete", driver);
            Assert.AreEqual("Ihr Account wurde erfolgreich gel�scht!", TestTools.IDText�berpr�fen("Gel�scht", driver));

            TestTools.ElementKlick("DropdownLogout", driver);
            TestTools.ElementKlick("loginLinkhead", driver);
            TestTools.LoginDatenEingeben("caterer1@test.de", "ZZZZZZZZ", driver);
            Assert.AreEqual("E-Mail oder Passwort falsch", TestTools.IDText�berpr�fen("error2", driver));


            TestTools.ElementKlick("StartButton", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

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














