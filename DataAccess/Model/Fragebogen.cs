using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Fragebogen
    {
        [Key]
        public int FragebogenId { get; set; }

        [Required]
        public Benutzer Benutzer { get; set; }

        [Required]
        public Antwort Antwort { get; set; }
    }
}