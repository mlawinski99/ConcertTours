﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<ConcertTour> GetConcertTourById(int id)
        {
            return await _dbContext.ConcertTours.Where(c => c.ConcertTourId == id).Include(c => c.Concerts).Include(c => c.Band).FirstOrDefaultAsync();
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
    }
}
