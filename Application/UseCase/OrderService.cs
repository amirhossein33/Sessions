using Application.Interfaces;
using Domain.Entity.Domain.Entities;

namespace Application.UseCase
{
    /*
     * بهتر است که UnitodWork رو لاغر نگه داریم یا  
    order Service را کوچک تر؟
     */
  
        public class OrderService
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IOrderRepository _orderRepository;
            private readonly IUserRepository _userRepository;
            private readonly IProductRepository _productRepository;

            public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository)
            {
                _unitOfWork = unitOfWork;
                _orderRepository = orderRepository;
                _userRepository = userRepository;
                _productRepository = productRepository;
            }

            private async Task<User> GetUserOrThrowAsync(int userId)
            {
                var user = await _userRepository.GetByIdAsync(userId);
                
                return user;
            }

            private async Task<List<Product>> GetProductsOrThrowAsync(Product product)
            {
                var productExists = await _productRepository.GetByIdAsync(product.Id);
                if (productExists == null)
                    throw new Exception("Product not found");
                return new List<Product> { productExists };
            }

            public async Task<Order> CreateOrderAsync(int userId, Product product)
            {
                var user = await GetUserOrThrowAsync(userId);
                var products = await GetProductsOrThrowAsync(product);

                var order = new Order
                {
                    UserId = userId,
                    Products = products,
                };

                await _orderRepository.AddAsync(order);
                await _unitOfWork.SaveChangesAsync();

                return order;
            }

            public async Task<List<Order>> GetAllOrdersAsync()
            {
                return await _orderRepository.GetAllAsync();
            }

            public async Task<Order?> GetOrderByIdAsync(int id)
            {
                return await _orderRepository.GetByIdAsync(id);
            }
        }
    }