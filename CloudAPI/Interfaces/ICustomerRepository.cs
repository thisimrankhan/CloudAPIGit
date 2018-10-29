using CloudAPI.Models.Entities;
using System.Threading.Tasks;

namespace CloudAPI.ApplicationCore.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>, IAsyncRepository<Customer>
    {
        Customer GetByIdWithItems(int id);
        Task<Customer> GetByIdWithItemsAsync(int id);
    }
}
