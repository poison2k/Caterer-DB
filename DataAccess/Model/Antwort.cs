using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Antwort
    {
        [Key]
        public int AntwortId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
        
        public Frage Frage { get; set; }
    }
}
