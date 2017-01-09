using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Table("Rechte")]
    public class Recht
    {
        [Key]
        public int RechtId { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        public string Beschreibung { get; set; }

        public virtual List<RechteGruppe> RechteVerwaltungsGruppen { get; set; }

        public bool IstGelöscht { get; set; }
    }
}