using WebAPI.Models;

namespace WebAPI.Data.Repository
{
    public interface IBandRepository
    {
        Task<Band> GetBandList();
        Task<Band> GetBandById(int id);
        Task<Band> CreateTask();
        Task<Band> UpdateTask();
        Task<Band> DeleteTask();
    }
}
