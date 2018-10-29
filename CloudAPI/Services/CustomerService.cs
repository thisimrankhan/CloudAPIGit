using CloudAPI.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using CloudAPI.Models.Entities;

namespace CloudAPI.ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IAsyncRepository<Recipie> _recipieRepository;

        public CustomerService(IAsyncRepository<Customer> customerRepository, IAsyncRepository<Recipie> recipieRepository)
        {
            _customerRepository = customerRepository;
            _recipieRepository = recipieRepository;
        }

        public async Task<Customer> CreateCustomerAsync(int id)
        {
            var customer = new Customer();
            //await _customerRepository.AddAsync(customer);
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<Recipie> GetRecipieAsync(int id)
        {
            return await _recipieRepository.GetByIdAsync(id);
        }
    }
}
