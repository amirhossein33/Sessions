namespace Infrastructure.Repository
{
    using Application.Interfaces;
    using Domain.Entity.Domain.Entities;
    using global::Infrastructure.Context;

    public class ProductRepository(ApplicationDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
    }



}
