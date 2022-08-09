using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public class ConcertTourRepository :IConcertTourRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ConcertTourRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ConcertTour>> GetConcertTours()
        {
            return await _dbContext.ConcertTours.ToListAsync();
        }

        public async Task<ConcertTour> GetConcertTourById(int bandId, int id)
        {
            return await _dbContext.ConcertTours.
                Where(c => c.ConcertTourId == id).
                Where(c => bandId == bandId).
                FirstOrDefaultAsync();
        }

        public async Task<ConcertTour> CreateConcertTour(ConcertTour concertTour)
        {
            await _dbContext.ConcertTours.AddAsync(concertTour);
            return concertTour;
        }

        public void DeleteConcertTour(ConcertTour concertTour)
        {
            _dbContext.ConcertTours.Remove(concertTour);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<bool> IsConcertTourExists(int concertTourId)
        {
            return await _dbContext.ConcertTours.Where(c => c.ConcertTourId == concertTourId).AnyAsync();
        }
    }
}
