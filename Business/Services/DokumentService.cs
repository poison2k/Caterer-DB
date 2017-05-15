using System.IO;
using Business.Interfaces;
using Common.Interfaces;
using Common.Model;

namespace Business.Services
{
    public class DokumentService : IDokumentService
    {
        public IDocxService DocumentService { get; set; }

        public IFrageService FrageService { get; set; }

        public DokumentService(IDocxService documentService, IFrageService frageService)
        {
            DocumentService = documentService;
            FrageService = frageService;
        }

        public void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream)
        {

            DocumentService.DokumentDrucken(benutzer, memoryStream, FrageService.FindAlleFragen());
        }
    }
}
