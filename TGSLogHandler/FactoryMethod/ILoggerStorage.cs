using TGSLogHandler.ViewModel;

namespace TGSLogHandler.FactoryMethod
{
    public interface ILoggerStorage
    {
        void LoggerDetail(ApiLoggerVM model);
    }
}
