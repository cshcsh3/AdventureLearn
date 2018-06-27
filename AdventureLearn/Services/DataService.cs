using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLearn.Services
{
    public class DataService
    {
        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            // Handler needed for web
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);

            client.BaseAddress = new Uri("https://3f9cf8bd.ngrok.io");
            var response = await client.GetAsync("api/" + queryString);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
    }
}
