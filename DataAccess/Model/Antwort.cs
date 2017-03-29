using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Antwort
    {
        [Key]
        public int AntwortId { get; set; }

        [Required]
        [DisplayName(@"Antwort")]
        public string Bezeichnung { get; set; }

        public bool IsChecked { get; set; }

        public Frage Frage { get; set; }
    }
}