using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Fragebogen
    {
        [Key]
        public int FragebogenId { get; set; }
        [Required]
        public Benutzer Benutzer { get; set; }
        [Required]
        public Frage Frage { get; set; }
        [Required]
        public Antwort Antwort { get; set; }
    }
}
