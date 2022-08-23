using AutoMapper;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using WebAPI.DTOs;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;
        public ManagerController(IManagerRepository managerRepository,
            IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        [HttpGet]
          public async Task<ActionResult<IEnumerable<ManagerReadDTO>>> GetManagers()
          {
              var managerList = await _managerRepository.GetManagerList();
              
              return Ok(_mapper.Map<IEnumerable<ManagerReadDTO>>(managerList));
          }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ManagerReadDTO>>> GetManagersConcertsByDate(int id, DateTime? beginningDateTime, DateTime? endingDateTime)
          {
              var query = _managerRepository.GetManagerConcerts(id);
              var managers = new List<Manager>();
              if (beginningDateTime != null && endingDateTime != null)
              {
                  managers = await query
                      .Where(m => m.ManagerId == id)
                      .Include(b => b.Bands
                          .Where(p => p.ConcertTours.Count > 0))
                      .ThenInclude(t => t.ConcertTours
                          .Where(l => l.Concerts.Count > 0))
                      .ThenInclude(c => c.Concerts
                          .Where(z => z.ConcertStartDateTime.Date >= beginningDateTime.Value.Date)
                          .Where(v => v.ConcertStartDateTime.AddMinutes(v.DurationInMinutes).Date <=
                                      endingDateTime.Value.Date))
                      .AsNoTracking()
                      .ToListAsync();
              }
              else if (beginningDateTime != null)
              {
                  managers = await query
                      .Where(m => m.ManagerId == id)
                      .Include(b => b.Bands
                          .Where(p => p.ConcertTours.Count > 0))
                      .ThenInclude(t => t.ConcertTours
                          .Where(l => l.Concerts.Count > 0))
                      .ThenInclude(c => c.Concerts
                          .Where(v => v.ConcertStartDateTime.Date == beginningDateTime.Value.Date))
                      .AsNoTracking()
                      .ToListAsync();
              }
              else
              {
                managers = await query
                    .Where(m => m.ManagerId == id)
                    .Include(b => b.Bands
                        .Where(p => p.ConcertTours.Count > 0))
                    .ThenInclude(t => t.ConcertTours
                        .Where(l => l.Concerts.Count > 0))
                    .ThenInclude(c => c.Concerts
                        .Where(v => v.ConcertStartDateTime.Date == beginningDateTime.Value.Date))
                    .AsNoTracking()
                    .ToListAsync();
            }
              if (!managers.Any())
                  return NotFound();

              return Ok(_mapper.Map <IEnumerable<ManagerReadDTO>>(managers));
          }
    }
}