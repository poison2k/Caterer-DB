using Common.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;

namespace Common.Services
{
    public class DocumentService : IDocumentService
    {
        public void writeWordDocument(string filepath, List<string> benutzerDaten)
        {
            WordprocessingDocument wordDocument = WordprocessingDocument.Open(filepath,true);
            wordDocument.MainDocumentPart.Document.RemoveAllChildren();
            Body body = wordDocument.MainDocumentPart.Document.AppendChild(new Body());          
            Paragraph paragraph = body.AppendChild(new Paragraph());
            Run run = paragraph.AppendChild(new Run());

            foreach (var item in benutzerDaten)
            {
                run.AppendChild(new Text(item));
            }
            
            
            wordDocument.Close();

            //WebClient webClient = new WebClient();
            //webClient.DownloadFile(filepath, @"c:\\Download\\downloadedFile.docx");
        }
    }
}
