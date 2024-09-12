namespace ConsoleAppForTesting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.tradingeconomics.com/calendar?c=e9f95eed6aa6465:blsksmd6c5y89rx"))
                {
                    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);
                    }
                }
            }
        }
    }
}
