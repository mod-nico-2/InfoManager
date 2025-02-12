using API_InfoManager.Models.DTOs.AlumnoDTO;
using API_InfoManager.Models.DTOs.DepartamentoDTO;
using API_InfoManager.Models.DTOs.ProfesorDTO;
using API_InfoManager.Models.DTOs.ProyectoDTO;
using API_InfoManager.Models.DTOs.ReunionDTO;
using API_InfoManager.Models.Entity;
using AutoMapper;

namespace API_InfoManager.AutoMapper
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
        }
    }
}
