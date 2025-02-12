namespace API_InfoManager.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using API_InfoManager.Models.DTOs;
    using API_InfoManager.Models.Entity;
    using API_InfoManager.Repository;
    using API_InfoManager.Models.DTOs.AlumnoDTO;
    using API_InfoManager.Repository.IRepository;
    using API_ProyectoAngular.Controllers;
    using global::AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : BaseController<AlumnoEntity, AlumnoDTO, CreateAlumnoDTO>
    {
        public AlumnoController(IAlumnoRepository alumnoRepository, IMapper mapper, ILogger<AlumnoController> logger)
            : base(alumnoRepository, mapper, logger)
        {
        }
    }
}
