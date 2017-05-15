using Common.Model;
using System.Collections.Generic;
using System.IO;

namespace Common.Interfaces
{
    public interface IDocxService
    {
        void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream, List<Frage> fragen);
    }
}