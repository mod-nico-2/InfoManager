namespace DesignAPI.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using DesignAPI.Models.DTOs;
    using DesignAPI.Models.Entity;
    using DesignAPI.Repository;
    using DesignAPI.Models.DTOs.ProyectoDTO;
    using DesignAPI.Repository.IRepository;
    using DesignAPI.Controllers;
    using global::AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : BaseController<ProyectoEntity, ProyectoDTO, CreateProyectoDTO>
    {
        public ProyectoController(IProyectoRepository proyectoRepository, IMapper mapper, ILogger<ProyectoController> logger)
            : base(proyectoRepository, mapper, logger)
        {
        }
    }
}
