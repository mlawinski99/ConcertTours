using AutoMapper;
using Models;
using WebAPI.DTOs;

namespace WebAPI.Profiles
{
    public class BandProfile : Profile
    {
        public BandProfile()
        {
            CreateMap<BandCreateUpdateDTO, Band>();
            CreateMap<Band, BandReadDTO>();
        }
    }
}
