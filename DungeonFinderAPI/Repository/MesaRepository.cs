using DungeonFinderAPI.Interface;
using DungeonFinderAPI.Model.Response;
using Dapper;
using Microsoft.Data.SqlClient;
using DungeonFinderAPI.Model.Requests;

namespace DungeonFinderAPI.Repository
{
    public class MesaRepository : IMesaRepository
    {
        private IConfiguration _config;

        public MesaRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IEnumerable<MesaResponse> getMesas(MesaRequest request)
        {
            IEnumerable<MesaResponse> response = new List<MesaResponse>();

            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")))
            {
               

                string query = @"SELECT m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres as QtdMaxJogadores,  count(jm.IdJogador) as QtdJogadores, s.Nome as Sistema, j.Nome as Mestre
                        FROM Mesa m
                        INNER JOIN Sistema s on(s.idSistema = m.idSistema)
                        INNER JOIN Jogador j on(j.idJogador = m.idMestre)
                        INNER JOIN JogadorNaMesa jm on (jm.idMesa = m.idMesa)
                        where (m.IdMesa = @IdMesa or @IdMesa = 0)
                        group By m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres, s.Nome, j.Nome";

                try
                {
                    conexao.Open();
                    response = conexao.Query<MesaResponse>(query,param: new { request.IdMesa }, commandTimeout: 20).ToList();

                    if (response == null)
                    {
                        var response2 = new MesaResponse();
                        response2.ErrorCode = 404;
                        response2.Message = "Nenhuma Mesa encontrada";
                    }
                    else
                    {
                        
                    }

                }
                catch (Exception ex)
                {
                    var response2 = new MesaResponse();
                    response2.ErrorCode = 404;
                    response2.Message = "Nenhuma Mesa encontrada";
                }
                finally
                {
                    conexao.Close();
                }
            }
            return response;
        }

        public MesaResponse getMesaDetails(int idMesa)
        {
            MesaResponse response = new MesaResponse();
            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")))
            {
                
                string query = @"SELECT m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres as QtdMaxJogadores,  count(IdJogador) as QtdJogadores
                        where IdMesa = @mesaId) as QtdJogadores, s.Nome as Sistema, j.Nome as Mestre
                        FROM Mesa m
                        INNER JOIN Sistema s on(s.idSistema = m.idSistema)
                        INNER JOIN Jogador j on(j.idJogador = m.idMestre)
                        INNER JOIN JogadorNaMesa jm on(jm.idmesa = m.idmesa)
                        where m.IdMesa = @mesaId";

                try
                {
                    conexao.Open();
                    response = conexao.QueryFirstOrDefault<MesaResponse>(
                               query, param: new { mesaId = idMesa }, commandTimeout: 20);

                    if(response == null)
                    {
                        response = new MesaResponse();
                        response.ErrorCode = 404;
                        response.Message = "Nenhuma Mesa encontrada";
                    }
                    else
                    {
                        response.ErrorCode = 0;
                        response.Message = "Sucesso";
                    }

                }
                catch (Exception ex)
                {
                    response.ErrorCode = 404;
                    response.Message = "Nenhuma Mesa encontrada";
                }
                finally
                {
                    conexao.Close();    
                }
                

                return response;
            }
        }

        public List<MesaResponse> getMesa(MesaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
