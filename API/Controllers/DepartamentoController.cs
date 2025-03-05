namespace DesignAPI.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using DesignAPI.Models.DTOs;
    using DesignAPI.Models.Entity;
    using DesignAPI.Repository;
    using DesignAPI.Models.DTOs.DepartamentoDTO;
    using DesignAPI.Repository.IRepository;
    using DesignAPI.Controllers;
    using global::AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : BaseController<DepartamentoEntity, DepartamentoDTO, CreateDepartamentoDTO>
    {
        public DepartamentoController(IDepartamentoRepository departamentoRepository, IMapper mapper, ILogger<DepartamentoController> logger)
            : base(departamentoRepository, mapper, logger)
        {
        }
    }
}
