using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public class BandRepository : IBandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Band> GetBandById(int managerId, int id)
        {
            return await _dbContext.Bands
                .Where(b => b.BandId == id)
                .Where(b => b.ManagerId == managerId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Band>> GetBandsInDateRange(int managerId,
            int id, DateTime? beginngDateTime, DateTime? endingDateTime)
        {
            if(beginngDateTime != null && endingDateTime != null)
            return await _dbContext.Bands
                .Where(m => m.BandId == id)
                .Where(m => managerId == managerId)
                .Include(t => t.ConcertTours)
                .ThenInclude(c => c.Concerts
                    .Where(c => c.ConcertStartDateTime.Date >= beginngDateTime)
                    .Where(c => c.ConcertStartDateTime.AddMinutes(c.DurationInMinutes).Date <= endingDateTime))
                .ToListAsync();

            return await _dbContext.Bands
                .Where(m => m.BandId == id)
                .Where(m => managerId == managerId)
                .Include(t => t.ConcertTours)
                .ThenInclude(c => c.Concerts)
                .ToListAsync();
        }

        public async Task<Band> CreateBand(Band band)
        {
            await _dbContext.Bands.AddAsync(band);
            return band;
        }

        public void DeleteBand(Band band)
        {
            _dbContext.Bands.Remove(band);
        }

        public async Task<bool> IsBandExists(int bandId)
        {
            return await _dbContext.Bands.Where(b => b.BandId == bandId).AnyAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }
    }
}
