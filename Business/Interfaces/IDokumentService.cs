using Common.Model;
using System.IO;

namespace Business.Interfaces
{
    public interface IDokumentService
    {
        void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream);
    }
}