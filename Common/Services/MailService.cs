using Common.Interfaces;
using Common.Resources;
using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Model;

namespace Common.Services
{
    public class MailService : IMailService
    {
        public void SendForgottenPasswordMail(Config config, string passwordVerificationCode, string mail, string id)
        {
            var mailModel = ConfigureMail(config);
            mailModel.Betreff = EMailBetreff.Passwortvergessen;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = EMailTexte.PWvergessen + config.URLWebseite + Links.ForgottenPassword + passwordVerificationCode + "&id=" + id + EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendRemoveCatererMail(Config config, string mail)
        {
            var mailModel = ConfigureMail(config);
            mailModel.Betreff = EMailBetreff.Nutzerlöschen;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = EMailTexte.Nutzerlöschen + EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendEditCatererMail(Config config, string mail)
        {
            var mailModel = ConfigureMail(config);
            mailModel.Betreff = EMailBetreff.NutzerÄnderung;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = EMailTexte.NutzerÄnderung + EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendInfoMailEditCatererToEmployee(Config config, Benutzer dbBenutzer, List<Benutzer> list)
        {
            string mail = "";
            foreach (Benutzer benutzer in list)
            {
                mail = mail + benutzer.Mail + ",";
            }
            mail = mail.Remove(mail.Length - 1, 1);
            var mailModel = ConfigureMail(config);
            mailModel.Betreff = EMailBetreff.CatererÄnderung;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = EMailTexte.MitarbeiterCatererEdit + dbBenutzer.Firmenname + EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendReleasedQuestionCatererMail(Config config, string mail)
        {
            var mailModel = ConfigureMail(config);
            mailModel.Betreff = EMailBetreff.NeueFragen;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = EMailTexte.NeueFragen + EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendNewMitarbeiterMail(Config config, string passwordVerificationCode, string mail, string id)
        {
            var mailModel = ConfigureMail(config);
            mailModel.Betreff = EMailBetreff.Kontoangelegt;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = EMailTexte.Mitarbeiterangelegt + config.URLWebseite + Links.NewMitarbeiter + passwordVerificationCode + "&id=" + id + EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendNewCatererMail(Config config, string passwordVerificationCode, string mail, string id)
        {
            var mailModel = ConfigureMail(config);
            mailModel.Betreff = EMailBetreff.Kontoangelegt;
            mailModel.Empfaenger = mail;
            mailModel.Inhalt = EMailTexte.Catererangelegt + config.URLWebseite + Links.NewCaterer + passwordVerificationCode + "&id=" + id + EMailTexte.Abschluss;
            SendMail(mailModel);
        }

        public void SendRegisterMail(Config config, string verify, string email, string id)
        {
            var mailModel = ConfigureMail(config);
            mailModel.Betreff = EMailBetreff.Kontoangelegt;
            mailModel.Empfaenger = email;
            mailModel.Inhalt = EMailTexte.CatererRegistrierung1 + config.URLWebseite +Links.Register + verify + "&id=" + id + EMailTexte.CatererRegistrierung2 + EMailTexte.Abschluss + EMailTexte.Anregung + config.URLWebseite + Links.Kontakt;
            SendMail(mailModel);
        }

        private MailModel ConfigureMail(Config config)
        {
            var mailModel = new MailModel();

            mailModel.SMTPSeverName = config.SmtpServer;
            mailModel.Port = config.SmtpPort;
            mailModel.Absender = config.UserNameForSMTPServer;
            mailModel.Passwort = config.PasswortForSMTPServer;
            mailModel.UserName = config.UserNameForSMTPServer;





            return mailModel;
        }

        private void SendMail(MailModel mailModel)
        {
            new Task(() =>
            {
#if DEBUG

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

#else
             try
            {
                MailMessage mail = new MailMessage(mailModel.Absender, mailModel.Empfaenger);
                mail.Subject = mailModel.Betreff;
                mail.Body = mailModel.Inhalt;
                SmtpClient smtpClient = new SmtpClient(mailModel.SMTPSeverName);
                smtpClient.Credentials = new NetworkCredential(mailModel.UserName, mailModel.Passwort);

                smtpClient.Send(mail);
            }
#endif
                catch (Exception)
                {
                    throw new ArgumentException("Fehler beim Senden von EMail");
                }


            }).Start();
        }


    }
}