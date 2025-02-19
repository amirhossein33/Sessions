using Domain.Entity.Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductRepository 
    {
        Task<Product> GetByIdAsync(int id);
    }

}
