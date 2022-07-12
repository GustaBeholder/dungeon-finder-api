using Dapper;
using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Model.Response;
using DungeonFinderDomain.Model.Requests;
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


            string query = @"SELECT m.idMesa ,m.Nome, m.Descricao, count(1) over() as QtdJogadores, m.QuantidadeMaxJogadres as QtdMaxJogadores, s.Nome as Sistema, m.IdMestre,j.Nome as Mestre,
                            m.isAtivo
                            FROM Mesa m
                            INNER JOIN Sistema s on(s.idSistema = m.idSistema)
                            INNER JOIN Jogador j on(j.idJogador = m.idMestre)
                            where (@IdMesa = 0 or m.IdMesa = @IdMesa )
                            AND (@isAtivo < 0 or m.isAtivo = @isAtivo)
                            AND (@Sistema = 0 or m.idSistema = @Sistema)
                            group By m.idMesa ,m.Nome, m.Descricao, m.QuantidadeMaxJogadres, s.Nome, m.IdMestre ,j.Nome, m.isAtivo";

            try
            {
                if (_session.OpenConnection())
                {
                    List<MesaResponse> itens = _session._connection.Query<MesaResponse>(query,
                        param: new {
                            request.IdMesa,
                            request.isAtivo,
                            request.Sistema

                        }, commandTimeout: 20).ToList();

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

            string query = @"
                        SELECT m.idMesa ,m.Nome, m.Descricao, (SELECT COUNT(idJogador) FROM JogadorNaMesa
                        where idMesa = @mesaId) as QtdJogadores, m.QuantidadeMaxJogadres as QtdMaxJogadores, s.Nome as Sistema, m.IdMestre,j.Nome as Mestre, m.isAtivo
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

            string query = @"Select j.idJogador, j.Nome, u.email, j.idUsuario, jm.idMesa, jm.AdcionadoEm from Jogador j
                                INNER JOIN jogadorNaMesa jm on (jm.IdJogador = j.IdJogador)
                                INNER JOIN Usuario u on (u.idUsuario = j.idUsuario)
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

            string query = @"insert into Mesa (nome, descricao, quantidadeMaxJogadres, idMestre, idSistema, isAtivo) 
                                values (@Nome, @descricao, @qtdMaxJogadores, @idMestre, @idSistema, 1)";

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

        public BaseResponse insertJogadorNaMesa(JogadorNaMesaRequest request)
        {
            BaseResponse response = new BaseResponse();

            string query = @"insert into JogadorNaMesa (idJogador, idMesa, adcionadoEm) 
                                values (@idJogador, @idMesa, GETDATE())";
            try
            {
                if (_session.OpenConnection())
                {
                    int rows = _session._connection.Execute(query, param: new
                    {
                        request.idJogador,
                        request.idMesa

                    }, commandTimeout: 20);

                    if (rows > 0)
                    {
                        response.ErrorCode = 201;
                        response.Message = "Jogador Adcionado!";

                    }
                    else
                    {
                        response.ErrorCode = 400;
                        response.Message = "Erro ao Adcionar Jogador";
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

        public BaseResponse updateMesa(UpdateMesa request)
        {
            BaseResponse response = new BaseResponse();

            string query = @"UPDATE MESA SET Nome = @Nome, Descricao = @Descricao, 
                            QuantidadeMaxJogadres = @QtdMaxJogadores, isAtivo = @isAtivo
                             WHERE idMesa = @idMesa";
            try
            {
                if (_session.OpenConnection())
                {
                    int rows = _session._connection.Execute(query, param: new
                    {
                        request.Nome,
                        request.Descricao,
                        request.QtdMaxJogadores,
                        request.isAtivo, 
                        request.IdMesa

                    }, commandTimeout: 20);

                    if (rows > 0)
                    {
                        response.ErrorCode = 201;
                        response.Message = "Mesa Atualizada";

                    }
                    else
                    {
                        response.ErrorCode = 400;
                        response.Message = "Erro ao Atualizar a Mesa";
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

        public BaseResponse RemoveJogadorDaMesa(JogadorNaMesaRequest request)
        {
            BaseResponse response = new BaseResponse();

            string query = @"DELETE FROM JogadorNaMesa
                            WHERE idJogador = @idJogador
                            AND idMesa = @idMesa";
            try
            {
                if (_session.OpenConnection())
                {
                    int rows = _session._connection.Execute(query, param: new
                    {
                        request.idJogador,
                        request.idMesa

                    }, commandTimeout: 20);

                    if (rows > 0)
                    {
                        response.ErrorCode = 201;
                        response.Message = "Jogador Retirado da Mesa";

                    }
                    else
                    {
                        response.ErrorCode = 400;
                        response.Message = "Erro ao Retirar Jogador";
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
