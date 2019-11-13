using System.Web.Http;
using TGSLogHandler.Helper;
using TGSLogHandler.Utility;

namespace LoggerWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new LogHandler(Enums.LoggerStorage.TextFile.ToString()));
        }
    }
}
