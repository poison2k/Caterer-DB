using System.ComponentModel.DataAnnotations;
using Common.Services;


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