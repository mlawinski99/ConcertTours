

using Models;

namespace DataAccess.Repository
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetManagerList();
        Task<Manager> GetManagerById(int id);
        Task<bool> IsManagerExists(int id);
        Task<IEnumerable<Manager>> GetManagerConcerts(int id,
            DateTime? startTime, DateTime? endDateTime);
    }
}
