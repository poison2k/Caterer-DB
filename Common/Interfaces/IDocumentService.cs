using DataAccess.Model;
using OpenXmlPowerTools;
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
        void writeWordDocument(string filepath, List<string> text);

        void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream);
    }
}
