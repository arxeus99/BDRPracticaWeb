using BDRPracticaWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BDRPracticaWeb
{
    public class APIConnectionHelper
    {

        private HttpClient client;

        
        public APIConnectionHelper()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44314/data/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<Pais>> GetPaises()
        {
            HttpResponseMessage response = await client.GetAsync("getPaises");

            List<Pais> paises = new List<Pais>();

            response.EnsureSuccessStatusCode();

            paises = await response.Content.ReadFromJsonAsync<List<Pais>>();

            return paises;
        }

        public async Task<Pais> GetPais(Int64 IdPais)
        {
            HttpResponseMessage response = await client.GetAsync($"GetPais?IdPais={IdPais}");

            response.EnsureSuccessStatusCode();

            var pais = await response.Content.ReadFromJsonAsync<Pais>();

            return pais;
        }

        public async Task<string> InsertPais(Pais pais)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("insertPais", pais);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();

        }

        public async Task<string> UpdatePais(Pais pais)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("updatePais", pais);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeletePais(Int64 IdPais)
        {
            HttpResponseMessage response = await client.GetAsync($"deletePais?IdPais={IdPais}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

    }
}
