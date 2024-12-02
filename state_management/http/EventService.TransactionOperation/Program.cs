using Dapr.Client;
using System.Text.Json;

string DAPR_STORE_NAME = "statestore";

while (true)
{
    Thread.Sleep(5000);

    int orderId = new Random().Next(1, 1000);

    var client = new DaprClientBuilder().Build();

    var request = new List<StateTransactionRequest>()
    {
        new StateTransactionRequest("order_3",JsonSerializer.SerializeToUtf8Bytes(orderId.ToString()),StateOperationType.Upsert),
        new StateTransactionRequest("order_2",null,StateOperationType.Delete)
    };

    var cts = new CancellationTokenSource();

    await client.ExecuteStateTransactionAsync(DAPR_STORE_NAME, request, cancellationToken: cts.Token);

    Console.WriteLine("Order requestd" + orderId);

}