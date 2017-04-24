using Common.Interfaces;
using DataAccess.Model;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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
    }
}
