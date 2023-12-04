using System;
using System.IO;
using System.Net.Http;

namespace APIRequest
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

        public async Task GetAsync(string outFilePath)
        {
            using HttpResponseMessage response = await httpClient.GetAsync(this.urlRelative);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            //TODO: ideally, this is in a different class
            //write the fetch to the file
            File.WriteAllText(outFilePath, jsonResponse);
            this.result = jsonResponse;

        }
    }
}