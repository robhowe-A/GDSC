using System.Net.Http;
using System.Text.Json.Nodes;

namespace waterlocator.Models
{
    class APIRequest
    {
        public Kml kml;
        public void Start()
        {
            //coordinates
            string Northern_most = @"32.874699";
            string Western_most = @"-96.958875";
            string Eastern_most = @"-96.932789";
            string Southern_most = @"32.859052";


            // //Tab-delineated option
            // string waterservicesOutFile = $"{Directory.GetCurrentDirectory()}\\waterservices.txt";
            // string waterservicesBaseAddr = @"https://waterservices.usgs.gov/";
            // string waterservicesURIRelative = @"nwis/site/?format=rdb&bBox=-96.958875,32.859052,-96.932789,32.874699&siteStatus=all";

            //google maps option
            string waterservicesOutFile = $"{Directory.GetCurrentDirectory()}\\waterservices.txt";
            string waterservicesBaseAddr = @"https://waterservices.usgs.gov/";

            //this is the API string. the provided coordinates are entered as values to the API's coordinate parameter
            //https://waterservices.usgs.gov/nwis/site/?format=gm&bBox=-96.958875,32.859052,-96.932789,32.874699&siteStatus=all
            string waterservicesURIRelative = @$"nwis/site/?format=gm&bBox={Western_most},{Southern_most},{Eastern_most},{Northern_most}&siteStatus=all";
            Console.WriteLine(waterservicesURIRelative);

            //Call Fetch
            this.Fetch(waterservicesBaseAddr, waterservicesURIRelative).Wait();

        }

        private async Task Fetch(string baseAddress, string urlRelative)
        {
            try
            {
                FetchRequest apiFetch = new FetchRequest(baseAddress, urlRelative);
                this.kml = await apiFetch.GetAsync();

                Console.WriteLine($"Kml: \n{kml}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}