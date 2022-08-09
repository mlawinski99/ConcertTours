using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetManagerList();
        Task<Manager> GetManagerById(int id);
        Task<bool> IsManagerExists(int id);
        Task<IEnumerable<Manager>> GetManagerConcerts(int id, DateTime? startTime, DateTime? endDateTime);
    }
}
