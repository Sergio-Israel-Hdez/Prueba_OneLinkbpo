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
    public class TipoDocumentoDAL
    {
        public List<TipoDocumento> SelectTipoDocumento(string token)
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
            HttpResponseMessage response = client.GetAsync("/api/TipoDocumento").Result;

            string stringData = response.Content.ReadAsStringAsync().Result;
            List<TipoDocumento> ltsTipoDocumento = JsonConvert.DeserializeObject<List<TipoDocumento>>(stringData);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }
            else
            {
                return ltsTipoDocumento;
            }
        }
    }
}
