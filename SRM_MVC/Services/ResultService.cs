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
    public class ResultService :IResultService
    {
        public void AddResult(Result Result)
        {
            using (HttpClient client = new HttpClient())
            {
            
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(Result),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Result/Add", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }

        public void DeleteResult(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                HttpResponseMessage response = client.DeleteAsync("api/Result/Delete/" + id).Result;
                //return response.Content.ReadAsStringAsync().Result;
            }
        }

      
        public Result GetResult(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Result/GetById/" + id).Result;
                Result Result = JsonConvert.DeserializeObject<Result>(response.Content.ReadAsStringAsync().Result);
                return Result;
            }
        }

        public List<Result> GetResults()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Result/GetAll").Result;
                List<Result> list = JsonConvert.DeserializeObject<List<Result>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public void UpdateResult(Result Result)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(Result),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/Result/Edit", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
