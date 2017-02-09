using Caterer_DB.Models;
using DataAccess.Model;

namespace Caterer_DB.Interfaces
{
    public interface IBenutzerViewModelService
    {
        AnmeldenBenutzerViewModel GeneriereAnmeldenBenutzerViewModel(Benutzer benutzer);
        AnmeldenBenutzerViewModel GeneriereAnmeldenBenutzerViewModel(int benutzerId = -1, string infobox = "");

        Benutzer Map_CreateBenutzerViewModel_Benutzer(CreateBenutzerViewModel createBenutzerViewModel);
        Benutzer Map_EditBenutzerViewModel_Benutzer(EditBenutzerViewModel editBenutzerViewModel);
        Benutzer Map_MyDataBenutzerViewModel_Benutzer(MyDataBenutzerViewModel myDataBenutzerViewModel);
        Benutzer Map_DeleteBenutzerViewModel_Benutzer(DeleteBenutzerViewModel deleteBenutzerViewModel);
        Benutzer Map_RegisterBenutzerViewModel_Benutzer(RegisterBenutzerViewModel registerBenutzerViewModel);

        EditBenutzerViewModel Map_Benutzer_EditBenutzerViewModel(Benutzer benutzer);
        MyDataBenutzerViewModel Map_Benutzer_MyDataBenutzerViewModel(Benutzer benutzer);
        DetailsBenutzerViewModel Map_Benutzer_DetailsBenutzerViewModel(Benutzer benutzer);
        DeleteBenutzerViewModel Map_Benutzer_DeleteBenutzerViewModel(Benutzer benutzer);
        RegisterBenutzerViewModel CreateNewRegisterBenutzerViewModel();

        RegisterBenutzerViewModel AddListsToRegisterViewModel(RegisterBenutzerViewModel registerBenutzerViewModel);
    }
}
