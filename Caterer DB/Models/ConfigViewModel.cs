using System.ComponentModel.DataAnnotations;

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



    }
}