using CloudAPI.ApplicationCore.Interfaces;
using CloudAPI.Data;
using CloudAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPI.Infrastructure.Data
{
    public class RecipieRepository : EfRepository<Recipie>, IRecipieRepository
    {
        public RecipieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Recipie GetByIdWithItems(int id)
        {
            return _dbContext.Recipies
                //.Include(o => o.OrderItems)
                //.Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
                .FirstOrDefault();
        }

        public Task<Recipie> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Recipies
                //.Include(o => o.OrderItems)
                //.Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
                .FirstOrDefaultAsync();
        }
    }
}
