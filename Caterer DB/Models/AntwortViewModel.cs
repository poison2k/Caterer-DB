using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models
{
    public class CreateAntwortViewModel
    {
        [Key]
        public int AntwortId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public Frage Frage { get; set; }
    }

    public class EditAntwortViewModel
    {
        [Key]
        public int AntwortId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public Frage Frage { get; set; }
    }

    public class DeleteAntwortViewModel
    {
        [Key]
        public int AntwortId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public Frage Frage { get; set; }
    }

    public class DetailsAntwortViewModel
    {
        [Key]
        public int AntwortId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public Frage Frage { get; set; }
    }
}