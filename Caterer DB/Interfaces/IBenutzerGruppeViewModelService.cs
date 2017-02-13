using AutoMapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caterer_DB.Models.Interfaces
{
    public interface IBenutzerGruppeViewModelService
    {
        editBenutzerGruppeViewModel Map_CreateBenutzerGruppeViewModel_BenutzerGruppe(CreateBenutzerGruppeViewModel createBenutzerGruppeViewModel);
        editBenutzerGruppeViewModel Map_EditBenutzerGruppeViewModel_BenutzerGruppe(EditBenutzerGruppeViewModel editBenutzerGruppeViewModel);
        EditBenutzerGruppeViewModel Map_BenutzerGruppe_EditBenutzerGruppeViewModel(editBenutzerGruppeViewModel benutzerGruppe);
        DetailsBenutzerGruppeViewModel Map_BenutzerGruppe_DetailsBenutzerGruppeViewModel(editBenutzerGruppeViewModel benutzerGruppe);
        editBenutzerGruppeViewModel Map_DeleteBenutzerGruppeViewModel_BenutzerGruppe(DeleteBenutzerGruppeViewModel deleteBenutzerGruppeViewModel);
        DeleteBenutzerGruppeViewModel Map_BenutzerGruppe_DeleteBenutzerGruppeViewModel(editBenutzerGruppeViewModel benutzerGruppe);
    }
}
