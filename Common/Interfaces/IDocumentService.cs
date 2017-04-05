using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDocumentService
    {
        void writeWordDocument(string filepath, string text);
    }
}
