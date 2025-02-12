namespace API_InfoManager.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using API_InfoManager.Models.DTOs;
    using API_InfoManager.Models.Entity;
    using API_InfoManager.Repository;
    using API_InfoManager.Models.DTOs.ProfesorDTO;
    using API_InfoManager.Repository.IRepository;
    using API_ProyectoAngular.Controllers;
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
