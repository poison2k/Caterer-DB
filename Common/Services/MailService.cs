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
            mailModel.Betreff = Common.Services.EMailBetreff.Passwortvergessen;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = Common.Services.EMailTexte.PWvergessen + Common.Services.Links.ForgottenPassword + passwordVerificationCode + "&id=" + id + Common.Services.EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendRemoveCatererMail(string mail)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = Common.Services.EMailBetreff.Nutzerlöschen;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = Common.Services.EMailTexte.Nutzerlöschen + Common.Services.EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendEditCatererMail(string mail)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = Common.Services.EMailBetreff.NutzerÄnderung;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = Common.Services.EMailTexte.NutzerÄnderung + Common.Services.EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendReleasedQuestionCatererMail(string mail)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = Common.Services.EMailBetreff.NeueFragen;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = Common.Services.EMailTexte.NeueFragen + Common.Services.EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendNewMitarbeiterMail(string passwordVerificationCode, string mail, string id)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = Common.Services.EMailBetreff.Kontoangelegt;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = Common.Services.EMailTexte.Mitarbeiterangelegt + Common.Services.Links.NewMitarbeiter + passwordVerificationCode + "&id=" + id + Common.Services.EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendNewCatererMail(string passwordVerificationCode, string mail, string id)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = Common.Services.EMailBetreff.Kontoangelegt;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = Common.Services.EMailTexte.Catererangelegt + Common.Services.Links.NewCaterer + passwordVerificationCode + "&id=" + id + Common.Services.EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendRegisterMail(string verify, string email, string id)
        {
            var mailModel = ConfigureMail();
            mailModel.Betreff = Common.Services.EMailBetreff.Kontoangelegt;
            mailModel.Empfaenger = email;
            mailModel.Inhalt = Common.Services.EMailTexte.CatererRegistrierung1 + Common.Services.Links.Register + verify + "&id=" + id + Common.Services.EMailTexte.CatererRegistrierung2 + Common.Services.EMailTexte.Abschluss + Common.Services.EMailTexte.Anregung + Common.Services.Links.Kontakt;
            SendMail(mailModel);
        }

        private MailModel ConfigureMail()
        {
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