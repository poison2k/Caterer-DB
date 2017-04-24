using Common.Interfaces;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Common.Services
{
    public class DocumentService : IDocumentService
    {
        public void writeWordDocument(string filepath, string text)
        {
            WordprocessingDocument wordDocument = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document);
            wordDocument.AddMainDocumentPart().Document = new Document();
            Body body = wordDocument.MainDocumentPart.Document.AppendChild(new Body());
            Paragraph paragraph = body.AppendChild(new Paragraph());
            Run run = paragraph.AppendChild(new Run());

            run.AppendChild(new Text(text));

            wordDocument.Close();

            //WebClient webClient = new WebClient();
            //webClient.DownloadFile(filepath, @"c:\\Download\\downloadedFile.docx");
        }
    }
}
