using Common.Interfaces;
using System;
using System.Net;
using System.Net.Mail;

namespace Common.Services
{
    public class MailService : IMailService
    {
        public void SendForgottenPasswordMail(string passwordVerificationCode, string mail, string id)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = "Passwort vergessen Caterer-DB";
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = "http://localhost:60003/Account/PasswordChange?verify=" + passwordVerificationCode + "&id=" + id;
            SendMail(mailModel);
        }

        public void SendRegisterMail(string verify, string email, string id)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = "Registrierung Caterer-DB";
            mailModel.Empfaenger = email;
            mailModel.Inhalt = "Sehr geehrter Nutzer,\r\n\nvielen Dank für Ihre Registrierung für den internen Bereich der Caterer Datenbank der Vernetzungsstelle Schulverpflegung Niedersachsen.\r\nBitte schließen Sie Ihre Registrierung durch Anklicken des folgenden Links ab. Im Anschluss können Sie mit Ihren Anmeldedaten alle Funktionen des internen Bereichs nutzen. \r\n\n http://localhost:60003/Account/RegisterComplete?verify=" + verify + "&id=" + id + "\r\n\nSie haben noch Fragen oder Anregungen? Bitte antworten Sie nicht direkt auf diese E-Mail - aus technischen Gründen können wir Ihre Anfrage leider nicht bearbeiten, wenn Sie die Reply-Funktion Ihres E-Mail-Programms wählen.\r\n\nNutzen Sie einfach unser Kontaktformular unter:\r\n\n http://localhost:60003/ \r\n\nWir wünschen Ihnen viel Erfolg!";
            SendMail(mailModel);
        }

        private MailModel ConfigureMail() {
            var mailModel = new MailModel();

            mailModel.SMTPSeverName = "smtp.gmail.com";
            mailModel.Port = 25;
            mailModel.Absender = "Hoersaal10@gmail.com";
            mailModel.Passwort = "HS10idgHSe!";
            mailModel.UserName = "Hoersaal10@gmail.com";

            return mailModel;
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