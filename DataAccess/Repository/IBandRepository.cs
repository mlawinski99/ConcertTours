using Models;

namespace DataAccess.Repository
{
    public interface IBandRepository
    {
        Task<Band> GetBandById(int managerId, int id);
        IQueryable<Band> GetBands(int managerId,
            int id);
        Task<Band> CreateBand(Band band);
        void DeleteBand(Band band);
        Task<bool> IsBandExists(int bandId);
        Task<bool> SaveChangesAsync();
    }
}
