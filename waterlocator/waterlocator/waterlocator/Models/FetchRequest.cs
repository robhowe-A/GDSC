using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace waterlocator.Models
{
    class FetchRequest
    {
        public Uri baseUrl { get; set; }
        public string urlRelative { get; set; }
        public string? result { get; set; }
        public FetchRequest(string baseUrl, string relativeUrl)
        {
            this.baseUrl = new Uri(baseUrl);
            this.urlRelative = relativeUrl;
            this.httpClient.BaseAddress = this.baseUrl;
        }
        private HttpClient httpClient = new HttpClient();

        public async Task<Water> GetAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync(this.urlRelative);

            response.EnsureSuccessStatusCode();

            var contentText = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"result: \n{contentText}");
            var mySerializer = new XmlSerializer(typeof(Water));
            var water = new Water();
            using (TextReader reader = new StringReader(contentText))
            {
                water = (Water)mySerializer.Deserialize(reader);
            }


            if (water == null)
            {
                return new Water();
            }

            return water; 
        }
    }
}