using Caterer_DB.Services;
using DataAccess.Model;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
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