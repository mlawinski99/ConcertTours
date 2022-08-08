using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<ManagerCreateUpdateDTO, Manager>();
            CreateMap<Manager, ManagerReadDTO>();
        }
    }
}
