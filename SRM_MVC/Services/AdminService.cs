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
    public class AdminService : IAdminService
    {
        public void AddAdmin(Admin admin)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(admin),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Admin/Add", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }

        public void DeleteAdmin(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                HttpResponseMessage response = client.DeleteAsync("api/Admin/Delete?id=" + id).Result;
                //return response.Content.ReadAsStringAsync().Result;
            }
        }



        public Admin GetAdmin(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetById/" + id).Result;
                Admin admin = JsonConvert.DeserializeObject<Admin>(response.Content.ReadAsStringAsync().Result);
                return admin;
            }
        }

        public List<Admin> GetAdmins()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType); //add content type to the request header
                HttpResponseMessage response = client.GetAsync("api/Admin/GetAll").Result;
                List<Admin> list = JsonConvert.DeserializeObject<List<Admin>>(response.Content.ReadAsStringAsync().Result);
                return list;
            }
        }

        public void UpdateAdmin(Admin admin)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44354/");
                var contentData = new StringContent(JsonConvert.SerializeObject(admin),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("api/Admin/Edit", contentData).Result;
                // return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
