using System;
using System.Configuration;
using System.IO;
using TGSLogHandler.ViewModel;

namespace TGSLogHandler.FactoryMethod
{
    public class TextFileLoggerStorage : ILoggerStorage
    {
        string TextFileDirectory = string.Empty;
        string TextFilePath = string.Empty;
        string TextFileName = string.Empty;
        public static object LockThread = new object();
        public void LoggerDetail(ApiLoggerVM model)
        {
            lock (LockThread)
            {
                string CurrentUTCDate = DateTime.UtcNow.Date.ToString("MMM-dd-yyyy");
                TextFileDirectory = string.Concat(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Log");
                bool TextFileDirectoryExits = System.IO.Directory.Exists(TextFileDirectory);
                if (!TextFileDirectoryExits)
                    System.IO.Directory.CreateDirectory(TextFileDirectory);
                TextFileName = CurrentUTCDate + ".txt";
                TextFilePath = string.Concat(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Log\\", TextFileName);

                string LoggerApplicationName = ConfigurationManager.AppSettings["LoggerApplicationName"];
                var message = string.Format("-------------------------------------------------------------");
                message += Environment.NewLine;
                message += string.Format("Application: {0}", LoggerApplicationName);
                message += Environment.NewLine;
                message += string.Format("User: {0}", model.applicaionUser);
                message += Environment.NewLine;
                message += string.Format("Machine: {0}", Environment.MachineName);
                message += Environment.NewLine;
                message += string.Format("================= Request Details: {0} ======================", model.requestTimestamp);
                message += Environment.NewLine;
                message += string.Format("RequestIpAddress: {0}", model.requestIpAddress);
                message += Environment.NewLine;
                message += string.Format("RequestContentType: {0}", model.requestContentType);
                message += Environment.NewLine;
                message += string.Format("RequestContentBody: {0}", model.requestContentBody);
                message += Environment.NewLine;
                message += string.Format("RequestUri: {0}", model.requestUri);
                message += Environment.NewLine;
                message += string.Format("RequestMethod: {0}", model.requestMethod);
                message += Environment.NewLine;
                message += string.Format("RequestHeaders: {0}", model.requestHeaders);
                message += Environment.NewLine;
                message += string.Format("================= Response Details: {0} ======================", model.responseTimestamp);
                message += Environment.NewLine;
                message += string.Format("ResponseContentType: {0}", model.responseContentType);
                message += Environment.NewLine;
                message += string.Format("ResponseContentBody: {0}", model.responseContentBody);
                message += Environment.NewLine;
                message += string.Format("ResponseStatusCode: {0}", model.responseStatusCode);
                message += Environment.NewLine;
                message += string.Format("ResponseHeaders: {0}", model.responseHeaders);
                message += Environment.NewLine;
                using (StreamWriter writer = File.AppendText(TextFilePath))
                {
                    writer.WriteLine(message);
                    writer.Close();
                }
            }
        }
    }
}
