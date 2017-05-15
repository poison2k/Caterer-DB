using Common.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common.Services;

namespace Caterer_DB.Models
{
    public class IndexKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }

        [MyRequired]
        [DisplayName(@"Kategorie")]
        public string Bezeichnung { get; set; }

        public List<Frage> Fragen { get; set; }
    }

    public class CreateKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }

        [MyRequired]
        [DisplayName(@"Kategorie")]
        public string Bezeichnung { get; set; }
    }

    public class EditKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }

        [MyRequired]
        [DisplayName(@"Kategorie")]
        public string Bezeichnung { get; set; }

        public List<Frage> Fragen { get; set; }
    }

    public class DeleteKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }
    }

    public class DetailsKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }

        [DisplayName(@"Kategorie")]
        [MyRequired]
        public string Bezeichnung { get; set; }

        public List<Frage> Fragen { get; set; }
    }
}