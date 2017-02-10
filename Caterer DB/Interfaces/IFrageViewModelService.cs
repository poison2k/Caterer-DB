using Caterer_DB.Models;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caterer_DB.Interfaces
{
    public interface IFrageViewModelService
    {
        Frage Map_CreateFrageViewModel_Frage(CreateFrageViewModel createFrageViewModel);
        Frage Map_EditFrageViewModel_Frage(EditFrageViewModel editFrageViewModel);
        EditFrageViewModel Map_Frage_EditFrageViewModel(Frage Frage);
        DetailsFrageViewModel Map_Frage_DetailsFrageViewModel(Frage Frage);
        Frage Map_DeleteFrageViewModel_Frage(DeleteFrageViewModel deleteFrageViewModel);
        DeleteFrageViewModel Map_Frage_DeleteFrageViewModel(Frage Frage);
    }
}
