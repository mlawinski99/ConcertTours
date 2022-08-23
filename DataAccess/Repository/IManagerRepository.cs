

using Models;

namespace DataAccess.Repository
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetManagerList();
        Task<Manager> GetManagerById(int id);
        Task<bool> IsManagerExists(int id);
        IQueryable<Manager> GetManagerConcerts(int id);
    }
}
