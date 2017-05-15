using Common.Model;

namespace DataAccess.Interfaces
{
    public interface IConfigRepository
    {
        void AddConfig(Config config);

        void EditConfig(Config config);

        Config GetConfig();
    }
}