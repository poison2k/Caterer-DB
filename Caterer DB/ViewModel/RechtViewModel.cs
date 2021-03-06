﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Model;
using Common.Services;

namespace Caterer_DB.ViewModel
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