using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Caterer_DB.Services;

namespace Caterer_DB.Models
{
    public class EditConfigViewModel
    {
        [Key]
        public int ConfigId { get; set; }

        [Required]
        public string UserNameForSMTPServer { get; set; }

        [Required]
        public string PasswortForSMTPServer { get; set; }

        [Required]
        public string SmtpServer { get; set; }

        [Required]
        public int SmtpPort { get; set; }

        [DisplayName(@"Änderungsverfolgung für Änderungen der Caterer")]
        public bool AenderungsVerfolgungCatererAktiviert { get;set;}

        [Required]
        [DisplayName(@"Zeit bis zur nächsten Änderungsmeldung")]
        [MinValue(1, ErrorMessage = "Mindestens 1 Stunde")]
        [MaxValue(24, ErrorMessage = "Maximal 24 Stunden")]
        [RegularExpression("^[1-9]*$", ErrorMessage = "Stunden in Ziffern angeben")]
        public int ZeitInStundendÄnderungsverfolgung { get; set; }
    }
}