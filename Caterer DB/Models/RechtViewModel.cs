using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models
{
        public class CreateRechtViewModel
        {
            [Key]
            public int RechtId { get; set; }

            [Required]
            public string Bezeichnung { get; set; }

            public string Beschreibung { get; set; }

            public virtual List<RechteGruppe> RechteVerwaltungsGruppen { get; set; }

            public bool IstGelöscht { get; set; }
        }

        public class EditRechtViewModel
        {
            [Key]
            public int RechtId { get; set; }

            [Required]
            public string Bezeichnung { get; set; }

            public string Beschreibung { get; set; }

            public virtual List<RechteGruppe> RechteVerwaltungsGruppen { get; set; }

            public bool IstGelöscht { get; set; }
        }

        public class DeleteRechtViewModel
        {
            [Key]
            public int RechtId { get; set; }

            [Required]
            public string Bezeichnung { get; set; }

            public string Beschreibung { get; set; }

            public virtual List<RechteGruppe> RechteVerwaltungsGruppen { get; set; }

            public bool IstGelöscht { get; set; }
        }

        public class DetailsRechtViewModel
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