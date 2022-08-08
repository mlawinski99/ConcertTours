using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

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
