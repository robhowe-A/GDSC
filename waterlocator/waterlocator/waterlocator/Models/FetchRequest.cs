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

        public async Task<Kml> GetAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync(this.urlRelative);

            response.EnsureSuccessStatusCode();

            var contentText = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"result: \n{contentText}");
            var mySerializer = new XmlSerializer(typeof(Kml));
            Kml kml;
            using (TextReader reader = new StringReader(contentText))
            {
                kml = (Kml)mySerializer.Deserialize(reader);
                Console.WriteLine($"kml.document->altitudeMode is: {kml.Document.Placemark.Point.altitudeMode}");
                Console.WriteLine($"kml.document->coordinates is: {kml.Document.Placemark.Point.coordinates}");

            }


            if (kml == null)
            {
                return new Kml();
            }

            return kml; 
        }
    }
}