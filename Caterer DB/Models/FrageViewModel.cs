using DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Caterer_DB.Models
{
    public class CreateFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }

        [Required]
        [DisplayName(@"Frage")]
        public string Bezeichnung { get; set; }

        public List<Antwort> Antworten { get; set; }

        [Required]
        [DisplayName(@"Kategorie")]
        public string KategorieName { get; set; }

        [DisplayName(@"Mehrfachantworten")]
        public bool IstMultiSelect { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Kategorien { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> JaNein { get; set; }
    }

    public class EditFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }

        [DisplayName(@"Frage")]
        [Required]
        public string Bezeichnung { get; set; }

        public List<Antwort> Antworten { get; set; }

        [Required]
        [DisplayName(@"Kategorie")]
        public string KategorieName { get; set; }

        [DisplayName(@"Mehrfachantworten")]
        public bool IstMultiSelect { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Kategorien { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> JaNein { get; set; }
    }

    public class DeleteFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }

        [Required]
        [DisplayName(@"Frage")]
        public string Bezeichnung { get; set; }

        public List<Antwort> Antworten { get; set; }

        [DisplayName(@"Mehrfachantworten")]     
        public bool IstMultiSelect { get; set; }

        [DisplayName(@"Kategorie")]
        public Kategorie Kategorie { get; set; }
    }

    public class DetailsFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }

        [Required]
        [DisplayName(@"Frage")]
        public string Bezeichnung { get; set; }

        public List<Antwort> Antworten { get; set; }

        [DisplayName(@"Kategorie")]
        public Kategorie Kategorien { get; set; }

        [DisplayName(@"Mehrfachantworten")]
        public bool IstMultiSelect { get; set; }

    }

    
}