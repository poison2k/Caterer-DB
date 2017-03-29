using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Services;
using System;
using System.Text;

namespace SeleniumTests
{
    public abstract class TestInitialize
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        protected string PWRequestURL;
        protected WebDriverWait wait;

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
            driver.FindElement(By.Id(ObjektIDs_Allgemein.LoginButton));

            Assert.AreEqual(Hinweise.Startseite, driver.Title);
        }

        [TearDown]
        public void TeardownTest()
        {
        }
    }
}

//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumTests.Services;
//using System;

//namespace SeleniumTests
//{
//    [TestFixture]
//    [Category("Userstory_C2_1")]
//    public class Userstory_U1_4 : TestInitialize
//    {