using System.Net.Http;
using System.Text.Json.Nodes;

namespace APIRequest
{
    class Program
    {


        static void Main(string[] args)
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
            string waterservicesURIRelative = @$"nwis/site/?format=gm&bBox={Western_most},{Southern_most},{Eastern_most},{Northern_most}&siteStatus=all";

            //Call Fetch
            Fetch(waterservicesBaseAddr, waterservicesURIRelative, waterservicesOutFile).Wait();

        }
        static async Task Fetch(string baseAddress, string urlRelative, string outFilePath)
        {
            try
            {
                FetchRequest apiFetch = new FetchRequest(baseAddress, urlRelative);
                await apiFetch.GetAsync(outFilePath);
                Console.WriteLine($"Result: \n{apiFetch.result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}