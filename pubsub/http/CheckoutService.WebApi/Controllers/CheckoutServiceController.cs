using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutService.WebApi.Controllers
{
    [ApiController]
    public class CheckoutServiceController : Controller
    {
        [Topic("order-pub-sub", "orders")]
        [HttpPost("checkout")]
        public void GetCheckout([FromBody] int orderId)
        {
            Console.WriteLine("Subscriber receiver: " + orderId);
        }
    }
}
