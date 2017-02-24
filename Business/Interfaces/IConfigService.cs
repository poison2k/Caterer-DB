using DataAccess.Model;


namespace Business.Interfaces
{
    public interface IConfigService
    {
        Config GetConfig();
        void AddConfig(Config config);
        void EditConfig(Config config);
    }
}
