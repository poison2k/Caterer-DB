using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDocxGenerator
    {
        Task GeneriereSeite(WordprocessingDocument wDoc);
    }
}
