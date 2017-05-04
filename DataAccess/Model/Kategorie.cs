using DataAccess.Services;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Kategorie
    {
        [Key]
        public int KategorieId { get; set; }

        [MyRequired]
        public string Bezeichnung { get; set; }
    }
}