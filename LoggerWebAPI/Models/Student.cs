using System.ComponentModel.DataAnnotations;

namespace LoggerWebAPI.Models
{
    public class Student
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
}