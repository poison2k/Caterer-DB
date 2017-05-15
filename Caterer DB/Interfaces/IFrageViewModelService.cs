using Caterer_DB.Models;
using Common.Model;
using System.Collections.Generic;
using Caterer_DB.ViewModel;

namespace Caterer_DB.Interfaces
{
    public interface IFrageViewModelService
    {
        ListViewModel<IndexFrageViewModel> GeneriereListViewModel(List<Frage> fragenListe, int gesamtAnzahlDatensätze, int aktuelleSeite = 1, int seitenGröße = 10);

        Frage Map_CreateFrageViewModel_Frage(CreateFrageViewModel createFrageViewModel);

        Frage Map_EditFrageViewModel_Frage(EditFrageViewModel editFrageViewModel);

        IndexFrageViewModel GeneriereIndexFrageViewModel(Frage frage);

        CreateFrageViewModel CreateCreateFrageViewModel(List<Kategorie> kategorien);

        EditFrageViewModel Map_Frage_EditFrageViewModel(Frage frage, List<Kategorie> kategorien);

        DetailsFrageViewModel Map_Frage_DetailsFrageViewModel(Frage frage);

        Frage Map_DeleteFrageViewModel_Frage(DeleteFrageViewModel deleteFrageViewModel);

        DeleteFrageViewModel Map_Frage_DeleteFrageViewModel(Frage frage);

        CreateFrageViewModel AddListsToCreateFrageViewModel(CreateFrageViewModel createFrageViewModel, List<Kategorie> kategorien);

        EditFrageViewModel AddListsToEditFrageViewModel(EditFrageViewModel editFrageViewModel, List<Kategorie> kategorien);

        List<AjaxAntwort> WandleAntworteninAjaxAntworten(List<Antwort> antworten);
    }
}