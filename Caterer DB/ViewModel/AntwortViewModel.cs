﻿using System.ComponentModel.DataAnnotations;
using Common.Model;
using Common.Services;

namespace Caterer_DB.ViewModel
{
    public class CreateAntwortViewModel
    {
        [Key]
        public int AntwortId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public Frage Frage { get; set; }
    }

    public class EditAntwortViewModel
    {
        [Key]
        public int AntwortId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public Frage Frage { get; set; }
    }

    public class DeleteAntwortViewModel
    {
        [Key]
        public int AntwortId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public Frage Frage { get; set; }
    }

    public class DetailsAntwortViewModel
    {
        [Key]
        public int AntwortId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }

        public Frage Frage { get; set; }
    }
}