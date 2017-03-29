using DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{
    public class CreateBenutzerGruppeViewModel
    {
        [Key]
        public int NutzerGruppeID { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        [Required]
        public bool Löschbar { get; set; }

        public bool IstGelöscht { get; set; }

        public virtual RechteGruppe RechteGruppe { get; set; }

        public virtual List<Benutzer> Benutzer { get; set; }
    }

    public class EditBenutzerGruppeViewModel
    {
        [Key]
        public int NutzerGruppeID { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        [Required]
        public bool Löschbar { get; set; }

        public bool IstGelöscht { get; set; }

        public virtual RechteGruppe RechteGruppe { get; set; }

        public virtual List<Benutzer> Benutzer { get; set; }
    }

    public class DeleteBenutzerGruppeViewModel
    {
        [Key]
        public int NutzerGruppeID { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        [Required]
        public bool Löschbar { get; set; }

        public bool IstGelöscht { get; set; }

        public virtual RechteGruppe RechteGruppe { get; set; }

        public virtual List<Benutzer> Benutzer { get; set; }
    }

    public class DetailsBenutzerGruppeViewModel
    {
        [Key]
        public int NutzerGruppeID { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        [Required]
        public bool Löschbar { get; set; }

        public bool IstGelöscht { get; set; }

        public virtual RechteGruppe RechteGruppe { get; set; }

        public virtual List<Benutzer> Benutzer { get; set; }
    }
}