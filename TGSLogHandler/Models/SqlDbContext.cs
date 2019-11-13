using System.Configuration;
using System.Data.Entity;

namespace TGSLogHandler.Models
{
    public class SqlDbContext : DbContext
    {
        public static string LoggerConnectionString = ConfigurationManager.AppSettings["LoggerConnectionString"];
        public SqlDbContext() : base(LoggerConnectionString)
        { }

        public DbSet<ApiLogger> ApiLogger { get; set; }
    }
}
