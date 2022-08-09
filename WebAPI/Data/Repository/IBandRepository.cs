using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IBandRepository
    {
        Task<IEnumerable<Band>> GetBands(int id);
        Task<Band> GetBandById(int managerId, int id);
        Task<Band> CreateBand(Band band);
        void DeleteBand(Band band); 
        Task<bool> IsBandExists(int bandId); 
        Task<bool> SaveChangesAsync();
    }
}
