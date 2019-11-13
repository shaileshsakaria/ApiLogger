using System;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoggerWebAPI.Controllers;
using LoggerWebAPI.Models;


namespace UnitTestLogger
{
    [TestClass]
    public class StudentControllerUnitTest
    {
        [TestMethod]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60724/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/Student/GetStudents").Result;
                Console.WriteLine("Response: " + response);
            }

        }

    }
}
