using OnlineShop.Core.Entities;
using System.Linq.Expressions;

namespace OnlineShop.Core.Interfaces
{

    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    }

}
