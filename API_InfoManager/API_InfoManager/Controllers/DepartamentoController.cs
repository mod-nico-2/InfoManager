namespace API_InfoManager.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using API_InfoManager.Models.DTOs;
    using API_InfoManager.Models.Entity;
    using API_InfoManager.Repository;
    using API_InfoManager.Models.DTOs.DepartamentoDTO;
    using API_InfoManager.Repository.IRepository;
    using API_ProyectoAngular.Controllers;
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
