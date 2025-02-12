namespace API_InfoManager.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using API_InfoManager.Models.DTOs;
    using API_InfoManager.Models.Entity;
    using API_InfoManager.Repository;
    using API_InfoManager.Models.DTOs.ReunionDTO;
    using API_InfoManager.Repository.IRepository;
    using API_ProyectoAngular.Controllers;
    using global::AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class ReunionController : BaseController<ReunionEntity, ReunionDTO, CreateReunionDTO>
    {
        public ReunionController(IReunionRepository reunionRepository, IMapper mapper, ILogger<ReunionController> logger)
            : base(reunionRepository, mapper, logger)
        {
        }
    }
}
