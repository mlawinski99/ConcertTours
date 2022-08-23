using AutoMapper;
using Models;
using WebAPI.DTOs;
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
