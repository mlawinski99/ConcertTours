using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetManagerList();
        Task<Manager> GetManagerById(int id);
        Task<bool> SaveChangesAsync();
        Task<bool> IsManagerExists(int id);
    }
}
