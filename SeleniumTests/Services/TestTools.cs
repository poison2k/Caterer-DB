using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Services
{
    public static class TestTools
    {

        public static bool FehlerID(string id, IWebDriver driver, Int16 zeit=0)
        {

            bool present = false;

            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
                driver.FindElement(By.Id(id));
                present = true;
            }
            catch (NoSuchElementException)
            {
                present = false;
            }
            return present;

        }

        public static String IDTextÜberprüfen(string id, IWebDriver driver, Int16 zeit=5)
        {

            String Text = "";
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
                driver.FindElement(By.Id(id));
                Text = driver.FindElement(By.Id(id)).Text;

            }
            return Text;

        }

        public static String TextboxTextÜberprüfen(string id, IWebDriver driver, Int16 zeit=5)
        {

            String Text = "";
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
                driver.FindElement(By.Id(id));
                Text = driver.FindElement(By.Id(id)).GetAttribute("value");

            }
            return Text;

        }

        public static void LoginÜberprüfen(IWebDriver driver)
        {


            if (FehlerID("DropdownLogin", driver))
            {
                ElementKlick("DropdownLogin", driver);
                ElementKlick("Ausloggen", driver);
            }
            else
            {

            }


        }

        public static void ElementKlick(string id, IWebDriver driver, Int16 zeit=5)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
            driver.FindElement(By.Id(id));
            driver.FindElement(By.Id(id)).Click();
        }

        public static void LoginDatenEingeben(String email, String pw, IWebDriver driver, Int16 zeit=5)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys(pw);
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();
        }

        public static void DatenEingeben(String daten, string id, IWebDriver driver, Int16 zeit=5)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
            driver.FindElement(By.Id(id)).Clear();
            driver.FindElement(By.Id(id)).SendKeys(daten);

        }


    }
}

////AGBs Fußzeile
//TestTools.ElementKlick("AGB", driver);
//Assert.AreEqual("Allgemeine Geschäftsbedingungen", TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

////Datenschutzbestimmungen Fußzeile
//TestTools.ElementKlick("Datenschutz", driver);
//Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDTextÜberprüfen("Datenschutzbest", driver));

////Kontakt Fußzeile
//TestTools.ElementKlick("Kontakt", driver);
//Assert.AreEqual("Ansprechpartner", TestTools.IDTextÜberprüfen("Ansprechp", driver));

////Impressum Fußzeile
//TestTools.ElementKlick("Impressum", driver);
//Assert.AreEqual("Impressum", TestTools.IDTextÜberprüfen("Impr", driver));

////AGBs Dropdown
//TestTools.ElementKlick("DropdownServiceLogout", driver);
//TestTools.ElementKlick("DropdownAGBLogout", driver);
//Assert.AreEqual("Allgemeine Geschäftsbedingungen", TestTools.IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

////Datenschutzbestimmungen Dropdown
//TestTools.ElementKlick("DropdownServiceLogout", driver);
//TestTools.ElementKlick("DropdownDatenschutzLogout", driver);
//Assert.AreEqual("Datenschutzbestimmungen", TestTools.IDTextÜberprüfen("Datenschutzbest", driver));

////Kontakt Dropdown
//TestTools.ElementKlick("DropdownServiceLogout", driver);
//TestTools.ElementKlick("DropdownKontaktLogout", driver);
//Assert.AreEqual("Ansprechpartner", TestTools.IDTextÜberprüfen("Ansprechp", driver));

////Impressum Dropdown
//TestTools.ElementKlick("DropdownServiceLogout", driver);
//TestTools.ElementKlick("DropdownImpressumLogout", driver);
//Assert.AreEqual("Impressum", TestTools.IDTextÜberprüfen("Impr", driver));

////StartButton
//TestTools.ElementKlick("StartButton", driver);
//driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//driver.FindElement(By.Id("loginLinkbutton"));
//Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

////Login Dropdown
//TestTools.ElementKlick("DropdownLogout", driver);
//TestTools.ElementKlick("loginLinkhead", driver);
//Assert.AreEqual("Login", TestTools.IDTextÜberprüfen("LoginPage", driver));

////Registrierung Dropdown
//TestTools.ElementKlick("DropdownLogout", driver);
//TestTools.ElementKlick("registerLinkhead", driver);
//Assert.AreEqual("Registrierung", TestTools.IDTextÜberprüfen("RegSeite", driver));