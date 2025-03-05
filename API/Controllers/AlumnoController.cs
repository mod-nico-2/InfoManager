namespace DesignAPI.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using DesignAPI.Models.DTOs;
    using DesignAPI.Models.Entity;
    using DesignAPI.Repository;
    using DesignAPI.Models.DTOs.AlumnoDTO;
    using DesignAPI.Repository.IRepository;
    using DesignAPI.Controllers;
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
