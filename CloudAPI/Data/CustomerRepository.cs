using CloudAPI.ApplicationCore.Interfaces;
using CloudAPI.Data;
using CloudAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPI.Infrastructure.Data
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Customer GetByIdWithItems(int id)
        {
            return _dbContext.Customers
                //.Include(o => o.OrderItems)
                //.Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
                .FirstOrDefault();
        }

        public Task<Customer> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Customers
                //.Include(o => o.OrderItems)
                //.Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
                .FirstOrDefaultAsync();
        }
    }
}
