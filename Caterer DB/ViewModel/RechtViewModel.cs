using Caterer_DB.Services;
using DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{
    public class CreateRechtViewModel
    {
        [Key]
        public int RechtId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public string Beschreibung { get; set; }

        public virtual List<RechteGruppe> RechteVerwaltungsGruppen { get; set; }

        public bool IstGelöscht { get; set; }
    }

    public class EditRechtViewModel
    {
        [Key]
        public int RechtId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public string Beschreibung { get; set; }

        public virtual List<RechteGruppe> RechteVerwaltungsGruppen { get; set; }

        public bool IstGelöscht { get; set; }
    }

    public class DeleteRechtViewModel
    {
        [Key]
        public int RechtId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public string Beschreibung { get; set; }

        public virtual List<RechteGruppe> RechteVerwaltungsGruppen { get; set; }

        public bool IstGelöscht { get; set; }
    }

    public class DetailsRechtViewModel
    {
        [Key]
        public int RechtId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public string Beschreibung { get; set; }

        public virtual List<RechteGruppe> RechteVerwaltungsGruppen { get; set; }

        public bool IstGelöscht { get; set; }
    }
}