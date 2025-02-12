namespace API_InfoManager.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using API_InfoManager.Models.DTOs;
    using API_InfoManager.Models.Entity;
    using API_InfoManager.Repository;
    using API_InfoManager.Models.DTOs.ProyectoDTO;
    using API_InfoManager.Repository.IRepository;
    using API_ProyectoAngular.Controllers;
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
