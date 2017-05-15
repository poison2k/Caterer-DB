using Common.Services;
using System.ComponentModel.DataAnnotations;

namespace Common.Model
{
    public class Kategorie
    {
        [Key]
        public int KategorieId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }
    }
}