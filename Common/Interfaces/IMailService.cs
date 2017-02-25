namespace Common.Interfaces
{
    public interface IMailService
    {
        void SendRegisterMail(string verify, string email, string id);
        void SendNewMitarbeiterMail(string passwordVerificationCode, string mail, string id);
        void SendForgottenPasswordMail(string eMailVerificationCode, string mail, string v);
    }
}
