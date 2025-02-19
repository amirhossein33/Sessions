//namespace OnlineShop.Application.Services
//{
//    using Core.Entities;
//    using Core.Interfaces;
//    using OnlineShop.Application.DTOs;
//    using OnlineShop.Application.Interfaces;

//    public class CustomerService : ICustomerService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CustomerService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
//        {
//            var customers = await _unitOfWork.Repository<Customer>().GetAllAsync();
//            return customers.Select(c => new CustomerDto(c.Id, c.Name, c.Email));
//        }

//        public async Task<CustomerDto?> GetCustomerByIdAsync(Guid id)
//        {
//            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(id);
//            return customer is null ? null : new CustomerDto(customer.Id, customer.Name, customer.Email);
//        }

//        public async Task<CustomerDto> CreateCustomerAsync(string name, string email)
//        {
//            var customer = new Customer { Id = Guid.NewGuid(), Name = name, Email = email };
//            await _unitOfWork.Repository<Customer>().AddAsync(customer);
//            await _unitOfWork.SaveChangesAsync();
//            return new CustomerDto(customer.Id, customer.Name, customer.Email);
//        }
//    }

//}
