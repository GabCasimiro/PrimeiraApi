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

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<ColaboradoresModel>>>> ListandoColab()
        {
            var colab = await _colab.ListarColaboradores();
            return Ok(colab);
            
        }
    }
}
