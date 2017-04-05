using Common.Interfaces;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;

namespace Common.Services
{
    public class DocumentService : IDocumentService
    {
        public void writeWordDocument(string filepath, string text)
        {
            WordprocessingDocument wordDocument;

            if (!File.Exists(filepath))
            {
                wordDocument = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document);
                wordDocument.AddMainDocumentPart().Document = new Document();
            }
            else
            {
                wordDocument = WordprocessingDocument.Open(filepath, true);
            }
            
            Body body = wordDocument.MainDocumentPart.Document.AppendChild(new Body());
            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());

            run.AppendChild(new Text(text));

            wordDocument.Close();
        }
    }
}
