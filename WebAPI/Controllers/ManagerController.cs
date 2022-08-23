using AutoMapper;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
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
              var manager = await _managerRepository.GetManagerConcerts(id, beginningDateTime, endingDateTime);

              if (manager.Count() == 0)
                  return NotFound();

              return Ok(_mapper.Map <IEnumerable<ManagerReadDTO>>(manager));
          }
    }
}