using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class MailModel
    {
        public string Absender { get; set; }
        public string Empfaenger { get; set; }
        public string Betreff { get; set; }
        public string Inhalt { get; set; }
        public string SMTPSeverName { get; set; }
        public string UserName { get; set; }
        public string Passwort { get; set; }
        public int Port { get; set; }
    }
}
