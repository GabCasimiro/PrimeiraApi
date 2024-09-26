using Colaboradores.Dto;
using Colaboradores.Models;
using Colaboradores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colaboradores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradoresServices _colab;
        public ColaboradoresController(IColaboradoresServices colab)
        {
            _colab = colab;
        }

        
        [HttpGet("Listar todos colaboradores")]
        public async Task<ActionResult<ResponseModel<List<ColaboradoresModel>>>> ListandoColab()
        {
            var colab = await _colab.ListarColaboradores();
            return Ok(colab);
        }

        [HttpGet("Buscar por ID/{id}")]
        public async Task<ActionResult<ResponseModel<ColaboradoresModel>>> BuuscarColaboradorID(int id)
        {
            var colab = await _colab.BuscarPorId(id);
            return Ok(colab);
        }

        [HttpPost("Atualizar colaboradores/{id}")]
        public async Task<ActionResult<ResponseModel<ColaboradoresModel>>> AtualizarColabs(ColaboradorDto colab, int id)
        {
            var colabs = await _colab.AtualizarColaboradorador(colab, id);
            return Ok(colabs);
        }


            
    }
}
