using AutoMapper;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/Manager/{managerId}/Band/{bandId}/ConcertTour/{concertTourId}/[controller]")]
    [ApiController]
    public class ConcertController : ControllerBase
    {
        private readonly IConcertTourRepository _concertTourRepository;
        private readonly IConcertRepository _concertRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;
        public ConcertController(IConcertTourRepository concertTourRepository,
            IMapper mapper, IManagerRepository managerRepository,
            IBandRepository bandRepository, IConcertRepository concertRepository)
        {
            _concertTourRepository = concertTourRepository;
            _mapper = mapper;
            _managerRepository = managerRepository;
            _bandRepository = bandRepository;
            _concertRepository = concertRepository;
        }

        [HttpGet(Name = "GetConcert")]
        public async Task<ActionResult<ConcertReadDTO>> GetConcertById(int managerId,
            int bandId, int concertTourId, int concertId)
        {
            if (!await _managerRepository.IsManagerExists(managerId)
                || !await _bandRepository.IsBandExists(bandId)
                || !await _concertTourRepository.IsConcertTourExists(concertTourId))
                return NotFound();

            var concert = await _concertRepository.GetConcertById(concertTourId, concertId);

            if (concert == null)
                return NotFound();

            return Ok(_mapper.Map<ConcertReadDTO>(concert));
        }

        [HttpPost]
        public async Task<ActionResult<ConcertReadDTO>> CreateConcertTour(int managerId,
            int bandId, int concertTourId, ConcertCreateUpdateDTO concertDto)
        {
            if (!await _managerRepository.IsManagerExists(managerId)
                || !await _bandRepository.IsBandExists(bandId)
                || !await _concertTourRepository.IsConcertTourExists(concertTourId))
                return NotFound();

            var bandConcertTours = await _concertTourRepository.GetConcertToursForBand(bandId);
            foreach (var concertTour in bandConcertTours)
            {
                //if new concert data is lower then concert date in any concert tour
                foreach (var concertInTour in concertTour.Concerts) 
                    if (concertInTour.ConcertStartDateTime.Date >= concertDto.ConcertStartDateTime.Date) 
                        return BadRequest();
            }

            var concert = _mapper.Map<Concert>(concertDto);
            concert.ConcertTourId = concertTourId;
            await _concertRepository.CreateConcert(concert);
            await _concertRepository.SaveChangesAsync();

            var createdConcert = _mapper.Map<ConcertReadDTO>(concert);
            return CreatedAtRoute
            ("GetConcert", new
            {
                managerId = managerId,
                bandId = bandId,
                concertTourId = concertTourId,
                concertId = createdConcert.ConcertId
            }, createdConcert);
        }

        [HttpPut("{concertId}")]

        public async Task<ActionResult> UpdateConcertTour(int managerId,
            int bandId, int concertTourId, int concertId, ConcertCreateUpdateDTO concertTourDto)
        {
            if (!await _managerRepository.IsManagerExists(managerId)
                || !await _bandRepository.IsBandExists(bandId)
                || !await _concertTourRepository.IsConcertTourExists(concertTourId))
                return NotFound();

            var concert = await _concertRepository.GetConcertById(concertTourId, concertId);
            if (concert == null)
                return NotFound();

            _mapper.Map(concertTourDto, concert);
            await _concertRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{concertId}")]
        public async Task<ActionResult> DeleteConcertTour(int managerId,
            int bandId, int concertTourId, int concertId)
        {
            if (!await _managerRepository.IsManagerExists(managerId)
                || !await _bandRepository.IsBandExists(bandId)
                || !await _concertTourRepository.IsConcertTourExists(concertTourId))
                return NotFound();

            var concert = await _concertRepository.GetConcertById(concertTourId, concertId);
            if (concert == null)
                return NotFound();

            _concertRepository.DeleteConcert(concert);
            await _concertRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

