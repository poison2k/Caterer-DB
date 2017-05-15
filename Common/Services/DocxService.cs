using Common.Interfaces;
using Common.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.Services
{
    public class DocxService : IDocxService
    {
        public void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream, List<Frage> fragen)
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
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Bemerkung", benutzer.Bemerkung);
                OpenXmlUtils.ErsetzeContentControl(openXmlDocument, "Sonstiges", benutzer.Sonstiges);

                var tableRow = (TableRow)OpenXmlUtils.SucheTabellenReiheMitContentControl(openXmlDocument, "Frage");
                Table table = OpenXmlUtils.SucheTabelleMitContentControl(openXmlDocument, "Frage");

                var neueTabellenZeile = new TableRow();
                OpenXmlElement neueTabelle = new Table();

                Paragraph seitenumbruch = OpenXmlUtils.ErstelleSeitenumbruch();

                int counter = 1;
                Frage letzteFrage = null;

                foreach (int antwortId in benutzer.AntwortIDs)
                {
                    Frage aktuelleFrage = searchFrageByAntwortId(fragen, antwortId);
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

        private Frage searchFrageByAntwortId(List<Frage> fragen, int id)
        {
            return (from frage in fragen from antwort in frage.Antworten where antwort.AntwortId == id select frage).FirstOrDefault();
        }
    }
}