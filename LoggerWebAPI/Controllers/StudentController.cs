using LoggerWebAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LoggerWebAPI.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        ClsDbContext context;
        public StudentController()
        {
            context = new ClsDbContext();
        }
        [HttpGet]
        [Route("GetStudents")]
        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        [HttpGet]
        [Route("GetStudent")]
        public Student GetStudent(long Id)
        {
            Student model = context.Students.Find(Id);
            return model;
        }

        [HttpPost]
        [Route("AddStudent")]
        public Student AddStudent()
        {
            var userModel = HttpContext.Current.Request.Form["userModel"];
            Student model = JsonConvert.DeserializeObject<Student>(userModel);
            context.Students.Add(model);
            context.SaveChanges();
            return model;
        }

        [HttpPost]
        [Route("UpdateStudent")]
        public Student UpdateStudent()
        {
            var userModel = HttpContext.Current.Request.Form["userModel"];
            Student model = JsonConvert.DeserializeObject<Student>(userModel);
            context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return model;
        }

        [HttpGet]
        [Route("DeleteStudent")]
        public Student DeleteStudent(long id)
        {
            Student stud = context.Students.Find(id);
            context.Students.Remove(stud);
            context.SaveChanges();
            return stud;
        }
    }
}
