using Caterer_DB.Models;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caterer_DB.Interfaces
{
    public interface IRechtViewModelService
    {
        Recht Map_CreateRechtViewModel_Recht(CreateRechtViewModel createRechtViewModel);
        Recht Map_EditRechtViewModel_Recht(EditRechtViewModel editRechtViewModel);
        EditRechtViewModel Map_Recht_EditRechtViewModel(Recht recht);
        DetailsRechtViewModel Map_Recht_DetailsRechtViewModel(Recht recht);
        Recht Map_DeleteRechtViewModel_Recht(DeleteRechtViewModel deleteRechtViewModel);
        DeleteRechtViewModel Map_Recht_DeleteRechtViewModel(Recht recht);
    }
}
