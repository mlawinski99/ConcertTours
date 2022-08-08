using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class ConcertTourProfile : Profile
    {
        public ConcertTourProfile()
        {
            CreateMap<ConcertTourCreateUpdateDTO, ConcertTour>();
            CreateMap<ConcertTour, ConcertTourReadDTO>();
        }
    }
}
