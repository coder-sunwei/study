using Dapr.Client;

string PUBSUB_NAME = "order-pub-sub";
string TOPIC_NAME = "orders";
while (true)
{
    Thread.Sleep(5000);

    int orderId = new Random().Next(1, 1000);

    CancellationTokenSource cts = new CancellationTokenSource();

    CancellationToken cancellationToken = cts.Token;

    using var client = new DaprClientBuilder().Build();

    await client.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, orderId, cancellationToken);

    Console.WriteLine("Published data: " + orderId);
}