using AutoMapper;
using Models;
using WebAPI.DTOs;

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
