using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Config
    {
        [Key]
        public int ConfigId { get; set; }

        public string UserNameForSMTPServer { get; set; }

        public string PasswortForSMTPServer { get; set; }

        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public bool AenderungsVerfolgungCatererAktiviert { get; set; }

        public int ZeitInStundendÄnderungsverfolgung { get; set; }
    }
}