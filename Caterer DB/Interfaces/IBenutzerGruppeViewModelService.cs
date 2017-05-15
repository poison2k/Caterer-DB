using Common.Model;


namespace Caterer_DB.Models.Interfaces
{
    public interface IBenutzerGruppeViewModelService
    {
        BenutzerGruppe Map_CreateBenutzerGruppeViewModel_BenutzerGruppe(CreateBenutzerGruppeViewModel createBenutzerGruppeViewModel);

        BenutzerGruppe Map_EditBenutzerGruppeViewModel_BenutzerGruppe(EditBenutzerGruppeViewModel editBenutzerGruppeViewModel);

        EditBenutzerGruppeViewModel Map_BenutzerGruppe_EditBenutzerGruppeViewModel(BenutzerGruppe benutzerGruppe);

        DetailsBenutzerGruppeViewModel Map_BenutzerGruppe_DetailsBenutzerGruppeViewModel(BenutzerGruppe benutzerGruppe);

        BenutzerGruppe Map_DeleteBenutzerGruppeViewModel_BenutzerGruppe(DeleteBenutzerGruppeViewModel deleteBenutzerGruppeViewModel);

        DeleteBenutzerGruppeViewModel Map_BenutzerGruppe_DeleteBenutzerGruppeViewModel(BenutzerGruppe benutzerGruppe);
    }
}