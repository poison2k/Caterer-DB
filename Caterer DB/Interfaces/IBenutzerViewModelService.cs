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
        EditBenutzerViewModel Map_Benutzer_EditBenutzerViewModel(Benutzer benutzer);
        DetailsBenutzerViewModel Map_Benutzer_DetailsBenutzerViewModel(Benutzer benutzer);
        Benutzer Map_DeleteBenutzerViewModel_Benutzer(DeleteBenutzerViewModel deleteBenutzerViewModel);
        DeleteBenutzerViewModel Map_Benutzer_DeleteBenutzerViewModel(Benutzer benutzer);
        Benutzer Map_RegisterBenutzerViewModel_Benutzer(RegisterBenutzerViewModel registerBenutzerViewModel);
    }
}
