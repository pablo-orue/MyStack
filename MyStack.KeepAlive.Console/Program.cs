using System.Net.Http;

var url = "https://oruewebapi-b4fgardse4dufjg8.brazilsouth-01.azurewebsites.net/api/keepalive/ping"; 
var interval = TimeSpan.FromMinutes(10);
var apiKey = Environment.GetEnvironmentVariable("x-api-key");

Console.WriteLine($"Starting KeepAlive Agent. Pinging {url} every {interval.TotalMinutes} minutes.");

while (true)
{
    try
    {
        using var client = new HttpClient()
        {
            DefaultRequestHeaders = { { "x-api-key", apiKey } }
        };

        var response = await client.GetAsync(url);
        var ok = response.IsSuccessStatusCode;

        Console.WriteLine($"{DateTime.Now:u} - Ping {(ok ? "✔️ OK" : $"❌ FAIL")} - Status {response.StatusCode}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{DateTime.Now:u} - ❌ EXCEPTION: {ex.Message}");
    }

    await Task.Delay(interval);
}
