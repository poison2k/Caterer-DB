using DocumentFormat.OpenXml.Packaging;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDocxGenerator
    {
        Task GeneriereSeite(WordprocessingDocument wDoc);
    }
}