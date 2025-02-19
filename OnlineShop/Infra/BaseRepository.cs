namespace OnlineShop.Infra
{
    using global::OnlineShop.Core.Entities;
    using global::OnlineShop.Core.Interfaces;
    using global::OnlineShop.Infra.OnlineShop.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq.Expressions;

    namespace OnlineShop.Infrastructure.Repositories
    {
        public class BaseRepository<T> : IRepository<T> where T : BaseEntity
        {
            protected readonly AppDbContext _context;
            private readonly DbSet<T> _dbSet;

            public BaseRepository(AppDbContext context)
            {
                _context = context;
                _dbSet = context.Set<T>();
            }

            public async Task<T> GetByIdAsync(int id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task AddAsync(T entity)
            {
                await _dbSet.AddAsync(entity);
            }

            public void Update(T entity)
            {
                _dbSet.Update(entity);
            }

            public void Delete(T entity)
            {
                _dbSet.Remove(entity);
            }

            public Task<T?> GetByIdAsync(Guid id)
            {
                throw new NotImplementedException();
            }

            public Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
            {
                throw new NotImplementedException();
            }
        }
    }


}
