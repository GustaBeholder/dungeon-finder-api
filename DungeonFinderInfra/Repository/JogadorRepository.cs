
using Dapper;
using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;
using DungeonFinderInfra.DbConnect;

namespace DungeonFinderInfra.Repository
{
    public class JogadorRepository : BaseRepository, IJogadorRepository
    {
        public JogadorRepository(DbSession session) : base(session)
        {
        }

        public GenericResponse<Jogador> getJogador(int idUsuario)
        {
            GenericResponse<Jogador> response = new GenericResponse<Jogador>();


            string query = @"SELECT * FROM Jogador
                            WHERE idUsuario = @idUsuario";

            try
            {
                if (_session.OpenConnection())
                {
                    Jogador jogador = _session._connection.QueryFirstOrDefault<Jogador>(query,
                        param: new { idUsuario }, commandTimeout: 20);

                    if (jogador != null)
                    {
                        response.Response = jogador;
                        response.BaseResponse.ErrorCode = 0;
                        response.BaseResponse.Message = "Sucesso";

                    }
                    else
                    {
                        response.BaseResponse.ErrorCode = 404;
                        response.BaseResponse.Message = "Nenhum Jogador encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                response.BaseResponse.ErrorCode = 500;
                response.BaseResponse.Message = "Erro ao conectar ao banco de dados";
            }
            finally
            {
                _session.CloseConnection();
            }
            return response;
        }

        public GenericResponse<Jogador> getJogadorById(int idJogador)
        {
            GenericResponse<Jogador> response = new GenericResponse<Jogador>();


            string query = @"SELECT * FROM Jogador
                            WHERE idJogador = @idJogador";

            try
            {
                if (_session.OpenConnection())
                {
                    Jogador jogador = _session._connection.QueryFirstOrDefault<Jogador>(query,
                        param: new { idJogador }, commandTimeout: 20);

                    if (jogador != null)
                    {
                        response.Response = jogador;
                        response.BaseResponse.ErrorCode = 0;
                        response.BaseResponse.Message = "Sucesso";

                    }
                    else
                    {
                        response.BaseResponse.ErrorCode = 404;
                        response.BaseResponse.Message = "Nenhum Jogador encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                response.BaseResponse.ErrorCode = 500;
                response.BaseResponse.Message = "Erro ao conectar ao banco de dados";
            }
            finally
            {
                _session.CloseConnection();
            }
            return response;
        }

        public ListResponse<Jogador> getJogadorList()
        {
            ListResponse<Jogador> response = new ListResponse<Jogador>();


            string query = @"SELECT * FROM Jogador";

            try
            {
                if (_session.OpenConnection())
                {
                    List<Jogador> itens = _session._connection.Query<Jogador>(query, commandTimeout: 20).ToList();

                    if (itens != null && itens.Count > 0)
                    {
                        response.ErrorCode = 0;
                        response.Items = itens;

                    }
                    else
                    {
                        response.ErrorCode = 404;
                        response.Message = "Nenhum Jogador encontrado";
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

        public BaseResponse createJogador(Jogador request)
        {
            BaseResponse response = new BaseResponse();

            string query = @"INSERT INTO Jogador (Nome, idUsuario) 
                           VALUES (@Nome, @IdUsuario)";

            try
            {
                if (_session.OpenConnection())
                {
                    int rows = _session._connection.Execute(query, param: new
                    {
                        request.Nome,
                        request.IdUsuario

                    }, commandTimeout: 20);

                    if (rows > 0)
                    {
                        response.ErrorCode = 0;
                        response.Message = "Jogador criado!";

                    }
                    else
                    {
                        response.ErrorCode = 400;
                        response.Message = "Erro ao criar Jogador";
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
