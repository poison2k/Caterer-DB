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

        public static String IDTextÜberprüfen(string id, IWebDriver driver, Int16 zeit = 5)
        {

            String Test = "";
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
                driver.FindElement(By.Id(id));
                Test = driver.FindElement(By.Id(id)).Text;

            }
            return Test;

        }

        public static void ElementKlick(string id, IWebDriver driver, Int16 zeit = 5)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
            driver.FindElement(By.Id(id));
            driver.FindElement(By.Id(id)).Click();
        }

        public static void LoginDatenEingeben(String email, String pw, IWebDriver driver, Int16 zeit = 5)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys(pw);
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();
        }


    }
}
