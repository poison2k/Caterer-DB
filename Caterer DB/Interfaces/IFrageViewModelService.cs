using Caterer_DB.Models;
using DataAccess.Model;
using System.Collections.Generic;

namespace Caterer_DB.Interfaces
{
    public interface IFrageViewModelService
    {
        Frage Map_CreateFrageViewModel_Frage(CreateFrageViewModel createFrageViewModel);
        Frage Map_EditFrageViewModel_Frage(EditFrageViewModel editFrageViewModel);

        CreateFrageViewModel CreateCreateFrageViewModel(List<Sparte> sparten);
        EditFrageViewModel Map_Frage_EditFrageViewModel(Frage Frage, List<Sparte> sparten);
        DetailsFrageViewModel Map_Frage_DetailsFrageViewModel(Frage Frage);
        Frage Map_DeleteFrageViewModel_Frage(DeleteFrageViewModel deleteFrageViewModel);
        DeleteFrageViewModel Map_Frage_DeleteFrageViewModel(Frage Frage);

        CreateFrageViewModel AddListsToCreateFrageViewModel(CreateFrageViewModel createFrageViewModel, List<Sparte> sparten);
        EditFrageViewModel AddListsToEditFrageViewModel(EditFrageViewModel editFrageViewModel, List<Sparte> sparten);
    }
}
