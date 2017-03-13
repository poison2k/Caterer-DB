using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models
{
        public class CreateFrageViewModel
        {
            [Key]
            public int FrageId { get; set; }
            [Required]
            public string Bezeichnung { get; set; }
            
            public Sparte Sparte { get; set; }
        }

        public class EditFrageViewModel
        {
            [Key]
            public int FrageId { get; set; }
            [Required]
            public string Bezeichnung { get; set; }

            public Sparte Sparte { get; set; }
        }

        public class DeleteFrageViewModel
        {
            [Key]
            public int FrageId { get; set; }
            [Required]
            public string Bezeichnung { get; set; }

            public Sparte Sparte { get; set; }
        }

        public class DetailsFrageViewModel
        {
            [Key]
            public int FrageId { get; set; }
            [Required]
            public string Bezeichnung { get; set; }

            public Sparte Sparte { get; set; }
        }

        public class BearbeiteFrageViewModel
        {
            [Key]
            public int FrageId { get; set; }
            [Required]
            public string Bezeichnung { get; set; }

            public Sparte Sparte { get; set; }

            public List<Antwort> Antworten { get; set; } 
        }
}