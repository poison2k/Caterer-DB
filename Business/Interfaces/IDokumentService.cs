using System.Collections.Generic;
using System.IO;
using Common.Model;

namespace Business.Interfaces
{
    public interface IDokumentService
    {
        void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream);

    }
}
