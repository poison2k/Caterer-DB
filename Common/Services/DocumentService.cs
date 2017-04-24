using Common.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class DocumentService : IDocumentService
    {
        public void writeWordDocument(string filepath, Benutzer benutzer)
        {
            string newFile = "C:\\Download\\" + DateTime.Now.ToString("yyyymmdd") + "_" + benutzer.Firmenname + ".docx";

            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }
            File.Copy(filepath, newFile);

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(newFile, true))
            {
                string docText = null;

                using (StreamReader sr = new StreamReader(wordDocument.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }
                
                docText = docText.Replace("Anrede", benutzer.Anrede);
                docText = docText.Replace("Vorname", benutzer.Vorname);
                docText = docText.Replace("Nachname", benutzer.Nachname);
                docText = docText.Replace("FunktionAnsprechpartner", benutzer.FunktionAnsprechpartner);
                docText = docText.Replace("Mail", benutzer.Mail);
                docText = docText.Replace("Firmenname", benutzer.Firmenname);
                docText = docText.Replace("Telefon", benutzer.Telefon);
                docText = docText.Replace("Straße", benutzer.Straße);
                docText = docText.Replace("Postleitzahl", benutzer.Postleitzahl);
                docText = docText.Replace("Ort", benutzer.Ort);               

                using (StreamWriter sw = new StreamWriter(wordDocument.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }

                wordDocument.Close();
            }
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
