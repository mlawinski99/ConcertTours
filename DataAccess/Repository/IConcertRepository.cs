using Models;

namespace DataAccess.Repository
{
    public interface IConcertRepository
    {
        Task<Concert> GetConcertById(int concertToudId, int id);
        Task<Concert> CreateConcert(Concert concert);
        void DeleteConcert(Concert concert);
        Task<bool> SaveChangesAsync();
    }
}
