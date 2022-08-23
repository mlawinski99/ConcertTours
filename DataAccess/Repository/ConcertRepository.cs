using DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebAPI.Data.Repository
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ConcertRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Concert> GetConcertById(int concertTourId, int id)
        {
            return await _dbContext.Concerts
                .Where(m => m.ConcertId == id)
                .Where(m => m.ConcertTourId == concertTourId)
                .FirstOrDefaultAsync();
        }

        public async Task<Concert> CreateConcert(Concert concert)
        {
            await _dbContext.Concerts.AddAsync(concert);
            return concert;
        }

        public void DeleteConcert(Concert concert)
        {
            _dbContext.Concerts.Remove(concert);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }
    }
}
