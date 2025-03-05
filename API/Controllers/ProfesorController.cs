namespace DesignAPI.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using DesignAPI.Models.DTOs;
    using DesignAPI.Models.Entity;
    using DesignAPI.Repository;
    using DesignAPI.Models.DTOs.ProfesorDTO;
    using DesignAPI.Repository.IRepository;
    using DesignAPI.Controllers;
    using global::AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : BaseController<ProfesorEntity, ProfesorDTO, CreateProfesorDTO>
    {
        public ProfesorController(IProfesorRepository profesorRepository, IMapper mapper, ILogger<ProfesorController> logger)
            : base(profesorRepository, mapper, logger)
        {
        }
    }
}
