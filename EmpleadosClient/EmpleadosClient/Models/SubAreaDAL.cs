using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmpleadosClient.Models
{
    public class SubAreaDAL
    {
        public List<SubArea> SelectSubArea(string token)
        {
            string baseUrl = "https://localhost:44382";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",
                token
                );
            HttpResponseMessage response = client.GetAsync("/api/SubArea").Result;

            string stringData = response.Content.ReadAsStringAsync().Result;
            List<SubArea> area = JsonConvert.DeserializeObject<List<SubArea>>(stringData);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }
            else
            {
                return area;
            }
        }
        public SubArea SelectSubAreaBy_Id(int id, string token)
        {
            string baseUrl = "https://localhost:44382";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",
                token
                );
            HttpResponseMessage response = client.GetAsync($"/api/SubArea/{id}").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            SubArea area = JsonConvert.DeserializeObject<SubArea>(stringData);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }
            else
            {
                return area;
            }
        }
        public void DeleteSubArea(int id, string token)
        {
            string baseUrl = "https://localhost:44382";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",
                token
                );
            HttpResponseMessage response = client.DeleteAsync($"/api/SubArea/{id}").Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;
        }
        public void UpdateSubArea(SubArea area, string token)
        {
            string baseUrl = "https://localhost:44382";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",
                token
                );
            string stringData = JsonConvert.SerializeObject(area);
            var contentData = new StringContent(
                stringData, System.Text.Encoding.UTF8, "application/json"
                );
            var response = client.PutAsync($"/api/SubArea", contentData).Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;
        }
        public void InsertSubArea(SubArea area, string token)
        {
            string baseUrl = "https://localhost:44382";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",
                token
                );
            string stringData = JsonConvert.SerializeObject(area);
            var contentData = new StringContent(
                stringData, System.Text.Encoding.UTF8, "application/json"
                );
            var response = client.PostAsync($"/api/SubArea", contentData).Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;
        }
    }
}
