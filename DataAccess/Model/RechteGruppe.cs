using DataAccess.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Table("RechteGruppen")]
    public class RechteGruppe
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }
}