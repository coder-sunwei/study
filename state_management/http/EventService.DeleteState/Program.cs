using Dapr.Client;

string DAPR_STORE_NAME = "statestore";

var client = new DaprClientBuilder().Build();

var cts = new CancellationTokenSource();

Console.CancelKeyPress += (object? sender, ConsoleCancelEventArgs e) => cts.Cancel();

await client.DeleteStateAsync(DAPR_STORE_NAME, "order_1", cancellationToken: cts.Token);