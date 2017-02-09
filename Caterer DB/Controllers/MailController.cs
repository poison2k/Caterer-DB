using Caterer_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{

    public class MailController : BaseController
    {
        //ToDo Dies ist nur ein Test-Controller, zur Überprüfung der Mail-Funktionalität
        public ActionResult Erstellen()
        {
            var erstelleMailViewModel = new CreateMailViewModel();
            erstelleMailViewModel.FehlerListe = new List<string>();
            erstelleMailViewModel.SMTPSeverName = "smtp.gmail.com";
            erstelleMailViewModel.Port = 25;
            erstelleMailViewModel.Absender = "Hoersaal10@gmail.com";
            erstelleMailViewModel.Passwort = "HS10idgHSe!";
            erstelleMailViewModel.UserName = "Hoersaal10@gmail.com";

            return View(erstelleMailViewModel);
        }

        [HttpPost]
        public ActionResult Erstellen(CreateMailViewModel createMailViewModel)
        {
            createMailViewModel.FehlerListe = new List<string>();
            try
            {
                MailMessage mail = new MailMessage(createMailViewModel.Absender, createMailViewModel.Empfaenger);
                mail.Subject = createMailViewModel.Betreff;
                mail.Body = createMailViewModel.Inhalt;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = 25;
                smtpClient.EnableSsl = true;
                smtpClient.Host = createMailViewModel.SMTPSeverName;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(createMailViewModel.UserName, createMailViewModel.Passwort);


                smtpClient.Send(mail);
                return View(createMailViewModel);
            }
            catch (Exception ex)
            {
                createMailViewModel.FehlerListe.Add(ex.Message);
                return View(createMailViewModel);
            }
        }

    }
}
