using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Benutzer
    {
        [Key]
        public int BenutzerId { get; set; }

        public string Anrede { get; set; }             
        [Required]
        public string Vorname { get; set; }             
        [Required]
        public string Nachname { get; set; }            
      
        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }          

        public string Mail { get; set; }                
       
        public string Strasse { get; set; }             

        public string Plz { get; set; }                 

        public string Ort { get; set; }                 
    }
}
