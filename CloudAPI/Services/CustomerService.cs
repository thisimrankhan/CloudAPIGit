using CloudAPI.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using CloudAPI.Models.Entities;

namespace CloudAPI.ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        
        public CustomerService(IAsyncRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomerAsync(int id)
        {
            var customer = new Customer();
            return await _customerRepository.GetByIdAsync(id);
        }
        
    }
}
