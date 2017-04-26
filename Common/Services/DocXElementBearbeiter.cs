using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Common.Services
{
    public class DocxElementBearbeiter
    {
        private readonly WordprocessingDocument _wordprocessingDocument;
        private readonly XDocument _xDocument;

        public DocxElementBearbeiter(WordprocessingDocument wordprocessingDocument)
        {
            _wordprocessingDocument = wordprocessingDocument;
            _xDocument = _wordprocessingDocument.MainDocumentPart.GetXDocument();
        }

        public XElement FindeSdtElementMitTextBoxNamen(string textBoxName)
        {
            IEnumerable<XElement> sdtElemente = _xDocument?.Root?.Element(W.body)?.Descendants(W.sdt);

            if (sdtElemente == null)
                throw new ArgumentException(@"Keine Sdt-Element im Dokument gefunden", nameof(textBoxName));

            foreach (var sdtElement in sdtElemente)
                foreach (var tag in sdtElement.Descendants(W.tag))
                    if (tag.Attributes(W.val).First().Value == textBoxName)
                        return sdtElement;

            throw new ArgumentException($"Sdt-Element {textBoxName} nichtgefunden", nameof(textBoxName));
        }

        #region Ganze Tabellen ersetzen
        public XElement FindeTabelleMitTableCaption(string tableCaptionName)
        {
            var tabellen = _xDocument?.Root?.Element(W.body)?.Elements(W.tbl);

            if (tabellen != null)
            {
                foreach (var tabelle in tabellen)
                {
                    if (tabelle.Descendants(W.tblCaption).Any())
                        return tabelle;
                }
            }

            return null;
        }

        public void ErsetzeTabelleMitTableCaptionMitWmlDocument(string tabellenCaptionName)
        {
            try
            {
                var tabelle = FindeTabelleMitTableCaption(tabellenCaptionName);
                if (tabelle != null)
                {
                    tabelle.AddBeforeSelf(new XElement(PtOpenXml.Insert, new XAttribute("Id", tabellenCaptionName)));
                    tabelle.Remove();
                }
                _wordprocessingDocument.MainDocumentPart.PutXDocument();
            }
            catch (Exception exception)
            {
                throw new ArgumentException("Tabelle nicht gefunden", exception);
            }
        }
        #endregion Ganze Tabellen ersetzen

        #region Tabellenzeile ersetzen
        public XElement FindeZeileMitTextBoxName(string textBoxName)
        {
            var tabellen = _xDocument?.Root?.Element(W.body)?.Elements(W.tbl);

            if (tabellen == null)
                return null;

            foreach (var tabelle in tabellen)
                foreach (var zeile in tabelle.Descendants(W.tr).Where(z => z.Descendants(W.sdt).Any()))
                    foreach (var inhalt in zeile.Descendants(W.sdt).Where(i => i.Descendants(W.tag).Any()))
                        foreach (var attribut in inhalt.Descendants(W.tag))
                            if (attribut.Attributes(W.val).First().Value == textBoxName)
                                return zeile;

            return null;
        }

        public void ErstelleZeileVorZeileMitTextBoxName(string templateZeileTextBoxName, string einfügenVorZeileTextBoxName, Dictionary<string, string> feldÄnderungen)
        {
            var templateZeile = FindeZeileMitTextBoxName(templateZeileTextBoxName);
            var einfügeVorZeile = FindeZeileMitTextBoxName(einfügenVorZeileTextBoxName);

            if (templateZeile == null || einfügeVorZeile == null)
                return;

            var neueZeile = new XElement(templateZeile);
            foreach (var änderungsSatz in feldÄnderungen)
                ErsetzeSdtInZeileDurchText(änderungsSatz.Key, änderungsSatz.Value, neueZeile);

            einfügeVorZeile.AddBeforeSelf(neueZeile);
            _wordprocessingDocument.MainDocumentPart.PutXDocument();
        }

        /// <summary>
        ///     Suche nach einem Sdt-Tag mittels des TextBoxNamens in einer übergebenen Zeile
        /// </summary>
        /// <param name="textBoxName"></param>
        /// <param name="content"></param>
        /// <param name="zeile"></param>
        public void ErsetzeSdtInZeileDurchText(string textBoxName, string content, XElement zeile)
        {
            var sdtsInZeile = zeile.Descendants(W.sdt);
            XElement zelle = null;
            XElement zuErsetzenderSdt = null;
            XElement neuerParagraph = null;

            foreach (var sdt in sdtsInZeile)
                foreach (var tag in sdt.Descendants(W.tag))
                    if (tag.Attributes(W.val).First().Value == textBoxName)
                        zuErsetzenderSdt = sdt;

            if (zuErsetzenderSdt != null)
            {
                zelle = zuErsetzenderSdt.Ancestors(W.tc).FirstOrDefault();
                if (zelle != null)
                    neuerParagraph = new XElement(zuErsetzenderSdt.Descendants(W.p).First());

                zuErsetzenderSdt.Remove();
            }

            var zParagraph = zelle?.Descendants(W.p).FirstOrDefault();
            if (zParagraph != null)
            {
                zParagraph?.AddBeforeSelf(neuerParagraph);
                zParagraph?.Remove();
            }
            else
            {
                var tcPr = zelle?.Descendants(W.tcPr);
                tcPr?.First().AddAfterSelf(neuerParagraph);
            }

            zelle?.Descendants(W.t).First().ReplaceWith(new XElement(W.t) { Value = content });

            _wordprocessingDocument.MainDocumentPart.PutXDocument();
        }

        internal void EntferneZeileMitTextBoxName(string textBoxName)
        {
            FindeZeileMitTextBoxName(textBoxName)?.Remove();
            _wordprocessingDocument.MainDocumentPart.PutXDocument();
        }
        #endregion Tabellenzeile ersetzen

        #region TextBox mit TextListe ersetzen
        public void ErsetzeTextBoxDurchTextListe(string textBoxNamen, List<string> textListe)
        {
            if (textListe == null || textListe.Count == 0)
            {
                ErsetzeTextBoxDurchText(textBoxNamen, "");
                return;
            }

            XElement sdtXElement = FindeSdtElementMitTextBoxNamen(textBoxNamen);

            // Zunächst muss herausgefunden werden, ob es sich bei dem Sdt-Element um
            // - SdtBlock
            // - SdtRun
            // - SdtCell
            // handelt

            if (sdtXElement.Descendants(W.tc).Any())
                ErsetzeSdtCellDurchTextListe(sdtXElement, textListe);
            else if (sdtXElement.Descendants(W.p).Any())
                ErsetzeSdtBlockDurchTextListe(sdtXElement, textListe);
            else
                ErsetzeSdtRunDurchTextListe(sdtXElement, textListe);
        }

        private void ErsetzeSdtCellDurchTextListe(XElement sdtXElement, List<string> textListe)
        {
            XElement neueZelle = sdtXElement.Descendants(W.tc).First();
            XElement paragraph = new XElement(neueZelle.Descendants(W.p).First());
            neueZelle.RemoveAll();
            foreach (var text in textListe)
            {
                XElement textElement = new XElement(W.t) { Value = "" };
                if (text != null)
                    textElement = new XElement(W.t) { Value = text };

                XElement neuerRun = new XElement(W.r);
                neuerRun.Add(textElement);
                XElement neuerParagraph = new XElement(paragraph);
                neuerParagraph.Add(new XElement(W.r));
                neueZelle.Add(neuerParagraph);
            }
            sdtXElement.ReplaceWith(neueZelle);
            _wordprocessingDocument.MainDocumentPart.PutXDocument();
        }

        private void ErsetzeSdtBlockDurchTextListe(XElement sdtXElement, List<string> textListe)
        {
            var sdtParagraph = sdtXElement.Elements(W.sdtContent).First().Element(W.p);
            if (sdtParagraph == null)
                return;

            XElement sdtParagraphProperties = sdtXElement.Descendants(W.pPr).FirstOrDefault();
            XElement neueParagrapProperties = new XElement(W.pPr);
            if (sdtParagraphProperties != null)
                neueParagrapProperties = new XElement(sdtParagraphProperties);

            XElement sdtRunProperties = sdtXElement.Descendants(W.rPr).FirstOrDefault();
            XElement neueRunProperties = new XElement(W.rPr);
            if (sdtRunProperties != null)
                neueRunProperties = new XElement(sdtRunProperties);

            sdtParagraph.RemoveAll();

            foreach (var text in textListe)
            {
                XElement textElement = new XElement(W.t) { Value = "" };
                if (text != null)
                    textElement = new XElement(W.t) { Value = text };
                XElement neuerRun = new XElement(W.r);
                neuerRun.Add(new XElement(neueRunProperties));
                neuerRun.Add(textElement);
                XElement neuerParagraph = new XElement(sdtParagraph);
                neuerParagraph.Add(new XElement(neueParagrapProperties));
                neuerParagraph.Add(new XElement(W.r));
                sdtXElement.AddBeforeSelf(neuerParagraph);
            }
            sdtXElement.Remove();
            _wordprocessingDocument.MainDocumentPart.PutXDocument();
        }

        private void ErsetzeSdtRunDurchTextListe(XElement sdtXElement, List<string> textListe)
        {
            XElement parent = sdtXElement.Parent;
            XElement sdtRunProperties = sdtXElement.Descendants(W.rPr).FirstOrDefault();
            XElement neueRunProperties = new XElement(W.rPr);
            if (sdtRunProperties != null)
                neueRunProperties = new XElement(sdtRunProperties);
            XElement tmpParagraph = new XElement(sdtXElement.Ancestors(W.p).First());
            XElement tmpParagraphProperties = new XElement(tmpParagraph.Descendants(W.pPr).First());
            tmpParagraph.RemoveAll();

            foreach (var text in textListe)
            {
                XElement textElement = new XElement(W.t) { Value = "" };
                if (text != null)
                    textElement = new XElement(W.t) { Value = text };
                XElement neuerRun = new XElement(W.r);
                neuerRun.Add(new XElement(neueRunProperties));
                neuerRun.Add(textElement);
                XElement neuerParagraph = new XElement(tmpParagraph);
                neuerParagraph.Add(new XElement(tmpParagraphProperties));
                neuerParagraph.Add(neuerRun);
                parent?.AddBeforeSelf(neuerParagraph);
            }
            parent?.Remove();
            _wordprocessingDocument.MainDocumentPart.PutXDocument();
        }
        #endregion TextBox mit TextListe ersetzen

        #region TextBox mit Text ersetzen
        public void ErsetzeTextBoxDurchText(string textBoxNamen, string neuerText)
        {
            XElement sdtXElement = FindeSdtElementMitTextBoxNamen(textBoxNamen);

            // Zunächst muss herausgefunden werden, ob es sich bei dem Sdt-Element um
            // - SdtBlock
            // - SdtRun
            // - SdtCell
            // handelt

            if (sdtXElement.Descendants(W.tc).Any())
                ErsetzeSdtCellDurchText(sdtXElement, neuerText);
            else if (sdtXElement.Descendants(W.p).Any())
                ErsetzeSdtBlockDurchText(sdtXElement, neuerText);
            else
                ErsetzeSdtRunDurchText(sdtXElement, neuerText);
        }

        private void ErsetzeSdtCellDurchText(XElement sdtXElement, string neuerText)
        {
            if (neuerText == null)
                neuerText = "";
            XElement neueZelle = sdtXElement.Descendants(W.tc).First();
            neueZelle.Descendants(W.t).First().ReplaceWith(new XElement(W.t) { Value = neuerText });
            sdtXElement.ReplaceWith(neueZelle);
            _wordprocessingDocument.MainDocumentPart.PutXDocument();
        }

        private void ErsetzeSdtBlockDurchText(XElement sdtXElement, string neuerText)
        {
            if (neuerText == null)
                neuerText = "";
            var sdtParagraph = sdtXElement.Elements(W.sdtContent).First().Element(W.p);
            if (sdtParagraph == null)
                return;

            XElement sdtParagraphProperties = sdtXElement.Descendants(W.pPr).FirstOrDefault();
        XElement pPr = new XElement(W.pPr);
            if (sdtParagraphProperties != null)
                pPr = new XElement(sdtParagraphProperties);

        XElement sdtRunProperties = sdtXElement.Descendants(W.rPr).FirstOrDefault();
        XElement neueRunProperties = new XElement(W.rPr);
            if (sdtRunProperties != null)
                neueRunProperties = new XElement(sdtRunProperties);

        sdtParagraph.RemoveAll();
            XElement neuerParagraph = new XElement(sdtParagraph);
        neuerParagraph.Add(pPr);
            XElement neuerRun = new XElement(W.r);
        neuerRun.Add(neueRunProperties);
            neuerRun.Add(new XElement(W.t) { Value = neuerText });
            neuerParagraph.Add(neuerRun);
            sdtXElement.ReplaceWith(neuerParagraph);
            _wordprocessingDocument.MainDocumentPart.PutXDocument();
        }

    private void ErsetzeSdtRunDurchText(XElement sdtXElement, string neuerText)
    {
        if (neuerText == null)
            neuerText = "";
        XElement neuerRun = new XElement(W.r);
        XElement sdtRunProperties = sdtXElement.Descendants(W.rPr).FirstOrDefault();
        XElement neueRunProperties = new XElement(W.rPr);
        if (sdtRunProperties != null)
            neueRunProperties = new XElement(sdtRunProperties);

        neuerRun.Add(neueRunProperties);
        neuerRun.Add(new XElement(W.t) { Value = neuerText });
        sdtXElement.ReplaceWith(neuerRun);

            _wordprocessingDocument.MainDocumentPart.PutXDocument();
      
        }
    #endregion TextBox mit Text ersetzen
}
}
