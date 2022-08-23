using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using WebAPI.Data;
namespace DataAccess.Repository
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

        public async Task<Manager> GetManagerById(int id)
        {
            return await _dbContext.Managers.
                Where(m => m.ManagerId == id).
                FirstOrDefaultAsync();
        }
        public async Task<bool> IsManagerExists(int id)
        {
            return await _dbContext.Managers.Where(m => m.ManagerId == id).AnyAsync();
        }

        public IQueryable<Manager> GetManagerConcerts(int id)
        {
            //concerts between the range of dates
           /* if (endDateTime != null && startTime != null)
                return await _dbContext.Managers
                    .Where(m => m.ManagerId == id)
                    .Include(b => b.Bands
                        .Where(p => p.ConcertTours.Count > 0))
                    .ThenInclude(t => t.ConcertTours
                        .Where(l => l.Concerts.Count > 0))
                    .ThenInclude(c => c.Concerts
                        .Where(z => z.ConcertStartDateTime.Date >= startTime.Value.Date)
                        .Where(v => v.ConcertStartDateTime.AddMinutes(v.DurationInMinutes).Date <= endDateTime.Value.Date))
                    .ToListAsync();

            //concerts for specific date
            if (startTime != null)
                return await _dbContext.Managers
                    .Where(m => m.ManagerId == id)
                    .Include(b => b.Bands
                        .Where(p => p.ConcertTours.Count > 0))
                    .ThenInclude(t => t.ConcertTours
                        .Where(l => l.Concerts.Count > 0))
                    .ThenInclude(c => c.Concerts
                        .Where(v => v.ConcertStartDateTime.Date == startTime.Value.Date))
                    .ToListAsync();
           */
            //all concerts
            return _dbContext.Managers
                .Where(m => m.ManagerId == id)
                .AsNoTracking();
            /*  .Include(b => b.Bands
                  .Where(p => p.ConcertTours.Count > 0))
              .ThenInclude(t => t.ConcertTours
                  .Where(l => l.Concerts.Count > 0))
              .ThenInclude(c => c.Concerts)
              .ToListAsync();*/
        }

    }
}
