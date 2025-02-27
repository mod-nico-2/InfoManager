using DesignAPI.Models.DTOs.UserDto;
using AutoMapper;
using DesignAPI.Models.DTOs;
using DesignAPI.Models.Entity;
using DesignAPI.Models.DTOs.AlumnoDTO;
using DesignAPI.Models.DTOs.DepartamentoDTO;
using DesignAPI.Models.DTOs.ProfesorDTO;
using DesignAPI.Models.DTOs.ProyectoDTO;
using DesignAPI.Models.DTOs.ReunionDTO;


namespace DesignAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {

            CreateMap<AlumnoEntity, AlumnoDTO>().ReverseMap();
            CreateMap<AlumnoEntity, CreateAlumnoDTO>().ReverseMap();

            CreateMap<DepartamentoEntity, DepartamentoDTO>().ReverseMap();
            CreateMap<DepartamentoEntity, CreateDepartamentoDTO>().ReverseMap();

            CreateMap<ProfesorEntity, ProfesorDTO>().ReverseMap();
            CreateMap<ProfesorEntity, CreateProfesorDTO>().ReverseMap();

            CreateMap<ProyectoEntity, ProyectoDTO>().ReverseMap();
            CreateMap<ProyectoEntity, CreateProyectoDTO>().ReverseMap();

            CreateMap<ReunionEntity, ReunionDTO>().ReverseMap();
            CreateMap<ReunionEntity, CreateReunionDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
