using CloudAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudAPI.ApplicationCore.Interfaces
{
    public interface IRecipieService
    {
        Task<List<Recipie>> GetRecipies();
        Task<Recipie> GetRecipieById(int Id);
    }
}
