﻿using Caterer_DB.Models;
using Caterer_DB.ViewModel;
using Common.Model;

namespace Caterer_DB.Interfaces
{
    public interface IRechteGruppeViewModelService
    {
        RechteGruppe Map_CreateRechteGruppeViewModel_RechteGruppe(CreateRechteGruppeViewModel createRechteGruppeViewModel);

        RechteGruppe Map_EditRechteGruppeViewModel_RechteGruppe(EditRechteGruppeViewModel editRechteGruppeViewModel);

        EditRechteGruppeViewModel Map_RechteGruppe_EditRechteGruppeViewModel(RechteGruppe rechteGruppe);

        DetailsRechteGruppeViewModel Map_RechteGruppe_DetailsRechteGruppeViewModel(RechteGruppe rechteGruppe);

        RechteGruppe Map_DeleteRechteGruppeViewModel_RechteGruppe(DeleteRechteGruppeViewModel deleteRechteGruppeViewModel);

        DeleteRechteGruppeViewModel Map_RechteGruppe_DeleteRechteGruppeViewModel(RechteGruppe rechteGruppe);
    }
}