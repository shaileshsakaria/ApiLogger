using TGSLogHandler.Utility;

namespace TGSLogHandler.FactoryMethod
{
    public class LoggerStorageFactory
    {
        public ILoggerStorage GetLoggerStorage(string LoggerStorageOption)
        {
            ILoggerStorage returnLoggerStorage = null;
            if (LoggerStorageOption == Enums.LoggerStorage.TextFile.ToString())
            {
                returnLoggerStorage = new TextFileLoggerStorage();
            }
            else if (LoggerStorageOption == Enums.LoggerStorage.MongoDB.ToString())
            {
                returnLoggerStorage = new MongoDBLoggerStorage();
            }
            else if (LoggerStorageOption == Enums.LoggerStorage.SqlServerDB.ToString())
            {
                returnLoggerStorage = new SqlServerLoggerStorage();
            }
            return returnLoggerStorage;
        }
    }
}
