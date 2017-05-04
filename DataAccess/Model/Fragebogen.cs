using DataAccess.Services;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
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