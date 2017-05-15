using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using Common.Model;
using System.Collections.Generic;
using Caterer_DB.ViewModel;

namespace Caterer_DB.Interfaces
{
    public interface IFragebogenViewModelService
    {
        FragebogenViewModelService Map_FragebogenViewModelService_FragebogenViewModelService(FragebogenViewModelService fragebogenViewModelService);

        BearbeiteFragebogenViewModel Map_Fragen_BearbeiteFragebogenViewModel(List<List<Frage>> fragenListen, List<int> nutzerAntworten);

        List<int> Map_BearbeiteFragebogenViewModel_BenutzerResultSet(BearbeiteFragebogenViewModel bearbeitefragebogenviewmodel);
    }
}