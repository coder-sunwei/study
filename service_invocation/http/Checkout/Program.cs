using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Dapr.Client;


var client = DaprClient.CreateInvokeHttpClient(appId: "order-processor");

for (int i = 1; i <= 10; i++)
{
    var order = new Order(i);

    var cts = new CancellationTokenSource();

    Console.CancelKeyPress += (object? sender, ConsoleCancelEventArgs e) => cts.Cancel();

    var response = await client.PostAsJsonAsync("/orders", order, cts.Token);

    Console.WriteLine($"Order passed:{order}, HttpStatus:{response.StatusCode}");

    await Task.Delay(TimeSpan.FromSeconds(5));

}

public record Order([property: JsonPropertyName("orderId")] int orderId);