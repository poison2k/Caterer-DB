using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestFixture]
    public class TestLoginFirefox
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:60003/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
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

        //     //Zwingt Selenium bis zu 10 Sekunden nach dem Element zu suchen!
        //     driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        //    //Sucht nach dem Element
        //    driver.FindElement(By.Id("Willkommen"));
        //    //Erwarteten Wert überprüfen
        //    Assert.AreEqual(baseURL, driver.Url.ToString());

            
        //    //Alternative Validierung
        //    //Assert.AreEqual("Willkommen caterer@test.de", driver.FindElement(By.Id("Willkommen")).Text);

        [Test]
        public void LoginTest()
        //T_U1-2_ALF_B_00 / T_U1-2_ALF_B_01
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("loginLinkbutton")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());

            //Variante Dropdown

            driver.FindElement(By.Id("DropdownLogout")).Click();
            driver.FindElement(By.Id("Ausloggen")).Click();
            driver.FindElement(By.Id("DropdownLogin")).Click();
            driver.FindElement(By.Id("loginLink")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("Willkommen"));
            Assert.AreEqual(baseURL, driver.Url.ToString());


        }
        [Test]
        public void AGBAufruf()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("AGB")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("AGB"));
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", driver.FindElement(By.Id("AGB")).Text);

        }
        [Test]
        public void DatenschutzAufruf()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("Datenschutz")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("Datenschutzbestimmungen"));
            Assert.AreEqual("Datenschutzbestimmungen", driver.FindElement(By.Id("Datenschutzbestimmungen")).Text);

        }
        [Test]
        public void KontaktAufruf()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("Kontakt")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("Ansprechpartner"));
            Assert.AreEqual("Ansprechpartner", driver.FindElement(By.Id("Ansprechpartner")).Text);

        }
    }
}
