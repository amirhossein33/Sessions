using Domain.Entity.Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User newUser);
        Task<User> GetByIdAsync(int id);
    }

}
