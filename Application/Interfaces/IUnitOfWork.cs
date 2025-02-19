using Domain.Entity.Domain.Entities;

namespace Application.Interfaces
{
    public interface IUnitOfWork 
    {
        Task SaveChangesAsync();
    }

}
