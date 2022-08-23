using AutoMapper;
using Models;
using WebAPI.DTOs;

namespace WebAPI.Profiles
{
    public class ConcertProfile : Profile
    {
        public ConcertProfile()
        {
            CreateMap<ConcertCreateUpdateDTO, Concert>();
            CreateMap<Concert, ConcertReadDTO>();
        }
    }
}
