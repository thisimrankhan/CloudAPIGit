using CloudAPI.Models.Entities;
using System.Threading.Tasks;

namespace CloudAPI.ApplicationCore.Interfaces
{
    public interface IRecipieRepository : IRepository<Recipie>, IAsyncRepository<Recipie>
    {
        Recipie GetByIdWithItems(int id);
        Task<Recipie> GetByIdWithItemsAsync(int id);
    }
}
