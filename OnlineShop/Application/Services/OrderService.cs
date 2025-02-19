//namespace OnlineShop.Application.Services
//{
//    using Core.Entities;
//    using Core.Interfaces;
//    using OnlineShop.Application.DTOs;
//    using OnlineShop.Application.Interfaces;

//    public class OrderService : IOrderService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public OrderService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(Guid customerId)
//        {
//            var orders = await _unitOfWork.Repository<Order>().FindAsync(o => o.CustomerId == customerId);
//            return orders.Select(o => new OrderDto(o.Id, o.CustomerId, o.TotalAmount));
//        }

//        public async Task<OrderDto> CreateOrderAsync(Guid customerId, decimal totalAmount)
//        {
//            var order = new Order { Id = Guid.NewGuid(), CustomerId = customerId, TotalAmount = totalAmount };
//            await _unitOfWork.Repository<Order>().AddAsync(order);
//            await _unitOfWork.SaveChangesAsync();
//            return new OrderDto(order.Id, order.CustomerId, order.TotalAmount);
//        }
//    }

//}
