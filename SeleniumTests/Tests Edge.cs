//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Text;

//namespace SeleniumTests
//{
//    [TestFixture]
//    public class TestEdge
//    {
//        private IWebDriver driver;
//        private StringBuilder verificationErrors;
//        private string baseURL;
//        private WebDriverWait wait;

//        [OneTimeSetUp]
//        public void OneTimeSetUp()
//        {
//            driver = new EdgeDriver();
//            baseURL = "http://localhost:60003/";
//            verificationErrors = new StringBuilder();
//            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
//        }

//        [OneTimeTearDown]
//        public void OneTimeTearDown()
//        {
//            try
//            {
//                driver.Quit();
//            }
//            catch (Exception)
//            {
//                // Ignore errors if unable to close the browser
//            }
//            Assert.AreEqual("", verificationErrors.ToString());
//        }

//        [SetUp]
//        public void SetupTest()
//        {
//            driver.Navigate().GoToUrl(baseURL);
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
//            driver.FindElement(By.Id("loginLinkbutton"));

//            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
//        }

//        [TearDown]
//        public void TeardownTest()
//        {
//        }

//        ////Zwingt Selenium bis zu 10 Sekunden nach dem Element zu suchen!
//        //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
//        ////Sucht nach dem Element
//        //driver.FindElement(By.Id("Willkommen"));
//        ////Erwarteten Wert überprüfen
//        //Assert.AreEqual(baseURL, driver.Url.ToString());

//        ////Alternative Validierung
//        //Assert.AreEqual("Willkommen caterer@test.de", driver.FindElement(By.Id("Willkommen")).Text);

//        [Test]
//        public void LoginTest1()
//        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
//        {

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Willkommen"));
//            Assert.AreEqual(baseURL, driver.Url.ToString());

//            driver.FindElement(By.Id("DropdownLogin")).Click();
//            driver.FindElement(By.Id("Ausloggen")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton"));

//            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
//        }

//        [Test]
//        public void LoginTest2()
//        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
//        {
//            //Variante Dropdown
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("DropdownLogin")).Click();
//            driver.FindElement(By.Id("loginLinkhead")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Willkommen"));
//            Assert.AreEqual(baseURL, driver.Url.ToString());

//            driver.FindElement(By.Id("DropdownLogin")).Click();
//            driver.FindElement(By.Id("Ausloggen")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
//            driver.FindElement(By.Id("loginLinkbutton"));

//            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
//        }

//        [Test]
//        public void LoginTest_FalschesPW()
//        //T_U1-2_ALF_B_05
//        {
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.Id("Passwort")).SendKeys("Start#21");
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("error2"));
//            Assert.AreEqual("E-Mail oder Passwort falsch", driver.FindElement(By.Id("error2")).Text);
//        }

//        [Test]
//        public void LoginTest_FalscheEmail()
//        //T_U1-2_ALF_B_06
//        {
//            driver.FindElement(By.Id("loginLinkbutton")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.d");
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("error2"));
//            Assert.AreEqual("E-Mail oder Passwort falsch", driver.FindElement(By.Id("error2")).Text);
//        }

//        [Test]
//        public void LoginTest_OhnePW()
//        //T_U1-2_ALF_B_07
//        {
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("error1"));
//            Assert.AreEqual("Das Feld \"Passwort\" ist erforderlich.", driver.FindElement(By.Id("error1")).Text);
//        }

//        [Test]
//        public void LoginTest_OhneEmail()
//        //T_U1-2_ALF_B_08
//        {
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email-error"));
//            Assert.AreEqual("Das Feld \"E-Mail\" ist erforderlich.", driver.FindElement(By.Id("Email-error")).Text);
//        }

//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        [Test]
//        public void KontaktAufruf1()
//        //T_U1-4_AL_B_01
//        {
//            //Variante Knopf
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Kontakt")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Ansprechp"));
//            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechp")).Text);
//        }

//        [Test]
//        public void KontaktAufruf2()
//        //T_U1-4_AL_B_01
//        {
//            //Variante Dropdown Logout
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            TestTools.ElementKlick("DropdownServiceLogout", driver);
//            driver.FindElement(By.Id("DropdownKontaktLogout")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Ansprechp"));
//            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechp")).Text);
//        }

//        [Test]
//        public void KontaktAufruf3()
//        //T_U1-4_AL_B_01
//        {
//            //Variante Dropdown Login
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("DropdownServiceLogin"));
//            driver.FindElement(By.Id("DropdownServiceLogin")).Click();
//            driver.FindElement(By.Id("DropdownKontaktLogin")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Ansprechp"));
//            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechp")).Text);

//            driver.FindElement(By.Id("DropdownLogin")).Click();
//            driver.FindElement(By.Id("Ausloggen")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton"));

//            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
//        }

//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        [Test]
//        public void DatenschutzAufruf1()
//        //T_U1-6_AL_B_01
//        {
//            //Variante Knopf
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Datenschutz")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Datenschutzbest"));
//            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);
//        }

//        [Test]
//        //T_U1-6_AL_B_01
//        public void DatenschutzAufruf2()
//        {
//            //Variante Dropdown Logout
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            TestTools.ElementKlick("DropdownServiceLogout", driver);
//            driver.FindElement(By.Id("DropdownDatenschutzLogout")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Datenschutzbest"));
//            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);
//        }

//        [Test]
//        //T_U1-6_AL_B_01
//        public void DatenschutzAufruf3()
//        {
//            //Variante Dropdown Login
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click(); ;

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("DropdownServiceLogin"));
//            driver.FindElement(By.Id("DropdownServiceLogin")).Click();
//            driver.FindElement(By.Id("DropdownDatenschutzLogin")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Datenschutzbest"));
//            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbest")).Text);

//            driver.FindElement(By.Id("DropdownLogin")).Click();
//            driver.FindElement(By.Id("Ausloggen")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton"));

//            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
//        }

//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        [Test]
//        public void AGBAufruf1()
//        //T_U1-7_AL_B_01
//        {
//            //Variante Knopf
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("AGB")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("AllgemGeschäftsbedingungen"));
//            Assert.AreEqual("Allgemeine Geschäftsbedingungen", driver.FindElement(By.Id("AllgemGeschäftsbedingungen")).Text);
//        }

//        [Test]
//        public void AGBAufruf2()
//        //T_U1-7_AL_B_01
//        {
//            //Variante Dropdown Logout
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            TestTools.ElementKlick("DropdownServiceLogout", driver);
//            driver.FindElement(By.Id("DropdownAGBLogout")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("AllgemGeschäftsbedingungen"));
//            Assert.AreEqual("Allgemeine Geschäftsbedingungen", driver.FindElement(By.Id("AllgemGeschäftsbedingungen")).Text);
//        }

//        [Test]
//        public void AGBAufruf3()
//        //T_U1-7_AL_B_01
//        {
//            //Variante Dropdown Login
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("Email")).Clear();
//            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
//            driver.FindElement(By.Id("Passwort")).Clear();
//            driver.FindElement(By.Id("Passwort")).SendKeys("Start#22");
//            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("DropdownServiceLogin"));
//            driver.FindElement(By.Id("DropdownServiceLogin")).Click();
//            driver.FindElement(By.Id("DropdownAGBLogin")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("AllgemGeschäftsbedingungen"));
//            Assert.AreEqual("Allgemeine Geschäftsbedingungen", driver.FindElement(By.Id("AllgemGeschäftsbedingungen")).Text);

//            driver.FindElement(By.Id("DropdownLogin")).Click();
//            driver.FindElement(By.Id("Ausloggen")).Click();

//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("loginLinkbutton"));

//            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
//        }

//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//    }
//}
