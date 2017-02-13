using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models
{
    public class CreateSparteViewModel
    {
        [Key]
        public int SparteId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
    }

    public class EditSparteViewModel
    {
        [Key]
        public int SparteId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
    }

    public class DeleteSparteViewModel
    {
        [Key]
        public int SparteId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
    }

    public class DetailsSparteViewModel
    {
        [Key]
        public int SparteId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
    }
}