using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    internal class APIConnectionDetails
    {
        public static string baseUrl = "https://localhost:7195/api/";
        public static string Url { get; set; } = "https://localhost:7195/api/";
        private static readonly HttpClient httpClient = new HttpClient();

        public static void SetUrl(string urlEnd)
        {
            Url = $"{baseUrl}{urlEnd}";
        }

        public static JsonSerializerOptions JOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            return options;
        }

        public static HttpClient getHTTP()
        {
            return httpClient;
        }
    }
    
}
