using Caterer_DB.Models;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caterer_DB.Interfaces
{
    public interface ISparteViewModelService
    {
        Sparte Map_CreateSparteViewModel_Sparte(CreateSparteViewModel createSparteViewModel);
        Sparte Map_EditSparteViewModel_Sparte(EditSparteViewModel editSparteViewModel);
        EditSparteViewModel Map_Sparte_EditSparteViewModel(Sparte sparte);
        DetailsSparteViewModel Map_Sparte_DetailsSparteViewModel(Sparte sparte);
        Sparte Map_DeleteSparteViewModel_Sparte(DeleteSparteViewModel deleteSparteViewModel);
        DeleteSparteViewModel Map_Sparte_DeleteSparteViewModel(Sparte sparte);
    }
}
