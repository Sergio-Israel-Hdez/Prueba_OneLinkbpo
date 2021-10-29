using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmpleadosClient.Models
{
    public class UsuarioDAL
    {
        public JWT Login(Usuario usuario)
        {
            string baseUrl = "https://localhost:44382";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            Usuario user = new Usuario()
            {
                IdUsuario = 0,
                Usuario1 = usuario.Usuario1,
                Password = usuario.Password
            };
            string stringData = JsonConvert.SerializeObject(user);
            var contentData = new StringContent(
                stringData, System.Text.Encoding.UTF8, "application/json"
                );
            HttpResponseMessage response = client.PostAsync("/api/Usuario", contentData).Result;
            if (response.IsSuccessStatusCode)
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                JWT jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);
                return jwt;
            }
            else
            {
                return null;
            }
        }
    }
}
