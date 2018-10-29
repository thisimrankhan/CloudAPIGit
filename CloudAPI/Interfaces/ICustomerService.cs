using CloudAPI.Models.Entities;
using System.Threading.Tasks;

namespace CloudAPI.ApplicationCore.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(int id);
    }
}
