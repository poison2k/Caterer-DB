using System.Collections.Generic;
using System.IO;
using Common.Model;

namespace Common.Interfaces
{
    public interface IDocxService
    {
        void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream, List<Frage> fragen);
    }
}
