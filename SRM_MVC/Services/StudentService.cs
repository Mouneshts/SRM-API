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
    public class StudentService : IStudentService
    {
        public void AddStudent(Student student)
        {
            using (HttpClient client = new HttpClient())
            {
           
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(student),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Student/Add", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }

        public void DeleteStudent(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                HttpResponseMessage response = client.DeleteAsync("api/Student/Delete?id=" + id).Result;
                //return response.Content.ReadAsStringAsync().Result;
            }
        }


        //public Result GetResult(int sid, int semid)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44354/");
        //        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
        //        client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
        //        HttpResponseMessage response = client.GetAsync("api/Student/GetById/" + sid +"&semid"+semid).Result;
        //        Result student = JsonConvert.DeserializeObject<Result>(response.Content.ReadAsStringAsync().Result);
        //        return student;
        //    }
        //}

        public Student GetStudent(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Student/GetById/" + id).Result;
                Student student = JsonConvert.DeserializeObject<Student>(response.Content.ReadAsStringAsync().Result);
                return student;
            }
        }

        public List<Student> GetStudents()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Student/GetAll").Result;
                List<Student> list = JsonConvert.DeserializeObject<List<Student>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public void UpdateStudent(Student student)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(student),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/Student/Edit", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }

        //Result    
        public List<Result> GetResult(int sid, int semid)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Student/GetResult?StudentId=" + sid + "&semester=" + semid).Result;
                List<Result> student = JsonConvert.DeserializeObject<List<Result>>(response.Content.ReadAsStringAsync().Result);
                return student;
            }
        }



    }
}
