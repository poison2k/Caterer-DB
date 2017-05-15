using Common.Model;
using System.Collections.Generic;

namespace Caterer_DB.Models
{
    public class BearbeiteFragebogenViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FragenNachThemengebiet> Fragen { get; set; }

        public string Sonstiges { get; set; }
    }

    public class FragenViewModel
    {
        public int ID { get; set; } // for binding
        public string Text { get; set; }
        public bool IstMultiSelect { get; set; }
        public int? GegebeneAntwort { get; set; } // for binding
        public List<Antwort> Antworten { get; set; }
    }

    public class FragenNachThemengebiet
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public List<FragenViewModel> Questions { get; set; }
    }
}