using Domain.Entity.Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderRepository 
    {
        Task<Order> GetByIdAsync(int id);
        Task<List<Order>> GetAllAsync();
        Task AddAsync(Order order);
        
    }
}
