using Caterer_DB.Models;
using Caterer_DB.ViewModel;
using Common.Model;

namespace Caterer_DB.Interfaces
{
    public interface IRechtViewModelService
    {
        Recht Map_CreateRechtViewModel_Recht(CreateRechtViewModel createRechtViewModel);

        Recht Map_EditRechtViewModel_Recht(EditRechtViewModel editRechtViewModel);

        EditRechtViewModel Map_Recht_EditRechtViewModel(Recht recht);

        DetailsRechtViewModel Map_Recht_DetailsRechtViewModel(Recht recht);

        Recht Map_DeleteRechtViewModel_Recht(DeleteRechtViewModel deleteRechtViewModel);

        DeleteRechtViewModel Map_Recht_DeleteRechtViewModel(Recht recht);
    }
}