namespace Infrastructure.Repository
{
    using Application.Interfaces;
    using Domain.Entity.Domain.Entities;
    using global::Infrastructure.Context;
    

    public class UserRepository(ApplicationDbContext context) : GenericRepository<User>(context), IUserRepository
    {
    }

}
