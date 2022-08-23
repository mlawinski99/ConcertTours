using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Models;

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

        public IQueryable<Band> GetBands(int managerId,
            int id)
        {
            return  _dbContext.Bands
              .Where(m => m.BandId == id)
              .Where(m => managerId == managerId)
              .AsNoTracking();
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
