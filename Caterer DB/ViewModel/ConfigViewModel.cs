using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Caterer_DB.Services;

namespace Caterer_DB.Models
{
    public class EditConfigViewModel
    {
        [Key]
        public int ConfigId { get; set; }

        [MyRequired]
        [DisplayName(@"Benutzername für SMTP - Server")]
        public string UserNameForSMTPServer { get; set; }

        [MyRequired]
        [DisplayName(@"Passwort für SMTP - Server")]
        public string PasswortForSMTPServer { get; set; }

        [MyRequired]
        [DisplayName(@"SMTP - Server")]
        public string SmtpServer { get; set; }

        [MyRequired]
        [DisplayName(@"SMTP - Port")]
        public int SmtpPort { get; set; }

        [DisplayName(@"Änderungsverfolgung für Änderungen der Caterer")]
        public bool AenderungsVerfolgungCatererAktiviert { get;set;}

        [MyRequired]
        [DisplayName(@"Zeit bis zur nächsten Änderungsmeldung (1h-24h)")]
        [MinValue(1, ErrorMessage = "Mindestens 1 Stunde")]
        [MaxValue(24, ErrorMessage = "Maximal 24 Stunden")]
        [RegularExpression("^[1-9]*$", ErrorMessage = "Stunden in Ziffern angeben")]
        public int ZeitInStundendÄnderungsverfolgung { get; set; }
    }
}