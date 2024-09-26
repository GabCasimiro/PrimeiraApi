
using Colaboradores.Data;
using Colaboradores.Models;
using Microsoft.EntityFrameworkCore;

namespace Colaboradores.Services
{
    public class ColaboradoresServices : IColaboradoresServices
    {
        private readonly ConnectDbContext _context;
        public ColaboradoresServices(ConnectDbContext connect)
        {
            _context = connect;
        }

        public async Task<ResponseModel<List<ColaboradoresModel>>> ListarColaboradores()
        {
            ResponseModel<List<ColaboradoresModel>> resposta = new ResponseModel<List<ColaboradoresModel>>();

            try
            {
                var colab = await _context.ColaboradoresDataBase.ToListAsync();
                resposta.Dados = colab;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Menssagem = ex.Message;
                return resposta;
                
            }
            
        }
    
    }
}
