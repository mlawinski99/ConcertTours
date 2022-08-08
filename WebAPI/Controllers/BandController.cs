using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Data.Repository;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/manager/{managerId}/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;

        public BandController(IManagerRepository managerRepository, IBandRepository bandRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _bandRepository = bandRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetBand")]
        public async Task<ActionResult<Band>> GetBandById(int managerId, int bandId)
        {
            var band = await _bandRepository.GetBandById(managerId, bandId);

            if (band == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BandReadDTO>(band));
        }
        [HttpPost]
        public async Task<ActionResult<BandCreateUpdateDTO>> CreateBand(int managerId, BandCreateUpdateDTO bandDto)
        {
            var manager = await _managerRepository.GetManagerById(managerId);
            if (manager == null)
                return NotFound();

            var band = _mapper.Map<Band>(bandDto);
            band.Manager = manager;
            await _bandRepository.CreateBand(band);
            await _bandRepository.SaveChangesAsync();

            var createdBand = _mapper.Map<BandReadDTO>(band);
            return CreatedAtRoute
            ("GetBand", new
                {
                    managerId = managerId,
                    bandId = createdBand.BandId
                }, createdBand);
        }
    }
}
