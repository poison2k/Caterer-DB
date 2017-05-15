using Common.Model;

namespace Common.Interfaces
{
    public class TestDocX
    {
        public string TemplateDateiPfad { get; set; }

        private Benutzer _Benutzer;

        public TestDocX(Benutzer benutzer, string templateDateiPfad)
        {
            _Benutzer = benutzer;
            TemplateDateiPfad = templateDateiPfad;
        }
    }
}