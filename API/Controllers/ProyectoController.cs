namespace API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using API.Models.DTOs;
    using API.Models.Entity;
    using API.Repository;
    using API.Models.DTOs.ProyectoDTO;
    using API.Repository.IRepository;
    using API.Controllers;
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
