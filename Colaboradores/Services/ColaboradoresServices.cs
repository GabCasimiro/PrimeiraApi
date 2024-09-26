
using Colaboradores.Data;
using Colaboradores.Dto;
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


        public async Task<ResponseModel<ColaboradoresModel>> AdicionarColaboradorPorId(ColaboradoresModel colab)
        {
            ResponseModel<ColaboradoresModel> resposta = new ResponseModel<ColaboradoresModel>();

            try
            {
                var colabs = await _context.ColaboradoresDataBase.AddAsync(colab);
                _context.SaveChanges();

                resposta.Dados = colab;
                return resposta;
                
                
               
            }
            catch (Exception e)
            {
                resposta.Menssagem = e.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<ColaboradoresModel>> ApagarColaborador(int id)
        {
            ResponseModel<ColaboradoresModel> resposta = new ResponseModel<ColaboradoresModel>();
            try
            {
                var colab = await _context.ColaboradoresDataBase.FirstOrDefaultAsync(x => x.Id == id);
                if (colab == null)
                {
                    resposta.Menssagem = $"Colaborador com ID: {id} não encontrado";
                    return resposta;
                }
                
                _context.Remove(colab);
                _context.SaveChanges();
                resposta.Dados = colab;
                return resposta;

            }
            catch(Exception e)
            {
                resposta.Menssagem = e.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<ColaboradoresModel>> AtualizarColaboradorador(ColaboradorDto colab, int id)
        {
            ResponseModel<ColaboradoresModel> resposta = new ResponseModel<ColaboradoresModel>();

            try
            {
                var colabs = await _context.ColaboradoresDataBase.FirstOrDefaultAsync(c => c.Id == id);
                if (colabs == null)
                {
                    resposta.Menssagem = $"Colaborador com o ID: {id}, não encontrado";
                    return resposta;
                }
                colabs.NomeCompleto = colab.NomeCompleto;
                colabs.Categoria = colab.Categoria;

                resposta.Dados = colabs;
                resposta.Menssagem = "Atualização concluida";

                _context.Update(colabs);
                _context.SaveChanges();
                
                return resposta;

            }
            catch (Exception e)
            {
                resposta.Menssagem = e.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<ColaboradoresModel>> BuscarPorId(int id)
        {
            ResponseModel<ColaboradoresModel> resposta = new ResponseModel<ColaboradoresModel>();
            try
            {
                var colab = await _context.ColaboradoresDataBase.FirstOrDefaultAsync(c => c.Id == id);
                if (colab == null)
                {
                    resposta.Menssagem = $"Colaborador com ID: {id}, não encontrado";
                    return resposta;
                }

                resposta.Dados = colab;
                resposta.Menssagem = $"ID: {id}, encontrado com sucesso!";
                return resposta;
            
            }
            catch (Exception e)
            {
                resposta.Menssagem = e.Message;
                return resposta;
            }
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
