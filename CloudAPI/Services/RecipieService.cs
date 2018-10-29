using CloudAPI.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using CloudAPI.Models.Entities;

namespace CloudAPI.ApplicationCore.Services
{
    public class RecipieService : IRecipieService
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IAsyncRepository<Recipie> _recipieRepository;

        public RecipieService(IAsyncRepository<Customer> customerRepository, IAsyncRepository<Recipie> recipieRepository)
        {
            _customerRepository = customerRepository;
            _recipieRepository = recipieRepository;
        }

        public async Task<List<Recipie>> GetRecipies()
        {
            return await _recipieRepository.ListAllAsync();
        }

        public async Task<Recipie> GetRecipieById(int Id)
        {
            return await _recipieRepository.GetByIdAsync(Id);
        }
    }
}
