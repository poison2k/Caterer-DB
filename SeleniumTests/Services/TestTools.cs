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

        public static bool FehlerID(string id, IWebDriver driver, Int16 Zeit=0)
        {

            bool present = false;

            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Zeit));
                driver.FindElement(By.Id(id));
                present = true;
            }
            catch (NoSuchElementException)
            {
                present = false;
            }
            return present;

        }
    }
}
