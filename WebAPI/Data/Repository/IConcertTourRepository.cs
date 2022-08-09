using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IConcertTourRepository
    {
        Task<IEnumerable<ConcertTour>> GetConcertTours();
        Task<ConcertTour> GetConcertTourById(int id);
        Task<ConcertTour> CreateConcertTour(ConcertTour concertTour);
        void DeleteConcertTour(ConcertTour concertTour);
        Task<bool> SaveChangesAsync();
    }
}

