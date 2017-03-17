using Caterer_DB.Models;
using DataAccess.Model;

namespace Caterer_DB.Interfaces
{
    public interface IKategorieViewModelService
    {
        Kategorie Map_CreateKategorieViewModel_Kategorie(CreateKategorieViewModel createKategorieViewModel);
        Kategorie Map_EditKategorieViewModel_Kategorie(EditKategorieViewModel editKategorieViewModel);
        EditKategorieViewModel Map_Kategorie_EditKategorieViewModel(Kategorie kategorie);
        DetailsKategorieViewModel Map_Kategorie_DetailsKategorieViewModel(Kategorie kategorie);
        Kategorie Map_DeleteKategorieViewModel_Kategorie(DeleteKategorieViewModel deleteKategorieViewModel);
        DeleteKategorieViewModel Map_Kategorie_DeleteKategorieViewModel(Kategorie kategorie);
    }
}
