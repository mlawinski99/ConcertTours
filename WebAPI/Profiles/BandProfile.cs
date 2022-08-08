using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

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
