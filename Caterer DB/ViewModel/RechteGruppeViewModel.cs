using DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{
    public class CreateRechteGruppeViewModel
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }

    public class EditRechteGruppeViewModel
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }

    public class DetailsRechteGruppeViewModel
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }

    public class DeleteRechteGruppeViewModel
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }
}