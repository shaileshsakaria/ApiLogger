using System.Configuration;
using TGSLogHandler.Models;
using TGSLogHandler.ViewModel;

namespace TGSLogHandler.FactoryMethod
{
    public class SqlServerLoggerStorage : ILoggerStorage
    {
        SqlDbContext dbContext;
        public SqlServerLoggerStorage()
        {
            dbContext = new SqlDbContext();
        }

        public void LoggerDetail(ApiLoggerVM model)
        {
            ApiLogger Log = new ApiLogger();
            string LoggerApplicationName = ConfigurationManager.AppSettings["LoggerApplicationName"];
            Log.application = LoggerApplicationName;
            Log.applicaionUser = model.applicaionUser;
            Log.machine = model.machine;
            Log.requestTimestamp = model.requestTimestamp;
            Log.requestIpAddress = model.requestIpAddress;
            Log.requestContentType = model.requestContentType;
            Log.requestContentBody = model.requestContentBody;
            Log.requestUri = model.requestUri;
            Log.requestMethod = model.requestMethod;
            Log.requestHeaders = model.requestHeaders;
            Log.responseTimestamp = model.responseTimestamp;
            Log.responseContentType = model.responseContentType;
            Log.responseContentBody = model.responseContentBody;
            Log.responseStatusCode = model.responseStatusCode;
            Log.responseHeaders = model.responseHeaders;
            dbContext.ApiLogger.Add(Log);
            dbContext.SaveChanges();
        }
    }
}
