
namespace Common.Services
{
    using Interfaces;
    using DocumentFormat.OpenXml.Packaging;
    using OpenXmlPowerTools;


    public class DocxDocumentGenerator
    {
        public Source WmlSource => new Source(WmlDocument, true);
        private WmlDocument WmlDocument { get; set; }
        private WordprocessingDocument WDoc { get; set; }
        private OpenXmlMemoryStreamDocument StreamDoc { get; set; }

        public DocxDocumentGenerator(byte[] rohDaten, IDocxGenerator docxGenerator)
        {
            OpenXmlPowerToolsDocument doc = new OpenXmlPowerToolsDocument(rohDaten);
            StreamDoc = new OpenXmlMemoryStreamDocument(doc);
            WDoc = StreamDoc.GetWordprocessingDocument();
            try
            {
                docxGenerator.GeneriereSeite(WDoc);
                WDoc.Dispose();
                WmlDocument = StreamDoc.GetModifiedWmlDocument();
            }
            finally
            {
                WDoc.Dispose();
                StreamDoc.Dispose();
            }
        }

        public void Dispose()
        {
            WDoc.Dispose();
        }
    }


}