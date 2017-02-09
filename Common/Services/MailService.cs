using Common.Interfaces;
using System;
using System.Net;
using System.Net.Mail;

namespace Common.Services
{
    public class MailService : IMailService
    {

        public void SendRegisterMail(string verify, string email, string id)
        {
            var mailModel = new MailModel();
            mailModel.SMTPSeverName = "smtp.gmail.com";
            mailModel.Port = 25;
            mailModel.Absender = "Hoersaal10@gmail.com";
            mailModel.Passwort = "HS10idgHSe!";
            mailModel.UserName = "Hoersaal10@gmail.com";
            mailModel.Betreff = "Registrierung Caterer-DB";
            mailModel.Empfaenger = email;
            mailModel.Inhalt = "http://localhost:60003/Account/RegisterComplete?verify="+verify+"&id="+id;
            SendMail(mailModel);
        }


        private void SendMail(MailModel mailModel)
        {
            try
            {
                MailMessage mail = new MailMessage(mailModel.Absender, mailModel.Empfaenger);
                mail.Subject = mailModel.Betreff;
                mail.Body = mailModel.Inhalt;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = 25;
                smtpClient.EnableSsl = true;
                smtpClient.Host = mailModel.SMTPSeverName;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(mailModel.UserName, mailModel.Passwort);

                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                throw new ArgumentException("Fehler beim Senden von EMail");
            }
        }
    }

   
}