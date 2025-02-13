using DesignAPI.Models.DTOs.UserDto;
using AutoMapper;
using DesignAPI.Models.DTOs;
using DesignAPI.Models.Entity;


namespace DesignAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {


            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
