using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Kategorie
    {
        [Key]
        public int KategorieId { get; set; } 
        [Required]
        public string Bezeichnung { get; set; }
                
    }
}
