using AutoMapper;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using WebAPI.Data;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/Manager/{managerId}/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;

        public BandController(IManagerRepository managerRepository,
            IBandRepository bandRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _bandRepository = bandRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetBand")]
        public async Task<ActionResult<BandReadDTO>> GetBand(int managerId,
            int bandId, DateTime? beginngDateTime, DateTime? endingDateTime)
        {
            var query =  _bandRepository.GetBands(managerId, bandId);
            var bands = new List<Band>();
            if (beginngDateTime != null && endingDateTime != null)
            {
               bands = await query.Include(t => t.ConcertTours)
                    .ThenInclude(c => c.Concerts
                        .Where(c => c.ConcertStartDateTime.Date >= beginngDateTime)
                        .Where(c => c.ConcertStartDateTime.AddMinutes(c.DurationInMinutes).Date <= endingDateTime))
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(_mapper.Map<IEnumerable<BandReadDTO>>(bands));
            }

            bands = await query.Include(t => t.ConcertTours)
                .ThenInclude(c => c.Concerts)
                .AsNoTracking()
                .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<BandReadDTO>>(bands));
        }

        [HttpPost]
        public async Task<ActionResult<BandReadDTO>> CreateBand(int managerId,
            BandCreateUpdateDTO bandDto)
        {
            if (!await _managerRepository.IsManagerExists(managerId))
                return NotFound();

            var band = _mapper.Map<Band>(bandDto);
            band.ManagerId = managerId;
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

        [HttpPut("{bandId}")]

        public async Task<ActionResult> UpdateBand(int managerId,
            int bandId, BandCreateUpdateDTO bandDto)
        {
            if (!await _managerRepository.IsManagerExists(managerId))
                return NotFound();

            var band = await _bandRepository.GetBandById(managerId, bandId);
            if (band == null)
                return NotFound();

            _mapper.Map(bandDto, band);
            await _bandRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{bandId}")]

        public async Task<ActionResult> DeleteBand(int managerId,
            int bandId)
        {
            if (!await _managerRepository.IsManagerExists(managerId))
                return NotFound();

            var band = await _bandRepository.GetBandById(managerId, bandId);
            if (band == null)
                return NotFound();

            _bandRepository.DeleteBand(band);
            await _bandRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
