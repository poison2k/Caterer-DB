using System.Collections.Generic;
using Common.Model;


namespace Common.Interfaces
{
    public interface IMailService
    {
        void SendRegisterMail(Config config, string verify, string email, string id);

        void SendNewMitarbeiterMail(Config config, string passwordVerificationCode, string mail, string id);

        void SendForgottenPasswordMail(Config config, string eMailVerificationCode, string mail, string v);

        void SendNewCatererMail(Config config, string passwordVerificationCode, string mail, string v);

        void SendRemoveCatererMail(Config config, string mail);

        void SendEditCatererMail(Config config, string mail);

        void SendReleasedQuestionCatererMail(Config config, string mail);
        void SendInfoMailEditCatererToEmployee(Config config, Benutzer dbBenutzer, List<Benutzer> list);
    }
}