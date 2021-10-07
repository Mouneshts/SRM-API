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
    public class BranchService : IBranchService
    {
        public void AddBranch(Branch Branch)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(Branch),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Branch/Add", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }

        public void DeleteBranch(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                HttpResponseMessage response = client.DeleteAsync("api/Branch/Delete?id=" + id).Result;
                //return response.Content.ReadAsStringAsync().Result;
            }
        }



        public Branch GetBranch(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Branch/GetById/" + id).Result;
                Branch Branch = JsonConvert.DeserializeObject<Branch>(response.Content.ReadAsStringAsync().Result);
                return Branch;
            }
        }

        public List<Branch> GetBranchs()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Branch/GetAll").Result;
                List<Branch> list = JsonConvert.DeserializeObject<List<Branch>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public void UpdateBranch(Branch Branch)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(Branch),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/Branch/Edit", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
