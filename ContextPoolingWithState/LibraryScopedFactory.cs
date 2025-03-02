using Microsoft.EntityFrameworkCore;

namespace ContextPoolingWithState
{
    public class LibraryScopedFactory : IDbContextFactory<LibraryContext>
    {
        private const int DefaultTenantId = -1;

        private readonly IDbContextFactory<LibraryContext> _pooledFactory;
        private readonly int _tenantId;

        public LibraryScopedFactory(
            IDbContextFactory<LibraryContext> pooledFactory,
            ITenant tenant)
        {
            _pooledFactory = pooledFactory;
            _tenantId = tenant?.TenantId ?? DefaultTenantId;
        }

        public LibraryContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();
            context.TenantId = _tenantId;
            return context;
        }
    }
}






