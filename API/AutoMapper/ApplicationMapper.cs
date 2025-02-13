using API.Models.DTOs.UserDto;
using AutoMapper;
using API.Models.DTOs;
using API.Models.Entity;


namespace API.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {


            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
