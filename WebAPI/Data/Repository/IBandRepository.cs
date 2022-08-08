using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IBandRepository
    {
       // Task<Band> GetBandList();
        Task<Band> GetBandById(int managerId, int id);
        Task<Band> CreateBand(Band band);
       // Task<Band> UpdateBand();
       // Task<Band> DeleteBand();
       Task<bool> SaveChangesAsync();
    }
}
