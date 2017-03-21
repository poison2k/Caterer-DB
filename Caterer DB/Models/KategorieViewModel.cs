using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Caterer_DB.Models
{
    public class CreateKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
    }

    public class EditKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }

        [Required]
        [DisplayName(@"Kategorie")]
        public string Bezeichnung { get; set; }

        public List<Frage> Fragen {get;set;}
    }

    public class DeleteKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }
        [Required]
        public string Bezeichnung { get; set; }


    }

    public class DetailsKategorieViewModel
    {
        [Key]
        public int KategorieId { get; set; }

        [DisplayName(@"Kategorie")]
        [Required]
        public string Bezeichnung { get; set; }

        public List<Frage> Fragen { get; set; }
    }
}