using Entities;
using Microsoft.AspNetCore.Http;
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
    public class EmpleadoDAL
    {        
        public List<Empleado> SelectEmpleados(string filtro,string token)
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
            HttpResponseMessage response;
            if (!String.IsNullOrEmpty(filtro))
            {
                response = client.GetAsync($"/api/Empleados?filtro={filtro}").Result;
            }
            else
            {
                response = client.GetAsync("/api/Empleados").Result;
            }
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<Empleado> empleados = JsonConvert.DeserializeObject<List<Empleado>>(stringData);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }
            else
            {
                return empleados;
            }
        }
        public Empleado SelectEmpleadosBy_Id(int id,string token)
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
            HttpResponseMessage response = client.GetAsync($"/api/Empleados/{id}").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Empleado empleado = JsonConvert.DeserializeObject<Empleado>(stringData);
            if (response.StatusCode==HttpStatusCode.Unauthorized)
            {
                return null;
            }
            else
            {
                return empleado;
            }
        }
        public void DeleteEmpleado(int id,string token)
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
            HttpResponseMessage response = client.DeleteAsync($"/api/Empleados/{id}").Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;            
        }
        public void UpdateEmpleado(Empleado empleado,string token)
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
            string stringData = JsonConvert.SerializeObject(empleado);
            var contentData = new StringContent(
                stringData,System.Text.Encoding.UTF8,"application/json"
                );
            var response = client.PutAsync($"/api/Empleados",contentData).Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;
        }
        public void InsertEmpleado(Empleado empleado,string token)
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
            string stringData = JsonConvert.SerializeObject(empleado);
            var contentData = new StringContent(
                stringData, System.Text.Encoding.UTF8, "application/json"
                );
            var response = client.PostAsync($"/api/Empleados", contentData).Result;
            string stringDataResponse = response.Content.ReadAsStringAsync().Result;
        }
    }
}
