using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


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
