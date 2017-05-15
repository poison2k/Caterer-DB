using System.ComponentModel.DataAnnotations;
using Common.Services;

namespace Common.Model
{
    public class Fragebogen
    {
        [Key]
        public int FragebogenId { get; set; }

        [MyRequired]
        public Benutzer Benutzer { get; set; }

        [MyRequired]
        public Antwort Antwort { get; set; }
    }
}