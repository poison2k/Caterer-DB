using Caterer_DB.Models;
using Caterer_DB.ViewModel;
using Common.Model;

namespace Caterer_DB.Interfaces
{
    public interface IConfigViewModelService
    {
        Config Map_EditConfigViewModel_Config(EditConfigViewModel editConfigViewModel);

        EditConfigViewModel Map_Config_EditConfigViewModel(Config config);
    }
}