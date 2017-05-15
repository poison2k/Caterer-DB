﻿using Common.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Services;

namespace Caterer_DB.Models
{
    public class CreateRechteGruppeViewModel
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }

    public class EditRechteGruppeViewModel
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }

    public class DetailsRechteGruppeViewModel
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }

    public class DeleteRechteGruppeViewModel
    {
        [Key]
        public int RechteVerwaltungsGruppeId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public bool Löschbar { get; set; }

        public virtual List<Recht> Rechte { get; set; }
    }
}