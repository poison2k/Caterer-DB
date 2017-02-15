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
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            driver.FindElement(By.Id("DropdownLogin")).Click();
            driver.FindElement(By.Id("Ausloggen")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }

        [Test]
        public void LoginTest2()
        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
        {
            //Variante Dropdown
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("loginLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            driver.FindElement(By.Id("DropdownLogin")).Click();
            driver.FindElement(By.Id("Ausloggen")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }

        [Test]
        public void LoginTest_FalschesPW()
        //T_U1-2_ALF_B_05
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("Start#21");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("error2"));
            Assert.AreEqual("E-Mail oder Passwort falsch", driver.FindElement(By.Id("error2")).Text);
        }

        [Test]
        public void LoginTest_FalscheEmail()
        //T_U1-2_ALF_B_06
        {
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.d");
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("error2"));
            Assert.AreEqual("E-Mail oder Passwort falsch", driver.FindElement(By.Id("error2")).Text);
        }

        [Test]
        public void LoginTest_OhnePW()
        //T_U1-2_ALF_B_07
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("error1"));
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", driver.FindElement(By.Id("error1")).Text);
        }

        [Test]
        public void LoginTest_OhneEmail()
        //T_U1-2_ALF_B_08
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email-error"));
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", driver.FindElement(By.Id("Email-error")).Text);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void KontaktAufruf1()
        //T_U1-4_AL_B_01
        {
            //Variante Knopf
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Kontakt")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Ansprechp"));
            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechp")).Text);
        }

        [Test]
        public void KontaktAufruf2()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Logout
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogout")).Click();
            driver.FindElement(By.Id("DropdownKontaktLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Ansprechp"));
            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechp")).Text);
        }

        [Test]
        public void KontaktAufruf3()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Login
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogin"));
            driver.FindElement(By.Id("DropdownServiceLogin")).Click();
            driver.FindElement(By.Id("DropdownKontaktLogin")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Ansprechp"));
            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechp")).Text);

            driver.FindElement(By.Id("DropdownLogin")).Click();
            driver.FindElement(By.Id("Ausloggen")).Click();

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
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Datenschutz")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Datenschutzbest"));
            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf2()
        {
            //Variante Dropdown Logout
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogout")).Click();
            driver.FindElement(By.Id("DropdownDatenschutzLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Datenschutzbest"));
            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf3()
        {
            //Variante Dropdown Login
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click(); ;

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogin"));
            driver.FindElement(By.Id("DropdownServiceLogin")).Click();
            driver.FindElement(By.Id("DropdownDatenschutzLogin")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Datenschutzbest"));
            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);

            driver.FindElement(By.Id("DropdownLogin")).Click();
            driver.FindElement(By.Id("Ausloggen")).Click();

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
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AGB")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AllgemGesch�ftsbedingungen"));
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", driver.FindElement(By.Id("AllgemGesch�ftsbedingungen")).Text);
        }

        [Test]
        public void AGBAufruf2()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Logout
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogout")).Click();
            driver.FindElement(By.Id("DropdownAGBLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AllgemGesch�ftsbedingungen"));
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", driver.FindElement(By.Id("AllgemGesch�ftsbedingungen")).Text);
        }

        [Test]
        public void AGBAufruf3()
        //T_U1-7_AL_B_01
        {
            //Variante Dropdown Login
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogin"));
            driver.FindElement(By.Id("DropdownServiceLogin")).Click();
            driver.FindElement(By.Id("DropdownAGBLogin")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AllgemGesch�ftsbedingungen"));
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", driver.FindElement(By.Id("AllgemGesch�ftsbedingungen")).Text);

            driver.FindElement(By.Id("DropdownLogin")).Click();
            driver.FindElement(By.Id("Ausloggen")).Click();

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
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("registerLink")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("StartButton")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("StartButton"));
            driver.FindElement(By.Id("StartButton")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }
        [Test]
        //T_U1-3_F02_B_001 
        public void RegistrationsSeitenLinks()
        {
            //Variante Links
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout"));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("registerLinkhead"));
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //AGB
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AGB")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AllgemGesch�ftsbedingungen"));
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", driver.FindElement(By.Id("AllgemGesch�ftsbedingungen")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //Datenschutz
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Datenschutz")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Datenschutzbest"));
            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //Kontakt
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Kontakt")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Ansprechp"));
            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechp")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //Impressum
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Impressum")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Impr"));
            Assert.AreEqual("Impressum", driver.FindElement(By.Id("Impr")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //AGBs bei Lesebest�tigung
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegAGB")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AllgemGesch�ftsbedingungen"));
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", driver.FindElement(By.Id("AllgemGesch�ftsbedingungen")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //Datenschutz bei Lesebest�tigung
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegDatenschutz")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Datenschutzbest"));
            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("StartButton"));
            driver.FindElement(By.Id("StartButton")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F03_B_001 
        public void RegistrationsDropdownLinks()
        {
            //Variante Dropdown
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout"));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("registerLinkhead"));
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //AGB
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogout")).Click();
            driver.FindElement(By.Id("DropdownAGBLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AllgemGesch�ftsbedingungen"));
            Assert.AreEqual("Allgemeine Gesch�ftsbedingungen", driver.FindElement(By.Id("AllgemGesch�ftsbedingungen")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //Datenschutz
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogout")).Click();
            driver.FindElement(By.Id("DropdownDatenschutzLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Datenschutzbest"));
            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //Kontakt
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogout")).Click();
            driver.FindElement(By.Id("DropdownKontaktLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Ansprechp"));
            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechp")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("registerLinkhead")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            //Impressum
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DropdownServiceLogout")).Click();
            driver.FindElement(By.Id("DropdownImpressumLogout")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Impr"));
            Assert.AreEqual("Impressum", driver.FindElement(By.Id("Impr")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("StartButton"));
            driver.FindElement(By.Id("StartButton")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F04_B_001 
        public void RegistrationsFehler()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("registerLink")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("btnSpeichern"));
            driver.FindElement(By.Id("btnSpeichern")).Click();

            //Account
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail-error"));
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", driver.FindElement(By.Id("Mail-error")).Text);
            driver.FindElement(By.Id("Passwort-error"));
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", driver.FindElement(By.Id("Passwort-error")).Text);
            driver.FindElement(By.Id("PasswortVerification-error"));
            Assert.AreEqual("Das Feld \"Passwort Wiederholung\" ist erforderlich.", driver.FindElement(By.Id("PasswortVerification-error")).Text);

            //Firma
            driver.FindElement(By.Id("Firmenname-error"));
            Assert.AreEqual("Das Feld \"Firmenname\" ist erforderlich.", driver.FindElement(By.Id("Firmenname-error")).Text);
            driver.FindElement(By.Id("Organisationsform-error"));
            Assert.AreEqual("Das Feld \"Organisationsform\" ist erforderlich.", driver.FindElement(By.Id("Organisationsform-error")).Text);
            driver.FindElement(By.Id("Stra_e-error"));
            Assert.AreEqual("Das Feld \"Stra�e und Hausnummer\" ist erforderlich.", driver.FindElement(By.Id("Stra_e-error")).Text);
            driver.FindElement(By.Id("Postleitzahl-error"));
            Assert.AreEqual("Das Feld \"Postleitzahl\" ist erforderlich.", driver.FindElement(By.Id("Postleitzahl-error")).Text);
            driver.FindElement(By.Id("Ort-error"));
            Assert.AreEqual("Das Feld \"Ort\" ist erforderlich.", driver.FindElement(By.Id("Ort-error")).Text);

            //Ansprechpartner
            driver.FindElement(By.Id("Anrede-error"));
            Assert.AreEqual("Das Feld \"Anrede\" ist erforderlich.", driver.FindElement(By.Id("Anrede-error")).Text);
            driver.FindElement(By.Id("Vorname-error"));
            Assert.AreEqual("Das Feld \"Vorname\" ist erforderlich.", driver.FindElement(By.Id("Vorname-error")).Text);
            driver.FindElement(By.Id("Nachname-error"));
            Assert.AreEqual("Das Feld \"Nachname\" ist erforderlich.", driver.FindElement(By.Id("Nachname-error")).Text);
            driver.FindElement(By.Id("FunktionAnsprechpartner-error"));
            Assert.AreEqual("Das Feld \"Funktion des Ansprechpartners\" ist erforderlich.", driver.FindElement(By.Id("FunktionAnsprechpartner-error")).Text);

            //Erreichbarkeit
            driver.FindElement(By.Id("Telefon-error"));
            Assert.AreEqual("Das Feld \"Telefon\" ist erforderlich.", driver.FindElement(By.Id("Telefon-error")).Text);

            //Sonstiges
            driver.FindElement(By.Id("Lieferumkreis-error"));
            Assert.AreEqual("Das Feld \"Lieferumkreis\" ist erforderlich.", driver.FindElement(By.Id("Lieferumkreis-error")).Text);


            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("StartButton"));
            driver.FindElement(By.Id("StartButton")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }
        [Test]
        //T_U1-3_F05_B_001 
        public void RegistrationsFehler2()
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("registerLink"));
            driver.FindElement(By.Id("registerLink")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("btnSpeichern")).Click();

            //Account
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Mail-error"));
            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", driver.FindElement(By.Id("Mail-error")).Text);
            driver.FindElement(By.Id("Passwort-error"));
            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", driver.FindElement(By.Id("Passwort-error")).Text);
            driver.FindElement(By.Id("PasswortVerification-error"));
            Assert.AreEqual("Das Feld \"Passwort Wiederholung\" ist erforderlich.", driver.FindElement(By.Id("PasswortVerification-error")).Text);

            //Firma
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Firmenname-error"));
            Assert.AreEqual("Das Feld \"Firmenname\" ist erforderlich.", driver.FindElement(By.Id("Firmenname-error")).Text);
            driver.FindElement(By.Id("Organisationsform-error"));
            Assert.AreEqual("Das Feld \"Organisationsform\" ist erforderlich.", driver.FindElement(By.Id("Organisationsform-error")).Text);
            driver.FindElement(By.Id("Stra_e-error"));
            Assert.AreEqual("Das Feld \"Stra�e und Hausnummer\" ist erforderlich.", driver.FindElement(By.Id("Stra_e-error")).Text);
            driver.FindElement(By.Id("Postleitzahl-error"));
            Assert.AreEqual("Das Feld \"Postleitzahl\" ist erforderlich.", driver.FindElement(By.Id("Postleitzahl-error")).Text);
            driver.FindElement(By.Id("Ort-error"));
            Assert.AreEqual("Das Feld \"Ort\" ist erforderlich.", driver.FindElement(By.Id("Ort-error")).Text);

            //Ansprechpartner
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Anrede-error"));
            Assert.AreEqual("Das Feld \"Anrede\" ist erforderlich.", driver.FindElement(By.Id("Anrede-error")).Text);
            driver.FindElement(By.Id("Vorname-error"));
            Assert.AreEqual("Das Feld \"Vorname\" ist erforderlich.", driver.FindElement(By.Id("Vorname-error")).Text);
            driver.FindElement(By.Id("Nachname-error"));
            Assert.AreEqual("Das Feld \"Nachname\" ist erforderlich.", driver.FindElement(By.Id("Nachname-error")).Text);
            driver.FindElement(By.Id("FunktionAnsprechpartner-error"));
            Assert.AreEqual("Das Feld \"Funktion des Ansprechpartners\" ist erforderlich.", driver.FindElement(By.Id("FunktionAnsprechpartner-error")).Text);

            //Erreichbarkeit
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Telefon-error"));
            Assert.AreEqual("Das Feld \"Telefon\" ist erforderlich.", driver.FindElement(By.Id("Telefon-error")).Text);

            //Sonstiges
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("Lieferumkreis-error"));
            Assert.AreEqual("Das Feld \"Lieferumkreis\" ist erforderlich.", driver.FindElement(By.Id("Lieferumkreis-error")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));


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


            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("StartButton"));
            driver.FindElement(By.Id("StartButton")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F08_B_001 
        public void RegistrationsFehlerDoppelMail()
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("registerLink"));
            driver.FindElement(By.Id("registerLink")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

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
            driver.FindElement(By.Id("AGBs")).Click();
            //AGBs akzeptieren
            driver.FindElement(By.Id("Datensch.")).Click();
            //AGBs akzeptieren
            driver.FindElement(By.Id("WeitergabeVonDaten")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("btnSpeichern"));
            driver.FindElement(By.Id("btnSpeichern")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("VallidationSummary"));

            Assert.AreEqual("E-Mail ist bereits registriert", driver.FindElement(By.Id("VallidationSummary")).Text);


            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("StartButton"));
            driver.FindElement(By.Id("StartButton")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }
        [Test]
        //T_U1-3_F11_B_001 
        public void RegistrationsFehlerEinverst�ndniss()
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("registerLink"));
            driver.FindElement(By.Id("registerLink")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegSeite"));
            Assert.AreEqual("Registrierung", driver.FindElement(By.Id("RegSeite")).Text);

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
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("btnSpeichern"));
            driver.FindElement(By.Id("btnSpeichern")).Click();

            TestTools.FehlerID("xxx", driver,1);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("DatenschutzValidation-error"));
            Assert.AreEqual("Datenschutzbestimmungen m�ssen zugestimmt werden", driver.FindElement(By.Id("DatenschutzValidation-error")).Text);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("AGBValidation-error"));
            Assert.AreEqual("Sie m�ssen die AGBs akzeptieren", driver.FindElement(By.Id("AGBValidation-error")).Text);

            //AGBs akzeptieren
            driver.FindElement(By.Id("AGBs")).Click();
            //AGBs akzeptieren
            driver.FindElement(By.Id("Datensch.")).Click();
            //AGBs akzeptieren
            driver.FindElement(By.Id("WeitergabeVonDaten")).Click();


            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("btnSpeichern"));
            driver.FindElement(By.Id("btnSpeichern")).Click();

            TestTools.FehlerID("xxx", driver, 1);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("RegErfolg"));
            Assert.AreEqual("Registrierung erfolgreich", driver.FindElement(By.Id("RegErfolg")).Text);


            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("StartButton"));
            driver.FindElement(By.Id("StartButton")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));

            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
        }








        //private void Testsub()
        //{


        //}
    }
}