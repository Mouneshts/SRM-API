using Newtonsoft.Json;
using SRM_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SRM_MVC.Services
{
    public class CoursesService : ICoursesService
    {
        public void AddCourse(Courses Course)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(Course),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Course/Add", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }

        public void DeleteCourse(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                HttpResponseMessage response = client.DeleteAsync("api/Course/Delete?id=" + id).Result;
                //return response.Content.ReadAsStringAsync().Result;
            }
        }

        

        public Courses GetCourse(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Course/GetById/" + id).Result;
                Courses Course = JsonConvert.DeserializeObject<Courses>(response.Content.ReadAsStringAsync().Result);
                return Course;
            }
        }

        public List<Courses> GetCourses()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Course/GetAll").Result;
                List<Courses> list = JsonConvert.DeserializeObject<List<Courses>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public void UpdateCourse(Courses Course)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(Course),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/Course/Edit", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
