using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var baseUrl = (Environment.GetEnvironmentVariable("BASE_URL") ?? "http://localhost") + ":" + (Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3500");

const string PUBSUBNAME = "orderpubsub";

const string TOPIC = "orders";

Console.WriteLine($"Publishing to baseURL: {baseUrl}, Pubsub Name:{PUBSUBNAME}, Topic:{TOPIC}");

var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

for (int i = 1; i <= 10; i++)
{
    var order = new Order(i);

    var orderJson = JsonSerializer.Serialize(order);

    var content = new StringContent(orderJson, Encoding.UTF8, "application/json");

    var response = await httpClient.PostAsync($"{baseUrl}/v1.0/publish/{PUBSUBNAME}/{TOPIC}", content);

    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine("HttpStatusCode:" + response.StatusCode);
        Console.WriteLine(response.Content.ToString());
        return;
    }

    Console.WriteLine("Published data:" + order);

    await Task.Delay(TimeSpan.FromSeconds(3));
}

public record Order([property: JsonPropertyName("orderId")] int OrderId);