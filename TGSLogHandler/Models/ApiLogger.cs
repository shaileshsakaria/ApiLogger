using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGSLogHandler.Models
{
    [Table("ApiLogger")]
    public class ApiLogger
    {
        [Key]
        public long loggerId { get; set; }

        [StringLength(200)]
        public string application { get; set; }

        [StringLength(200)]
        public string applicaionUser { get; set; }

        [StringLength(200)]
        public string machine { get; set; }

        public DateTime? requestTimestamp { get; set; }

        [StringLength(200)]
        public string requestIpAddress { get; set; }

        public string requestContentType { get; set; }

        public string requestContentBody { get; set; }

        [StringLength(500)]
        public string requestUri { get; set; }

        [StringLength(100)]
        public string requestMethod { get; set; }

        public string requestHeaders { get; set; }

        public DateTime? responseTimestamp { get; set; }

        public string responseContentType { get; set; }

        public string responseContentBody { get; set; }

        public int? responseStatusCode { get; set; }

        public string responseHeaders { get; set; }
    }
}
