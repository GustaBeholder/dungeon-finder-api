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

        public ListResponse<MesaResponse> getMesas(MesaRequest request)
        {
            ListResponse<MesaResponse> response = new ListResponse<MesaResponse>();

            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")))
            {
               

                string query = @"SELECT m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres as QtdMaxJogadores, s.Nome as Sistema, j.Nome as Mestre
                        FROM Mesa m
                        INNER JOIN Sistema s on(s.idSistema = m.idSistema)
                        INNER JOIN Jogador j on(j.idJogador = m.idMestre)
                        where (m.IdMesa = @IdMesa or @IdMesa = 0)
                        group By m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres, s.Nome, j.Nome";

                try
                {
                    conexao.Open();
                    List<MesaResponse> itens = conexao.Query<MesaResponse>(query,param: new { request.IdMesa }, commandTimeout: 20).ToList();

                    if (itens != null && itens.Count > 0)
                    {
                        response.ErrorCode = 0;
                        response.Items = itens; 
                        
                    }
                    else
                    {
                        response.ErrorCode = 404;
                        response.Message = "Nenhuma Mesa encontrada";
                    }

                }
                catch (Exception ex)
                {
                    response.ErrorCode = 500;
                    response.Message = "Erro ao conectar ao banco de dados";
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
                
                string query = @"SELECT m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres as QtdMaxJogadores, s.Nome as Sistema, j.Nome as Mestre
                        FROM Mesa m
                        INNER JOIN Sistema s on(s.idSistema = m.idSistema)
                        INNER JOIN Jogador j on(j.idJogador = m.idMestre)
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

        public ListResponse<JogadorNaMesaResponse> getJogadoresNaMesa(int idMesa)
        {
            ListResponse<JogadorNaMesaResponse> response = new ListResponse<JogadorNaMesaResponse>();

            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")))
            {


                string query = @"Select j.idJogador, j.Nome, j.email from Jogador j
                                INNER JOIN jogadorNaMesa jm on (jm.IdJogador = j.IdJogador)
                                where jm.idMesa = @idMesa";

                try
                {
                    conexao.Open();
                    List<JogadorNaMesaResponse> itens = conexao.Query<JogadorNaMesaResponse>(query, param: new { idMesa }, commandTimeout: 20).ToList();

                    if (itens != null && itens.Count > 0)
                    {
                        response.ErrorCode = 0;
                        response.Items = itens;

                    }
                    else
                    {
                        response.ErrorCode = 404;
                        response.Message = "Nenhuma Jogador encontrado";
                    }

                }
                catch (Exception ex)
                {
                    response.ErrorCode = 500;
                    response.Message = "Erro ao conectar ao banco de dados";
                }
                finally
                {
                    conexao.Close();
                }
            }
            return response;
        }

        public BaseResponse createMesa(MesaCreateRequest request)
        {
            BaseResponse response = new BaseResponse();

            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")))
            {


                string query = @"insert into Mesa (nome, descricao, quantidadeMaxJogadres, idMestre, idSistema) 
                                values (@Nome, @descricao, @qtdMaxJogadores, @idMestre, @idSistema)";

                try
                {
                    conexao.Open();
                    int rows = conexao.Execute(query, param: new { 
                        request.Nome,
                        request.Descricao,
                        request.QtdMaxJogadores,
                        request.idMestre,
                        request.idSistema

                    }, commandTimeout: 20);

                    if (rows > 0)
                    {
                        response.ErrorCode = 201;
                        response.Message = "Mesa criada!";

                    }
                    else
                    {
                        response.ErrorCode = 400;
                        response.Message = "Erro ao criar Mesa";
                    }

                }
                catch (Exception ex)
                {
                    response.ErrorCode = 500;
                    response.Message = "Erro ao conectar ao banco de dados";
                }
                finally
                {
                    conexao.Close();
                }
            }
            return response;
        }
    }
}
