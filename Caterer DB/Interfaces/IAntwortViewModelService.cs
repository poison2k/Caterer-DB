using Caterer_DB.Models;
using Caterer_DB.ViewModel;
using Common.Model;

namespace Caterer_DB.Interfaces
{
    public interface IAntwortViewModelService
    {
        Antwort Map_CreateAntwortViewModel_Antwort(CreateAntwortViewModel createAntwortViewModel);

        Antwort Map_EditAntwortViewModel_Antwort(EditAntwortViewModel editAntwortViewModel);

        EditAntwortViewModel Map_Antwort_EditAntwortViewModel(Antwort antwort);

        DetailsAntwortViewModel Map_Antwort_DetailsAntwortViewModel(Antwort antwort);

        Antwort Map_DeleteAntwortViewModel_Antwort(DeleteAntwortViewModel deleteAntwortViewModel);

        DeleteAntwortViewModel Map_Antwort_DeleteAntwortViewModel(Antwort antwort);
    }
}