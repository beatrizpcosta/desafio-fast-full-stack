using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshops.Models;
using Workshops.Repositorios;
using Workshops.Repositórios.Interfaces;

namespace Workshops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopController : ControllerBase

    {
        private readonly IWorkshop _workshopRepositorio;

            public WorkshopController(IWorkshop workshopRepositorio)
        {
            _workshopRepositorio = workshopRepositorio;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<WorkshopModel>>> BuscarWorkshops()
        {
            List<WorkshopModel> workshops = await _workshopRepositorio.BuscarWorkshops();

            return Ok(workshops);
        }


        [HttpPost]
        public async Task<ActionResult<WorkshopModel>> Cadastrar([FromBody] WorkshopModel workshopModel)
        {
            WorkshopModel workshopAdicionado = await _workshopRepositorio.Adicionar(workshopModel);

            return Ok(workshopAdicionado);
        }
    }
}