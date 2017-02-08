namespace Common.Interfaces
{
    public interface IMailService
    {
        void SendRegisterMail(string verify, string email, string id);
    }
}
