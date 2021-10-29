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
    public class AreaDAL
    {
        public List<Area> SelectArea( string token)
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
            HttpResponseMessage response = client.GetAsync("/api/Area").Result;

            string stringData = response.Content.ReadAsStringAsync().Result;
            List<Area> area = JsonConvert.DeserializeObject<List<Area>>(stringData);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }
            else
            {
                return area;
            }
        }
        public Area SelectAreaBy_Id(int id, string token)
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
            HttpResponseMessage response = client.GetAsync($"/api/Area/{id}").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Area area = JsonConvert.DeserializeObject<Area>(stringData);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }
            else
            {
                return area;
            }
        }
        public void DeleteArea(int id, string token)
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
            HttpResponseMessage response = client.DeleteAsync($"/api/Area/{id}").Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;
        }
        public void UpdateArea(Area area, string token)
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
            var response = client.PutAsync($"/api/Area", contentData).Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;
        }
        public void InsertArea(Area area, string token)
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
            var response = client.PostAsync($"/api/Area", contentData).Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;
        }
    }
}
