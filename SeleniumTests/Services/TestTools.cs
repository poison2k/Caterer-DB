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

        //Prüft mittels ObjektID ob Element sichtbar ist.
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

        //Gibt mittels ObjektID den Text eines sichbaren Elements zurück.
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

        //Gibt mittels ObjektID den Wert einer sichbaren Textbox zurück.
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

        //Prüft ob der User angemeldet ist und loggt sich ggf aus.
        public static void TestStart(IWebDriver driver)
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

        //Klick mittels ObjektID ein sichbares Elements.
        public static void ElementKlick(string id, IWebDriver driver, Int16 zeit=5)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
            driver.FindElement(By.Id(id));
            driver.FindElement(By.Id(id)).Click();
        }

        //Für den Userlogin durch.
        public static void LoginDatenEingeben(String email, String pw, IWebDriver driver, Int16 zeit=5)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
            ElementKlick("DropdownLogout", driver);
            ElementKlick("loginLinkhead", driver);
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Passwort")).Clear();
            driver.FindElement(By.Id("Passwort")).SendKeys(pw);
            driver.FindElement(By.XPath("//input[@value='Anmelden']")).Click();

        }

        //Gibt mittels ObjektID, Daten in eine sichbare Textbox ein.
        public static void DatenEingeben(string daten, string id, IWebDriver driver, int zeit=5)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(zeit));
            driver.FindElement(By.Id(id)).Clear();
            driver.FindElement(By.Id(id)).SendKeys(daten);

        }

        //Lässt Selenium 1 Sekunde warten.
        public static void EineSekundeWarten(IWebDriver driver)
        {

            FehlerID("xxx", driver, 1);

        }

        //Loggt den User aus.
        public static void NutzerAusloggen(IWebDriver driver)
        {

            ElementKlick("DropdownLogin", driver);
            ElementKlick("Ausloggen", driver);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("loginLinkbutton"));
            Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

        }

        //Loggt angemeldeten User aus oder geht auf die Startseite.
        public static void TestEnde(IWebDriver driver)
        {
            
            if (FehlerID("DropdownLogin", driver))
            {
                ElementKlick("DropdownLogin", driver);
                ElementKlick("Ausloggen", driver);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                driver.FindElement(By.Id("loginLinkbutton"));
                Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);
            }
            else
            {

                ElementKlick("StartButton", driver);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                driver.FindElement(By.Id("loginLinkbutton"));
                Assert.AreEqual("Startseite - My ASP.NET Application", driver.Title);

            }

        }

        //------------------------------------------------------------------------------------------------------------
        //Navigiert zur Kontaktseite über die Fußzeile.
        public static void KontaktFußzeile(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("Kontakt", driver);
            Assert.AreEqual("Ansprechpartner",IDTextÜberprüfen("Ansprechp", driver));

        }

        //Navigiert zur Kontaktseite über die Logoutdropdown.
        public static void KontaktDropdownLogout(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("DropdownServiceLogout", driver);
            ElementKlick("DropdownKontaktLogout", driver);
            Assert.AreEqual("Ansprechpartner", IDTextÜberprüfen("Ansprechp", driver));

        }

        //Navigiert zur Kontaktseite über die Logindropdown.
        public static void KontaktDropdownLogin(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("DropdownServiceLogin", driver);
            ElementKlick("DropdownKontaktLogin", driver);
            Assert.AreEqual("Ansprechpartner", IDTextÜberprüfen("Ansprechp", driver));

        }

        //------------------------------------------------------------------------------------------------------------
        //Navigiert zur Datenschutzseite über die Fußzeile.
        public static void DatenschutzFußzeile(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("Datenschutz", driver);
            Assert.AreEqual("Datenschutzbestimmungen", IDTextÜberprüfen("Datenschutzbest", driver));

        }

        //Navigiert zur Datenschutzseite über die Logoutdropdown.
        public static void DatenschutzDropdownLogout(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("DropdownServiceLogout", driver);
            ElementKlick("DropdownDatenschutzLogout", driver);
            Assert.AreEqual("Datenschutzbestimmungen", IDTextÜberprüfen("Datenschutzbest", driver));

        }

        //Navigiert zur Datenschutzseite über die Logindropdown.
        public static void DatenschutzDropdownLogin(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("DropdownServiceLogin", driver);
            ElementKlick("DropdownDatenschutzLogin", driver);
            Assert.AreEqual("Datenschutzbestimmungen", IDTextÜberprüfen("Datenschutzbest", driver));

        }

        //------------------------------------------------------------------------------------------------------------
        //Navigiert zur AGB-Seite über die Fußzeile.
        public static void AGBFußzeile(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("AGB", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

        }

        //Navigiert zur AGB-Seite über die Logoutdropdown.
        public static void AGBDropdownLogout(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("DropdownServiceLogout", driver);
            ElementKlick("DropdownAGBLogout", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

        }

        //Navigiert zur AGB-Seite über die Logindropdown.
        public static void AGBDropdownLogin(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("DropdownServiceLogin", driver);
            ElementKlick("DropdownAGBLogin", driver);
            Assert.AreEqual("Allgemeine Geschäftsbedingungen", IDTextÜberprüfen("AllgemGeschäftsbedingungen", driver));

        }

        //------------------------------------------------------------------------------------------------------------
        //Navigiert zur Impressum-Seite über die Fußzeile.
        public static void ImpressumFußzeile(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("Impressum", driver);
            Assert.AreEqual("Impressum", IDTextÜberprüfen("Impr", driver));

        }

        //Navigiert zur Impressum-Seite über die Logoutdropdown.
        public static void ImpressumDropdownLogout(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("DropdownServiceLogout", driver);
            ElementKlick("DropdownImpressumLogout", driver);
            Assert.AreEqual("Impressum", IDTextÜberprüfen("Impr", driver));

        }

        //Navigiert zur Impressum-Seite über die Logindropdown.
        public static void ImpressumDropdownLogin(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            ElementKlick("DropdownServiceLogin", driver);
            ElementKlick("DropdownImpressumLogin", driver);
            Assert.AreEqual("Impressum", IDTextÜberprüfen("Impr", driver));

        }

    }
}

