namespace Presentation.UI.Controllers
{
  
        using Application.UseCase;
        using Domain.Entity.Domain.Entities;
        using Microsoft.AspNetCore.Mvc;

        [ApiController]
        [Route("api/orders")]
        public class OrderController(OrderService orderService) : ControllerBase
        {
            private readonly OrderService _orderService = orderService;

        [HttpPost]
            public async Task<IActionResult> CreateOrder([FromBody] Order order)
            {
                var createdOrder = await _orderService.CreateOrderAsync(order.UserId, order.Products.FirstOrDefault()); 
                return Ok(createdOrder);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllOrders()
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return Ok(orders);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetOrderById(int id)
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null) return NotFound();
                return Ok(order);
            }
        }
    }
