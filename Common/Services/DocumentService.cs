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
        public IAntwortRepository AntwortRepository { get; set; }
        public IFrageRepository FrageRepository { get; set; }
        public IKategorieRepository KategorieRepository { get; set; }
        public IFragebogenRepository FragebogenRepository { get; set; }

        public DocumentService(IAntwortRepository antwortRepository, IFrageRepository frageRepository, IKategorieRepository kategorieRepository, IFragebogenRepository fragebogenRepository)
        {
            AntwortRepository = antwortRepository;
            FrageRepository = frageRepository;
            KategorieRepository = kategorieRepository;
            FragebogenRepository = fragebogenRepository;
        }

        public void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream)
        {
            {
                WordprocessingDocument openXmlDocument = WordprocessingDocument.Open(memoryStream, true);

                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Nachname", benutzer.Nachname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Vorname", benutzer.Vorname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Telefon", benutzer.Telefon);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Firma", benutzer.Firmenname);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Fax", benutzer.Fax);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Straße", benutzer.Straße);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Postleitzahl", benutzer.Postleitzahl);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Ort", benutzer.Ort);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Anrede", benutzer.Anrede);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Internetadresse", benutzer.Internetadresse);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Bemerkung", benutzer.Sonstiges);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "aktuellesDatum", DateTime.Now.ToString("d"));

                var tableRow = (TableRow)OpenXmlUtils.SucheTabellenReiheMitContentControl(openXmlDocument, "Kategorie");
                Table table = OpenXmlUtils.SucheTabelleMitContentControl(openXmlDocument, "Kategorie");

                var neueTabellenZeile = new TableRow();
                OpenXmlElement neueTabelle = new Table();

                Paragraph seitenumbruch = OpenXmlUtils.ErstelleSeitenumbruch();

                var leerZeile = new Paragraph();
                int counter = 0;
                foreach (int antwortId in benutzer.AntwortIDs)
                {
                    Frage aktuelleFrage = FrageRepository.SearchFrageByAntwortId(antwortId);
                    string verketteteAntworten = "";

                    counter++;
                    neueTabellenZeile = (TableRow)tableRow.CloneNode(true);

                    OpenXmlUtils.ErsetzeContentControl(neueTabellenZeile, "Kategorie", KategorieRepository.SearchKategorieIdById(aktuelleFrage.Kategorie.KategorieId).Bezeichnung);
                    OpenXmlUtils.ErsetzeContentControl(neueTabellenZeile, "Frage", aktuelleFrage.Bezeichnung);

                    for (int i = 0; i < aktuelleFrage.Antworten.Count; i++)
                    {
                        foreach (int antwort in benutzer.AntwortIDs)
                        {
                            if (antwort == aktuelleFrage.Antworten[i].AntwortId)
                            {
                                verketteteAntworten = verketteteAntworten + Convert.ToString(i + 1) + ". " + aktuelleFrage.Antworten[i].Bezeichnung + Environment.NewLine;
                            }
                        }
                    }


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
