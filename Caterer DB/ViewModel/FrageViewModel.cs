using DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{
    public class IndexFrageViewModel
    {
        [Key]
        public int FrageId { get; set; }

        [Required]
        [DisplayName(@"Frage")]
        public string Bezeichnung { get; set; }

        [DisplayName(@"Anzahl Antworten")]
        public List<Antwort> Antworten { get; set; }

        [Required]
        [DisplayName(@"Kategorie")]
        public Kategorie Kategorie { get; set; }

        [DisplayName(@"Mehrfachantwort")]
        public bool IstMultiSelect { get; set; }
    }

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

        public bool IstVeröffentlicht { get; set; }

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


    public class AjaxAntwort
    {
        public int AntwortId { get; set; }

        public string Antworttext { get; set; }

    }
}