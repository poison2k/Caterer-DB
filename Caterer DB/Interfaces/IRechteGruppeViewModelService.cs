using Caterer_DB.Models;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caterer_DB.Interfaces
{
    public interface IRechteGruppeViewModelService
    {
        RechteGruppe Map_CreateRechteGruppeViewModel_RechteGruppe(CreateRechteGruppeViewModel createRechteGruppeViewModel);
        RechteGruppe Map_EditRechteGruppeViewModel_RechteGruppe(EditRechteGruppeViewModel editRechteGruppeViewModel);
        EditRechteGruppeViewModel Map_RechteGruppe_EditRechteGruppeViewModel(RechteGruppe RechteGruppe);
        DetailsRechteGruppeViewModel Map_RechteGruppe_DetailsRechteGruppeViewModel(RechteGruppe RechteGruppe);
        RechteGruppe Map_DeleteRechteGruppeViewModel_RechteGruppe(DeleteRechteGruppeViewModel deleteRechteGruppeViewModel);
        DeleteRechteGruppeViewModel Map_RechteGruppe_DeleteRechteGruppeViewModel(RechteGruppe RechteGruppe);
    }
}
