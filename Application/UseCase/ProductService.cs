//using Application.Interfaces;
//using Domain.Entity.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.UseCase
//{
//    public class ProductService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IProductRepository _productRepository;

//        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _productRepository = productRepository;
//        }



//        public async Task<Product> CreateProductAsync(Product product)
//        {
         
//            var product = new Product
//            {
//                Name = product.Name,
//               Price = product.Price

//            };

//            await _productRepository.AddAsync(product);
//            await _unitOfWork.SaveChangesAsync();

//            return product;
//        }


//        public async Task<bool> DeleteProductAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task GetAllProductsAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<Product> GetUserByIdAsync(int id)
//        {
//            return await _productRepository.GetByIdAsync(id);
//        }

//        public async Task<bool> UpdateUserAsync(User user)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
