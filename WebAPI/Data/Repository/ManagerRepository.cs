using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ManagerRepository(ApplicationDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<IEnumerable<Manager>> GetManagerList()
        {
            return await _dbContext.Managers.ToListAsync();
        }

        public async Task<Manager?> GetManagerById(int id)
        {
            return await _dbContext.Managers.Where(m => m.ManagerId == id).Include(m => m.Bands).FirstOrDefaultAsync();
        }
        public async Task<bool> IsManagerExists(int id)
        {
            return await _dbContext.Managers.Where(m => m.ManagerId == id).AnyAsync();
        }
    }
}
