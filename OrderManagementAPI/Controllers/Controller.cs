using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    namespace OrderManagementAPI.Controllers
    {
        [ApiController]
        [Route("api/orders")]
        public class OrderController : ControllerBase
        {
            [HttpPost("create")]
            public IActionResult CreateOrder([FromBody] string orderType)
            {
                OrderFactory factory;
                if (orderType == "physical")
                    factory = new PhysicalOrderFactory();
                else if (orderType == "digital")
                    factory = new DigitalOrderFactory();
                else
                    return BadRequest("Invalid order type!");

                IOrder order = factory.CreateOrder();
                order.ProcessOrder();

                return Ok("Order has been created.");
            }

            [HttpPost("pay")]
            public IActionResult ProcessPayment([FromBody] string paymentType)
            {
                IPaymentFactory factory;
                if (paymentType == "creditcard")
                    factory = new CreditCardPaymentFactory();
                else if (paymentType == "paypal")
                    factory = new PayPalPaymentFactory();
                else
                    return BadRequest("Invalid payment method!");

                IPayment payment = factory.CreatePayment();
                payment.ProcessPayment();

                return Ok("Payment has been processed.");
            }
        }
    }

}
