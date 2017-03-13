﻿using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.Interfaces
{
    public interface IFragebogenViewModelService
    {
        FragebogenViewModelService Map_FragebogenViewModelService_FragebogenViewModelService(FragebogenViewModelService fragebogenViewModelService);
        BearbeiteFragebogenViewModel Map_Fragen_BearbeiteFragebogenViewModel(List<Frage> fragen);
    }
}