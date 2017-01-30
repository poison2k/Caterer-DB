using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestFixture]
    public class TestLoginChrome
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
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

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl(baseURL + "Account/Login");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("caterer@test.de");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Start#22");
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

            //Zwingt Selenium bis zu 10 Sekunden nach dem Element zu suchen!
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //Sucht nach dem Element
            driver.FindElement(By.Id("Willkommen"));
            //Erwarteten Wert überprüfen
            Assert.AreEqual(baseURL, driver.Url.ToString());

            //Alternative Validierung
            //Assert.AreEqual("Willkommen caterer@test.de", driver.FindElement(By.Id("Willkommen")).Text);
            
        }
        [Test]
        public void AGBAufruf()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("AGB")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.AreEqual( baseURL + "home/AGB", driver.Url.ToString());
        }
    }
}
