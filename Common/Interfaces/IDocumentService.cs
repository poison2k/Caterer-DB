using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDocumentService
    {
        void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream);
    }
}
