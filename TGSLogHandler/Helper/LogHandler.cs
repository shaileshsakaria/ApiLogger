using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TGSLogHandler.FactoryMethod;
using TGSLogHandler.ViewModel;

namespace TGSLogHandler.Helper
{
    public class LogHandler : DelegatingHandler
    {
        private static string LoggerStorageOptions = string.Empty;
        LoggerStorageFactory factory = new LoggerStorageFactory();

        public LogHandler(string LoggerStorage)
        {
            LoggerStorageOptions = LoggerStorage;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var apiLogEntry = CreateApiLogEntryWithRequestData(request);
            var response = (dynamic)null;
            Task.Run(() =>
            {
                try
                {
                    if (request.Content != null)
                    {
                        request.Content.ReadAsStringAsync()
                            .ContinueWith(task =>
                            {
                                apiLogEntry.requestContentBody = task.Result;
                            }, cancellationToken);
                        //while (true) { Thread.Sleep(1000); }
                    }
                }
                catch (Exception ex)
                {
                    string ExceptionMessage = ex.Message;
                }
            });

            await base.SendAsync(request, cancellationToken)
                   .ContinueWith(task =>
                   {
                       response = task.Result;
                       Task.Run(() =>
                       {
                           try
                           {
                               apiLogEntry = CreateApiLogEntryWithResponseData(response, apiLogEntry);
                               #region Save the API log entry to the loggerStorage options
                               ILoggerStorage apiLoggerStorage = factory.GetLoggerStorage(LoggerStorageOptions);
                               apiLoggerStorage.LoggerDetail(apiLogEntry);
                               #endregion Save Log
                           }
                           catch (Exception ex)
                           {
                               string ExceptionMessage = ex.Message;
                           }
                       }, cancellationToken);
                   });
            return response;
        }

        private ApiLoggerVM CreateApiLogEntryWithRequestData(HttpRequestMessage request)
        {
            var context = ((HttpContextBase)request.Properties["MS_HttpContext"]);
            string RequestHeaders = SerializeHeaders(request.Headers);
            return new ApiLoggerVM
            {
                applicaionUser = context.User.Identity.Name,
                machine = Environment.MachineName,
                requestContentType = context.Request.ContentType,
                requestIpAddress = context.Request.UserHostAddress,
                requestMethod = request.Method.Method,
                requestTimestamp = DateTime.Now,
                requestHeaders = RequestHeaders,
                requestUri = request.RequestUri.ToString()
            };
        }

        private ApiLoggerVM CreateApiLogEntryWithResponseData(dynamic response, ApiLoggerVM apiLogEntry)
        {

            apiLogEntry.responseStatusCode = (int)response.StatusCode;
            apiLogEntry.responseTimestamp = DateTime.Now;

            if (response.Content != null)
            {
                apiLogEntry.responseContentBody = response.Content.ReadAsStringAsync().Result;
                apiLogEntry.responseContentType = response.Content.Headers.ContentType.MediaType;
                apiLogEntry.responseHeaders = SerializeHeaders(response.Content.Headers);
            }
            return apiLogEntry;
        }

        private string SerializeHeaders(HttpHeaders headers)
        {
            var dict = new Dictionary<string, string>();
            foreach (var item in headers.ToList())
            {
                if (item.Value != null)
                {
                    var header = String.Empty;
                    foreach (var value in item.Value)
                    {
                        header += value + " ";
                    }
                    // Trim the trailing space and add item to the dictionary
                    header = header.TrimEnd(" ".ToCharArray());
                    dict.Add(item.Key, header);
                }
            }
            return JsonConvert.SerializeObject(dict, Formatting.Indented);
        }
    }
}
