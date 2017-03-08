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
            mailModel.Inhalt = "Sehr geehrter Nutzer,\r\n\nfalls Sie Ihr Passwort vergessen haben, können Sie sich mit Hilfe des folgenden Links ein neues Passwort vergeben. Bitte beachten Sie, dass der Link nur 2 Stunden gültig ist.Danach müssen Sie eine neue E-Mail anfordern.\r\n\n http://localhost:60003/Account/PasswordChange?verify=" + passwordVerificationCode + "&id=" + id + "\r\n\nWir wünschen Ihnen einen erfolgreichen Tag! \r\n\nIhr Team der Vernetzungsstelle für Schulverpflegung Niedersachsen";
            SendMail(mailModel);
        }

        public void SendRemoveCatererMail(string mail)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = "Sie wurden als Caterer aus der Caterer-DB entfernt";
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = "Wir bedauern dass Sie nicht weiter in unserer Caterer Datenbank geführt werden möchten.";
            SendMail(mailModel);
        }

        public void SendEditCatererMail(string mail)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = "Ihre Daten in der Caterer-DB wurden bearbeitet";
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = "Ihre Daten wurden von uns aktualisiert.";
            SendMail(mailModel);
        }


        public void SendNewMitarbeiterMail(string passwordVerificationCode, string mail, string id)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = "Sie wurden als neuer Mitarbeiter der Caterer-DB hinzugefügt";
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = "Bitte folgen Sie dem folgenden Link und legen Sie ihr Passwort fest http://localhost:60003/Account/PasswordChange?verify=" + passwordVerificationCode + "&id=" + id;
            SendMail(mailModel);
        }

        public void SendNewCatererMail(string passwordVerificationCode, string mail, string id)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = "Sie wurden als neuer Caterer der Caterer-DB hinzugefügt";
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = "Bitte folgen Sie dem folgenden Link und legen Sie ihr Passwort fest http://localhost:60003/Account/PasswordChange?verify=" + passwordVerificationCode + "&id=" + id;
            SendMail(mailModel);
        }

        public void SendRegisterMail(string verify, string email, string id)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = "Registrierung Caterer-DB";
            mailModel.Empfaenger = email;
            mailModel.Inhalt = "Sehr geehrter Nutzer,\r\n\nSie haben ein Benutzerkonto bei der Caterer Datenbank der Vernetzungsstelle Schulverpflegung Niedersachsenangelegt. Eine gute Entscheidung! Nur so können Sie bei der Empfehlung von Verpflegungsanbietern für Schulen berücksichtigt werden.\r\n\nDamit Sie Ihr Konto nutzen können, fehlt nur noch ein Schritt:\r\nBestätigen Sie Ihre E-Mail Adresse.\r\nKlicken Sie dafür einfach auf den nach folgenden Link. \r\n\n http://localhost:60003/Account/RegisterComplete?verify=" + verify + "&id=" + id + "\r\n\nIm Anschluss können Sie mit Ihren Anmeldedaten alle Funktionen des internen Bereichs nutzen. \r\n\nWir wünschen Ihnen viel Erfolg!\r\n\nIhr Team der Vernetzungsstelle für Schulverpflegung Niedersachsen\r\n\n\n\nSie haben noch Fragen oder Anregungen? Bitte antworten Sie nicht direkt auf diese E-Mail - aus technischen Gründen können wir Ihre Anfrage leider nicht bearbeiten, wenn Sie die Reply-Funktion Ihres E-Mail-Programms wählen.\r\n\nNutzen Sie einfach die Kontaktmöglichkeiten unter:\r\n\n http://localhost:60003/";
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
                smtpClient.Port = mailModel.Port;
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