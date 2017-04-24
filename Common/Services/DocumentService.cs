using Common.Interfaces;
using DataAccess.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using Path = System.IO.Path;

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

       
        

        public void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream)
        {
            {
                WordprocessingDocument openXmlDocument = WordprocessingDocument.Open(memoryStream, true);

                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "uebernehmenderNachname", benutzer.Nachname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "uebernehmenderVorname", benutzer.Vorname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "uebernehmenderApperatNr", benutzer.Telefon);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "uebernehmenderDienststelle", benutzer.Firmenname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "bemerkung", benutzer.Sonstiges);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "aktuellesDatum", DateTime.Now.ToString("d"));

                var tableRow = (TableRow)OpenXmlUtils.SucheTabellenReiheMitContentControl(openXmlDocument, "materialGeraeteart");
                Table table = OpenXmlUtils.SucheTabelleMitContentControl(openXmlDocument, "materialGeraeteart");

                var neueTabellenZeile = new TableRow();
                OpenXmlElement neueTabelle = new Table();

                Paragraph seitenumbruch = OpenXmlUtils.ErstelleSeitenumbruch();

                var leerZeile = new Paragraph();
                int counter = 0;
                foreach (int antwortId in benutzer.AntwortIDs)
                {
                    counter++;
                    neueTabellenZeile = (TableRow)tableRow.CloneNode(true);
                    OpenXmlUtils.ErsetzeContentControl(neueTabellenZeile, "materialGeraeteart", antwortId.ToString());

                    if (counter < 17)
                        tableRow.InsertBeforeSelf(neueTabellenZeile);
                    else if (counter == 17)
                    {
                        OpenXmlElement aktuellesElement = table.InsertAfterSelf(seitenumbruch);
                        neueTabelle = aktuellesElement.InsertAfterSelf(table.CloneNode(true));
                        neueTabelle.LastChild.Remove();
                        neueTabelle.LastChild.InsertAfterSelf(neueTabellenZeile);
                    }
                    else
                        neueTabelle.LastChild.InsertAfterSelf(neueTabellenZeile);
                }

                if (counter > 7 && counter < 17)
                {
                    table.InsertAfterSelf(seitenumbruch);
                }

                tableRow.Remove();

                openXmlDocument.MainDocumentPart.Document.Save();
            }
        }
    }
}
