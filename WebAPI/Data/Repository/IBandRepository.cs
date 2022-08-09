using System.Collections;
using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IBandRepository
    {
        Task<Band> GetBandById(int managerId, int id);
        Task<IEnumerable<Band>> GetBandsInDateRange(int managerId, 
            int id, DateTime? beginngDateTime, DateTime? endingDateTime);
        Task<Band> CreateBand(Band band);
        void DeleteBand(Band band); 
        Task<bool> IsBandExists(int bandId); 
        Task<bool> SaveChangesAsync();
    }
}
