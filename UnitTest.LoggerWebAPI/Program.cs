using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace UnitTest.LoggerWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:60724/api/Student/GetStudent?Id=2";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(url);
                var responseGetStudent = client.GetAsync(url).Result;
                Console.WriteLine("Get Student Response: " + responseGetStudent);
            }

            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:60724/api/Student/GetStudents";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(url);
                var responseGetAllStudents = client.GetAsync(url).Result;
                Console.WriteLine("Get All Students Response: " + responseGetAllStudents);
            }

            Console.ReadLine();
        }
    }
}




