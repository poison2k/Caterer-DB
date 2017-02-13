using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Table("BenutzerGruppen")]
    public class editBenutzerGruppeViewModel
    {
        [Key]
        public int NutzerGruppeID { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
        [Required]
        public bool Löschbar { get; set; }

        public bool IstGelöscht { get; set; }
        
        public virtual RechteGruppe RechteGruppe { get; set; }

        public virtual List<Benutzer> Benutzer {get ;set; }
    }
}

