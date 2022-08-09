using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IConcertRepository
    {
        Task<Concert> GetConcertById(int id);
        Task<Concert> CreateConcert(Concert concert);
        void DeleteConcertTour(Concert concert);
        Task<bool> SaveChangesAsync();
        Task<bool> IsConcertExists(int concertId);
    }
}
