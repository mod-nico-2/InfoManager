namespace DesignAPI.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using DesignAPI.Models.DTOs;
    using DesignAPI.Models.Entity;
    using DesignAPI.Repository;
    using DesignAPI.Models.DTOs.ReunionDTO;
    using DesignAPI.Repository.IRepository;
    using DesignAPI.Controllers;
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
