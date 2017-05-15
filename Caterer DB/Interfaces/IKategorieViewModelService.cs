using Caterer_DB.Models;
using Common.Model;
using System.Collections.Generic;

namespace Caterer_DB.Interfaces
{
    public interface IKategorieViewModelService
    {
        Kategorie Map_CreateKategorieViewModel_Kategorie(CreateKategorieViewModel createKategorieViewModel);

        Kategorie Map_EditKategorieViewModel_Kategorie(EditKategorieViewModel editKategorieViewModel);

        EditKategorieViewModel Map_Kategorie_EditKategorieViewModel(Kategorie kategorie, List<Frage> fragenZuKategorie);

        DetailsKategorieViewModel Map_Kategorie_DetailsKategorieViewModel(Kategorie kategorie, List<Frage> fragenZuKategorie);

        Kategorie Map_DeleteKategorieViewModel_Kategorie(DeleteKategorieViewModel deleteKategorieViewModel);

        DeleteKategorieViewModel Map_Kategorie_DeleteKategorieViewModel(Kategorie kategorie);

        Kategorie Map_IndexKategorieViewModel_Kategorie(IndexKategorieViewModel indexKategorieViewModel);

        IndexKategorieViewModel Map_Kategorie_IndexKategorieViewModel(Kategorie kategorie, List<Frage> fragenZuKategorie);
    }
}