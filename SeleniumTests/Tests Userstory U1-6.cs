using NUnit.Framework;
using SeleniumTests.Services;

namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_U1_6")]
    public class Userstory_U1_6 : TestInitialize
    {
        [Test]
        public void DatenschutzAufruf1()
        //T_U1-6_AL_B_01
        {
            //Variante Knopf
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.DatenschutzFußzeile(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf2()
        {
            //Variante Dropdown Logout
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.DatenschutzDropdownLogout(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        //T_U1-6_AL_B_01
        public void DatenschutzAufruf3()
        {
            //Variante Dropdown Login
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Name1, LoginDaten.PW1, driver);

            TestTools.DatenschutzDropdownLogin(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }
    }
}