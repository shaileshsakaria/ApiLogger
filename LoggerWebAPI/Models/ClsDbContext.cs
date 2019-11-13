using System.Data.Entity;

namespace LoggerWebAPI.Models
{
    public class ClsDbContext : DbContext
    {
        public ClsDbContext() : base("UtitliyProject") { }

        public DbSet<Student> Students { get; set; }
    }
}