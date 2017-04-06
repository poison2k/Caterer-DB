using NUnit.Framework;
using SeleniumTests.Services;

namespace SeleniumTests
{
    [TestFixture]
    [Category("Userstory_U1_4")]
    public class Userstory_U1_4 : TestInitialize
    {
        [Test]
        public void KontaktAufruf1()
        //T_U1-4_AL_B_01
        {
            //Variante Knopf
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.KontaktFußzeile(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void KontaktAufruf2()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Logout
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.KontaktDropdownLogout(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }

        [Test]
        public void KontaktAufruf3()
        //T_U1-4_AL_B_01
        {
            //Variante Dropdown Login
            TestTools.TestStart_Angemeldete_User_Ausloggen(driver);

            TestTools.User_Login_Durchführen(LoginDaten.Caterer1, LoginDaten.PW1, driver);

            TestTools.KontaktDropdownLogin(driver);

            TestTools.TestEnde_Angemeldete_User_Ausloggen_Oder_Startseite_Aufrufen(driver);
        }
    }
}