using Colaboradores.Dto;
using Colaboradores.Models;

namespace Colaboradores.Services
{
    public interface IColaboradoresServices
    {
        Task<ResponseModel<List<ColaboradoresModel>>> ListarColaboradores();
        Task<ResponseModel<ColaboradoresModel>> BuscarPorId(int id);
        Task<ResponseModel<ColaboradoresModel>> AtualizarColaboradorador(ColaboradorDto colab, int id);
        Task<ResponseModel<ColaboradoresModel>> AdicionarColaboradorPorId(ColaboradoresModel colab);
        Task<ResponseModel<ColaboradoresModel>> ApagarColaborador(int id);
    }
}
