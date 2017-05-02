using Common.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;

namespace Common.Services
{
    public class DocumentService : IDocumentService
    {
        public IFrageRepository FrageRepository { get; set; }

        public DocumentService(IFrageRepository frageRepository)
        {
            FrageRepository = frageRepository;
        }

        public void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream)
        {
            {
                WordprocessingDocument openXmlDocument = WordprocessingDocument.Open(memoryStream, true);

                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Nachname", benutzer.Nachname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Vorname", benutzer.Vorname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Telefon", benutzer.Telefon);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Firma", benutzer.Firmenname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "FirmaAnschrift", benutzer.Firmenname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Fax", benutzer.Fax);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Straße", benutzer.Straße);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Postleitzahl", benutzer.Postleitzahl);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "OrtAnschrift", benutzer.Ort);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Anrede", benutzer.Anrede);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Internetadresse", benutzer.Internetadresse);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Bemerkung", benutzer.Sonstiges);

                var tableRow = (TableRow)OpenXmlUtils.SucheTabellenReiheMitContentControl(openXmlDocument, "Frage");
                Table table = OpenXmlUtils.SucheTabelleMitContentControl(openXmlDocument, "Frage");

                var neueTabellenZeile = new TableRow();
                OpenXmlElement neueTabelle = new Table();

                Paragraph seitenumbruch = OpenXmlUtils.ErstelleSeitenumbruch();

                var leerZeile = new Paragraph();
                int counter = 1;
                Frage letzteFrage = null;
                neueTabellenZeile = (TableRow)tableRow.CloneNode(true);


                foreach (int antwortId in benutzer.AntwortIDs)
                {
                    
                    Frage aktuelleFrage = FrageRepository.SearchFrageByAntwortId(antwortId);
                    string verketteteAntworten = "";
                    List<Antwort> tmpAntworten = new List<Antwort>(aktuelleFrage.Antworten);

                    if (letzteFrage == aktuelleFrage)
                    {
                        continue;
                    }

                    for (int i = 0; i < aktuelleFrage.Antworten.Count; i++)
                    {
                        if (!benutzer.AntwortIDs.Contains(aktuelleFrage.Antworten[i].AntwortId))
                        {
                            tmpAntworten.Remove(aktuelleFrage.Antworten[i]);
                        }
                    }

                    aktuelleFrage.Antworten = tmpAntworten;

                    neueTabellenZeile = (TableRow)tableRow.CloneNode(true);

                    for (int i = 0; i < aktuelleFrage.Antworten.Count; i++)
                    {
                        if (verketteteAntworten != "")
                        {
                            verketteteAntworten = verketteteAntworten + ", ";
                        }
                        verketteteAntworten = verketteteAntworten + aktuelleFrage.Antworten[i].Bezeichnung;
                    }

                    OpenXmlUtils.ErsetzeContentControl(neueTabellenZeile, "Frage", aktuelleFrage.Bezeichnung);
                    OpenXmlUtils.ErsetzeContentControl(neueTabellenZeile, "Antwort", verketteteAntworten);

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
                    {
                        neueTabelle.LastChild.InsertAfterSelf(neueTabellenZeile);
                    }
                    counter++;
                    letzteFrage = aktuelleFrage;
                }

                tableRow.Remove();

                openXmlDocument.MainDocumentPart.Document.Save();
            }
        }
    }
}
