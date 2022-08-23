using AutoMapper;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/Manager/{managerId}/Band/{bandId}/[controller]")]
    [ApiController]
    public class ConcertTourController : ControllerBase
    {
        private readonly IConcertTourRepository _concertTourRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;
        public ConcertTourController(IConcertTourRepository concertTourRepository,
            IMapper mapper, IManagerRepository managerRepository,
            IBandRepository bandRepository)
        {
            _concertTourRepository = concertTourRepository;
            _mapper = mapper;
            _managerRepository = managerRepository;
            _bandRepository = bandRepository;
        }

        [HttpGet(Name="GetConcertTour")]
        public async Task<ActionResult<ConcertTourReadDTO>> GetConcertTourById(int managerId,
            int bandId, int concertTourId)
        {
            if (!await _managerRepository.IsManagerExists(managerId)
                || !await _bandRepository.IsBandExists(bandId))
                return NotFound();

            var concertTour = await _concertTourRepository.GetConcertTourById(bandId, concertTourId);

            if (concertTour == null)
                return NotFound();

            return Ok(_mapper.Map<ConcertTourReadDTO>(concertTour));
        }

        [HttpPost]
        public async Task<ActionResult<ConcertTourReadDTO>> CreateConcertTour(int managerId,
            int bandId, ConcertTourCreateUpdateDTO concertTourDto)
        {
            if (!await _managerRepository.IsManagerExists(managerId)
                || !await _bandRepository.IsBandExists(bandId))
                return NotFound();

            var concertTour = _mapper.Map<ConcertTour>(concertTourDto);
            concertTour.BandId = bandId;
            await _concertTourRepository.CreateConcertTour(concertTour);
            await _concertTourRepository.SaveChangesAsync();

            var createdConcertTour = _mapper.Map<ConcertTourReadDTO>(concertTour);
            return CreatedAtRoute
            ("GetConcertTour", new
            {
                managerId = managerId,
                bandId = bandId,
                concertTourId = createdConcertTour.ConcertTourId
            }, createdConcertTour);
        }

        [HttpPut("{concertTourId}")]

        public async Task<ActionResult> UpdateConcertTour(int managerId,
            int bandId,int concertTourId, ConcertTourCreateUpdateDTO concertTourDto)
        {
            if (!await _managerRepository.IsManagerExists(managerId) 
                || !await _bandRepository.IsBandExists(bandId))
                return NotFound();

            var concertTour = await _concertTourRepository.GetConcertTourById(bandId, concertTourId);
            if (concertTour == null)
                return NotFound();

            _mapper.Map(concertTourDto, concertTour);
            await _concertTourRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{concertTourId}")]

        public async Task<ActionResult> DeleteConcertTour(int managerId,
            int bandId, int concertTourId)
        {
            if (!await _managerRepository.IsManagerExists(managerId) 
                || !await _bandRepository.IsBandExists(bandId))
                return NotFound();

            var concertTour = await _concertTourRepository.GetConcertTourById(bandId, concertTourId);
            if (concertTour == null)
                return NotFound();

            _concertTourRepository.DeleteConcertTour(concertTour);
            await _concertTourRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
