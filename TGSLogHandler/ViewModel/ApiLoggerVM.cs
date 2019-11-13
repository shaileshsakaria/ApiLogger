using System;

namespace TGSLogHandler.ViewModel
{
    public class ApiLoggerVM
    {
        public long loggerId { get; set; }                  // The (database) ID for the API log entry.
        public string application { get; set; }             // The application that made the request.
        public string applicaionUser { get; set; }                    // The user that made the request.
        public string machine { get; set; }                 // The machine that made the request.
        public string requestIpAddress { get; set; }        // The IP address that made the request.
        public string requestContentType { get; set; }      // The request content type.
        public string requestContentBody { get; set; }      // The request content body.
        public string requestUri { get; set; }              // The request URI.
        public string requestMethod { get; set; }           // The request method (GET, POST, etc).
        public string requestHeaders { get; set; }          // The request headers.
        public DateTime? requestTimestamp { get; set; }     // The request timestamp.
        public string responseContentType { get; set; }     // The response content type.
        public string responseContentBody { get; set; }     // The response content body.
        public int? responseStatusCode { get; set; }        // The response status code.
        public string responseHeaders { get; set; }         // The response headers.
        public DateTime? responseTimestamp { get; set; }    // The response timestamp.
    }
}
