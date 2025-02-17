using API.Models.DTOs.UserDto;
using AutoMapper;
using API.Models.DTOs;
using API.Models.Entity;
using API.Models.DTOs.ProyectoDTO;


namespace API.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {

            CreateMap<ProyectoEntity, ProyectoDTO>().ReverseMap();
            CreateMap<ProyectoEntity, CreateProyectoDTO>().ReverseMap();



            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
