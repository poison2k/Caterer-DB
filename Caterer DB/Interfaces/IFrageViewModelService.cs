using Caterer_DB.Models;
using DataAccess.Model;
using System.Collections.Generic;

namespace Caterer_DB.Interfaces
{
    public interface IFrageViewModelService
    {
        Frage Map_CreateFrageViewModel_Frage(CreateFrageViewModel createFrageViewModel);
        Frage Map_EditFrageViewModel_Frage(EditFrageViewModel editFrageViewModel);

        CreateFrageViewModel CreateCreateFrageViewModel(List<Kategorie> kategorien);
        EditFrageViewModel Map_Frage_EditFrageViewModel(Frage Frage, List<Kategorie> kategorien);
        DetailsFrageViewModel Map_Frage_DetailsFrageViewModel(Frage Frage);
        Frage Map_DeleteFrageViewModel_Frage(DeleteFrageViewModel deleteFrageViewModel);
        DeleteFrageViewModel Map_Frage_DeleteFrageViewModel(Frage Frage);

        CreateFrageViewModel AddListsToCreateFrageViewModel(CreateFrageViewModel createFrageViewModel, List<Kategorie> kategorien);
        EditFrageViewModel AddListsToEditFrageViewModel(EditFrageViewModel editFrageViewModel, List<Kategorie> kategorien);
    }
}
