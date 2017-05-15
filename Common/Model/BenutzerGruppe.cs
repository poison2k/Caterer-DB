using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Services;


namespace Common.Model
{
    [Table("BenutzerGruppen")]
    public class BenutzerGruppe
    {
        [Key]
        public int NutzerGruppeID { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        [MyRequired]
        public bool Löschbar { get; set; }

        public bool IstGelöscht { get; set; }

        public virtual RechteGruppe RechteGruppe { get; set; }

        public virtual List<Benutzer> Benutzer { get; set; }
    }
}