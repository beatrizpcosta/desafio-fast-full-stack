using Microsoft.AspNetCore.Mvc;
using Workshops.Models;
using Workshops.Repositorios;
using Workshops.Repositórios.Interfaces;

namespace Workshops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaborador _colaboradorRepositorio;

        public ColaboradorController(IColaborador colaboradorRepositorio)
        {
            _colaboradorRepositorio = colaboradorRepositorio;
        }

        [HttpGet]

        //Listagem de Todos os Colaboradores
        public async Task<ActionResult<List<ColaboradorModel>>> BuscarColaboradores()
        {
            List<ColaboradorModel> colaboradores = await _colaboradorRepositorio.BuscarColaboradores();
            return Ok(colaboradores);
        }

        //Cadastrar Colaborador
        [HttpPost]
        public async Task<ActionResult<ColaboradorModel>> Cadastrar([FromBody] ColaboradorModel colaboradorModel)
        {
            ColaboradorModel colaboradorAdicionado = await _colaboradorRepositorio.Adicionar(colaboradorModel);

            return Ok(colaboradorAdicionado);
        }


        /*[HttpGet]

        //Listagem de Somente um Colaborador
        public async Task<ActionResult<ColaboradorModel>> BuscarPorId(int id)
        {
            ColaboradorModel colaboradores = await _colaboradorRepositorio.BuscarPorId(id);
            return Ok(colaboradores);
        }*/

        // Cadastro de Workshop




    }
}
