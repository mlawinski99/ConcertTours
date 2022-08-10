﻿using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IConcertTourRepository
    {
        Task<IEnumerable<ConcertTour>> GetConcertToursForBand(int bandId, int id);
        Task<ConcertTour> GetConcertTourById(int bandId, int id);
        Task<ConcertTour> CreateConcertTour(ConcertTour concertTour);
        void DeleteConcertTour(ConcertTour concertTour);
        Task<bool> SaveChangesAsync();
        Task<bool> IsConcertTourExists(int concertTourId);
    }
}

