namespace Application.UseCase
{
    using Domain.Entity.Domain.Entities;
    using global::Application.Interfaces;
    using System;

    namespace Application.UseCase
    {
        public class UserService
        {

            private readonly IUnitOfWork _unitOfWork;
            private readonly IUserRepository _userRepository;

            public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
            {
                _unitOfWork = unitOfWork;
                _userRepository = userRepository;
            }



            public async Task<User> CreateUserAsync(User user)
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user), "User cannot be null");

                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
              
                };

                await _userRepository.AddAsync(newUser);
                await _unitOfWork.SaveChangesAsync();

                return newUser;
            }


            public async Task<bool> DeleteUserAsync(int id)
            {
                throw new NotImplementedException();
            }

            public async Task GetAllUsersAsync()
            {
                throw new NotImplementedException();
            }

            public async Task<User?> GetUserByIdAsync(int id)
            {
                return await _userRepository.GetByIdAsync(id);
            }

            public async Task<bool> UpdateUserAsync(User user)
            {
                throw new NotImplementedException();
            }
        }

    }
}
