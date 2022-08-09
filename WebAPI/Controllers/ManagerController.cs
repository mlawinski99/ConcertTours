using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Repository;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;
        public ManagerController(IManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        [HttpGet]
          public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
          {
              var managerList = await _managerRepository.GetManagerList();
              
              return Ok(_mapper.Map<IEnumerable<ManagerReadDTO>>(managerList));
          }

          [HttpGet ("{id}")]
          public async Task<ActionResult<Manager>> GetManagerById(int id)
          {
              var manager = await _managerRepository.GetManagerById(id);

              if (manager == null)
                  return NotFound();

              return Ok(_mapper.Map<ManagerReadDTO>(manager));
          }
    }
}