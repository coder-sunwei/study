
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapPost("/orders", (Order order) =>
{
    Console.WriteLine("Order received : " + order);
    return order.ToString();
});

app.Run();

public record Order(int orderId);