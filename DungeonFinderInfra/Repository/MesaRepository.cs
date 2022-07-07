using Dapper;
using Microsoft.Data.SqlClient;
using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Model.Response;
using DungeonFinderDomain.Model.Requests;
using Microsoft.Extensions.Configuration;
using DungeonFinderInfra.DbConnect;

namespace DungeonFinderInfra.Repository
{
    public class MesaRepository : BaseRepository, IMesaRepository
    {
        public MesaRepository(DbSession session) : base(session)
        {
        }

        public ListResponse<MesaResponse> getMesas(MesaRequest request)
        {
            ListResponse<MesaResponse> response = new ListResponse<MesaResponse>();


            string query = @"SELECT m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres as QtdMaxJogadores, s.Nome as Sistema, j.Nome as Mestre
                        FROM Mesa m
                        INNER JOIN Sistema s on(s.idSistema = m.idSistema)
                        INNER JOIN Jogador j on(j.idJogador = m.idMestre)
                        where (m.IdMesa = @IdMesa or @IdMesa = 0)
                        group By m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres, s.Nome, j.Nome";

            try
            {
                if (_session.OpenConnection())
                {
                    List<MesaResponse> itens = _session._connection.Query<MesaResponse>(query, param: new { request.IdMesa }, commandTimeout: 20).ToList();

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
            }
            catch (Exception ex)
            {
                response.ErrorCode = 500;
                response.Message = "Erro ao conectar ao banco de dados";
            }
            finally
            {
                _session.CloseConnection();
            }
            return response;
        }



        public GenericResponse<MesaResponse> getMesaDetails(int idMesa)
        {
            GenericResponse<MesaResponse> response = new GenericResponse<MesaResponse>();

            string query = @"SELECT m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres as QtdMaxJogadores, s.Nome as Sistema, j.Nome as Mestre
                        FROM Mesa m
                        INNER JOIN Sistema s on(s.idSistema = m.idSistema)
                        INNER JOIN Jogador j on(j.idJogador = m.idMestre)
                        where m.IdMesa = @mesaId";

            try
            {
                if (_session.OpenConnection())
                {
                    response.Response = _session._connection.QueryFirstOrDefault<MesaResponse>(
                               query, param: new { mesaId = idMesa }, commandTimeout: 20);

                    if (response.Response == null)
                    {
                        response.BaseResponse.ErrorCode = 404;
                        response.BaseResponse.Message = "Nenhuma Mesa encontrada";
                    }
                    else
                    {
                        response.BaseResponse.ErrorCode = 0;
                        response.BaseResponse.Message = "Sucesso";
                    }
                }
            }
            catch (Exception ex)
            {
                response.BaseResponse.ErrorCode = 404;
                response.BaseResponse.Message = "Nenhuma Mesa encontrada";
            }
            finally
            {
                _session.CloseConnection();
            }
            return response;
        }

        public ListResponse<JogadorNaMesaResponse> getJogadoresNaMesa(int idMesa)
        {
            ListResponse<JogadorNaMesaResponse> response = new ListResponse<JogadorNaMesaResponse>();

            string query = @"Select j.idJogador, j.Nome, j.email from Jogador j
                                INNER JOIN jogadorNaMesa jm on (jm.IdJogador = j.IdJogador)
                                where jm.idMesa = @idMesa";

            try
            {
                if (_session.OpenConnection())
                {
                    List<JogadorNaMesaResponse> itens = _session._connection.Query<JogadorNaMesaResponse>(query, param: new { idMesa }, commandTimeout: 20).ToList();

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
            }
            catch (Exception ex)
            {
                response.ErrorCode = 500;
                response.Message = "Erro ao conectar ao banco de dados";
            }
            finally
            {
                _session.CloseConnection();
            }
            return response;
        }

        public BaseResponse createMesa(MesaCreateRequest request)
        {
            BaseResponse response = new BaseResponse();

            string query = @"insert into Mesa (nome, descricao, quantidadeMaxJogadres, idMestre, idSistema) 
                                values (@Nome, @descricao, @qtdMaxJogadores, @idMestre, @idSistema)";

            try
            {
                if (_session.OpenConnection())
                {
                    int rows = _session._connection.Execute(query, param: new
                    {
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
            }
            catch (Exception ex)
            {
                response.ErrorCode = 500;
                response.Message = "Erro ao conectar ao banco de dados";
            }
            finally
            {
                _session.CloseConnection();
            }
            return response;
        }
    }
}
