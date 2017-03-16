﻿using DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{
    public class CreateFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public List<Antwort> Antworten { get; set; }

        [Required]
        public string SpartenName { get; set; }

        public bool IstMultiSelect { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Sparten { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> JaNein { get; set; }
    }

    public class EditFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public List<Antwort> Antworten { get; set; }

        [Required]
        public string SpartenName { get; set; }

        public bool IstMultiSelect { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Sparten { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> JaNein { get; set; }
    }

    public class DeleteFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public List<Antwort> Antworten { get; set; }

        public bool IstMultiSelect { get; set; }

        public Sparte Sparte { get; set; }
    }

    public class DetailsFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        public List<Antwort> Antworten { get; set; }

        public Sparte Sparte { get; set; }

        public bool IstMultiSelect { get; set; }

    }

    
}