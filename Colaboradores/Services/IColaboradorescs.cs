using Colaboradores.Models;

namespace Colaboradores.Services
{
    public interface IColaboradoresServices
    {
        Task<ResponseModel<List<ColaboradoresModel>>> ListarColaboradores();
    }
}
