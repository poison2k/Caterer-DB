
using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Common.Services
{
    public static class OpenXmlUtils
    {
        public static OpenXmlElement SucheTabellenReiheMitContentControl(WordprocessingDocument wordprocessingDocument, string controlName)
        {
            var contentControls = ContentControls(wordprocessingDocument);
            var contentControl =
                contentControls.SingleOrDefault(e =>
                {
                    var firstOrDefault = e.Descendants<Tag>().FirstOrDefault();
                    return firstOrDefault != null && firstOrDefault.Val.Value == controlName;
                });

            OpenXmlElement parentElement = contentControl.Parent;
            while (!(parentElement is TableRow))
                parentElement = parentElement.Parent;

            return parentElement;
        }

        public static Table SucheTabelleMitContentControl(WordprocessingDocument wordprocessingDocument, string controlName)
        {
            var contentControls = ContentControls(wordprocessingDocument);
            var contentControl =
                contentControls.SingleOrDefault(e =>
                {
                    var firstOrDefault = e.Descendants<Tag>().FirstOrDefault();
                    return firstOrDefault != null && firstOrDefault.Val.Value == controlName;
                });

            OpenXmlElement parentElement = contentControl.Parent;
            while (!(parentElement is Table))
                parentElement = parentElement.Parent;

            return (Table)parentElement;
        }

        public static void ErsetzeContentControl(WordprocessingDocument wordprocessingDocument, string controlName, string text)
        {
            try
            {
                var contentControls = ContentControls(wordprocessingDocument);
                var contentControl =
                    contentControls.SingleOrDefault(e =>
                    {
                        var firstOrDefault = e.Descendants<Tag>().FirstOrDefault();
                        return firstOrDefault != null && firstOrDefault.Val.Value == controlName;
                    });
                ErsetzeContentControl(contentControl, text);
            }
            catch (Exception)
            {
            }
        }

        public static void ErsetzeContentControl(TableRow tableRow, string controlName, string text)
        {
            try
            {
                var contentControls = tableRow.Descendants().Where(e => e is SdtBlock || e is SdtRun || e is SdtCell);

                var contentControl =
                    contentControls.SingleOrDefault(e =>
                    {
                        var firstOrDefault = e.Descendants<Tag>().FirstOrDefault();
                        return firstOrDefault != null && firstOrDefault.Val.Value == controlName;
                    });
                ErsetzeContentControl(contentControl, text);
            }
            catch (Exception)
            {
            }
        }

        public static void ErsetzeContentControl(OpenXmlElement contentControl, string text)
        {
            if (contentControl is SdtCell)
                ErsetzeSdtCellDurchTabellenZelle(contentControl, text);
            else if (contentControl is SdtRun)
                ErsetzeSdtRunDurchParagraph(contentControl, text);
            else
                ErsetzeDurchParagraph(contentControl, text);
        }


        public static Paragraph ErstelleSeitenumbruch()
        {
            var paragraph = new Paragraph();

            var run = new Run();
            var umbruch = new Break() { Type = BreakValues.Page };

            run.Append(umbruch);

            paragraph.Append(run);
            return paragraph;
        }


        private static void ErsetzeDurchParagraph(OpenXmlElement contentControl, string neuerText)
        {
            var paragraph = contentControl.Descendants<Paragraph>().FirstOrDefault().CloneNode(true);
            var text = paragraph.Descendants<Text>().FirstOrDefault();
            var neuesTextElement = new Text { Text = neuerText };

            text.InsertAfterSelf(neuesTextElement);
            text.Remove();
            contentControl.InsertAfterSelf(paragraph);
            contentControl.Remove();
        }

        private static void ErsetzeSdtRunDurchParagraph(OpenXmlElement contentControl, string neuerText)
        {
            var contentControlParagraph = contentControl.Descendants<Paragraph>().FirstOrDefault();
            Paragraph paragraph = new Paragraph();
            Text text = new Text();
            if (contentControlParagraph == null)
            {
                var run = (Run)contentControl.Parent.Descendants<Run>().FirstOrDefault().CloneNode(true);
                text = run.Descendants<Text>().FirstOrDefault();
                var neuesTextElement = new Text();
                neuesTextElement.Text = neuerText;

                text.InsertAfterSelf(neuesTextElement);
                text.Remove();
                contentControl.InsertAfterSelf(run);
            }
            else
            {
                paragraph = (Paragraph)contentControlParagraph.CloneNode(true);
                text = paragraph.Descendants<Text>().FirstOrDefault();
                var neuesTextElement = new Text();
                neuesTextElement.Text = neuerText;

                text.InsertAfterSelf(neuesTextElement);
                text.Remove();
                contentControl.InsertAfterSelf(paragraph);
            }

            contentControl.Remove();
        }

        private static void ErsetzeSdtCellDurchTabellenZelle(OpenXmlElement contentControl, string neuerText)
        {
            var tableCell = contentControl.Descendants<TableCell>().FirstOrDefault().CloneNode(true);
            var text = tableCell.Descendants<Text>().FirstOrDefault();
            var neuesTextElement = new Text();
            neuesTextElement.Text = neuerText;

            text.InsertAfterSelf(neuesTextElement);
            text.Remove();
            contentControl.InsertAfterSelf(tableCell);
            contentControl.Remove();
        }

        private static IEnumerable<OpenXmlElement> ContentControls(this OpenXmlPart part)
        {
            return part.RootElement
                .Descendants()
                .Where(e => e is SdtBlock || e is SdtRun || e is SdtCell);
        }

        private static IEnumerable<OpenXmlElement> ContentControls(this WordprocessingDocument doc)
        {
            foreach (var cc in doc.MainDocumentPart.ContentControls())
                yield return cc;
            foreach (var header in doc.MainDocumentPart.HeaderParts)
                foreach (var cc in header.ContentControls())
                    yield return cc;
            foreach (var footer in doc.MainDocumentPart.FooterParts)
                foreach (var cc in footer.ContentControls())
                    yield return cc;
            if (doc.MainDocumentPart.FootnotesPart != null)
                foreach (var cc in doc.MainDocumentPart.FootnotesPart.ContentControls())
                    yield return cc;
            if (doc.MainDocumentPart.EndnotesPart != null)
                foreach (var cc in doc.MainDocumentPart.EndnotesPart.ContentControls())
                    yield return cc;
        }

    }



}