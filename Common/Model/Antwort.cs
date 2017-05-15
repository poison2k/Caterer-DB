using Common.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.Model
{
    public class Antwort
    {
        [Key]
        public int AntwortId { get; set; }

        [MyRequired]
        [DisplayName(@"Antwort")]
        public string Bezeichnung { get; set; }

        public bool IsChecked { get; set; }

        public Frage Frage { get; set; }
    }
}