using OnlineShop.Application.DTOs;
using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        Task<OrderDto> GetOrderByIdAsync(Guid id);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    }


namespace OnlineShop.Application.Services
    {
        public class OrderService ///: IOrderService
        {
            private readonly IUnitOfWork _unitOfWork;

            public OrderService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            //public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
            //{
            //    var order = new Order
            //    {
            //        Id = Guid.NewGuid(),
            //     //   CustomerName = orderDto.CustomerName,
            //        TotalAmount = orderDto.TotalAmount,
            //        OrderDate = DateTime.UtcNow
            //    };

            // //   _unitOfWork.Repository<Order>().Add(order);
            //    await _unitOfWork.SaveChangesAsync();

            //    // تبدیل Entity به DTO به صورت دستی
            //    return new OrderDto
            //    {
            //        Id = order.Id,
            //        CustomerName = order.CustomerName,
            //        TotalAmount = order.TotalAmount,
            //        OrderDate = order.OrderDate
            //    };
            //}

            //public async Task<OrderDto> GetOrderByIdAsync(Guid id)
            //{
            //    var order = await _unitOfWork.Repository<Order>().GetByIdAsync(id);

            //    if (order == null) return null;

            //    // تبدیل Entity به DTO به صورت دستی
            //    return new OrderDto
            //    {
            //        Id = order.Id,
            //        CustomerName = order.CustomerName,
            //        TotalAmount = order.TotalAmount,
            //        OrderDate = order.OrderDate
            //    };
            //}

            //public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
            //{
            //    var orders = await _unitOfWork.Repository<Order>().GetAllAsync();

            //    // تبدیل Entity به DTO به صورت دستی
            //    var orderDtos = orders.Select(order => new OrderDto
            //    {
            //        Id = order.Id,
            //        CustomerName = order.CustomerName,
            //        TotalAmount = order.TotalAmount,
            //        OrderDate = order.OrderDate
            //    });

            //    return orderDtos;
            //}
        }
    }

}
