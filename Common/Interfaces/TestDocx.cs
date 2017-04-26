using Common.Services;
using DataAccess.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public class TestDocX
    {
        public string TemplateDateiPfad { get; set; }



        private Benutzer _Benutzer;
        public TestDocX(Benutzer benutzer, string templateDateiPfad)
        {
            _Benutzer = benutzer;
            TemplateDateiPfad = templateDateiPfad;
        }

    
    }
}
