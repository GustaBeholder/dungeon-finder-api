
using Dapper;
using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Model.Response;
using DungeonFinderDomain.Utils;
using DungeonFinderInfra.DbConnect;

namespace DungeonFinderInfra.Repository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(DbSession session) : base(session)
        {
        }

        public BaseResponse createUsuario(CreateUserRequest request)
        {
            BaseResponse response = new BaseResponse();

            string query = @"INSERT INTO Usuario (email, password, DataCadastro) 
                           VALUES (@email, @password, GETDATE())";

            try
            {
                if (_session.OpenConnection())
                {
                    int rows = _session._connection.Execute(query, param: new
                    {
                        request.Email,
                        Password = Criptografia.GetHash(request.Password)

                    }, commandTimeout: 20) ;

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

        public int getIdUsuarioEmail(string email)
        {
            int idUsuario = 0;

            string query = @"SELECT idUsuario FROM Usuario
                            WHERE email = @email";

            try
            {
                if (_session.OpenConnection())
                {
                    idUsuario = _session._connection.QueryFirstOrDefault<int>(query, param: new
                    {
                        email

                    }, commandTimeout: 20);

                    if (idUsuario == 0)
                    {
                        idUsuario = -1;

                    }

                }
            }
            catch (Exception ex)
            {
                idUsuario = -1;
            }
            finally
            {
                _session.CloseConnection();
            }
            return idUsuario;
        }

        public GenericResponse<Usuario> getUsuario(UserLoginRequest request)
        {
            GenericResponse<Usuario> response = new GenericResponse<Usuario>();

            string query = @"SELECT u.idUsuario, j.idJogador, j.Nome, u.Email, u.Password FROM Usuario u
                            INNER JOIN Jogador j on (j.idUsuario = u.idUsuario)
                            WHERE u.Email = @Email
                            AND u.Password = @Password";

            try
            {
                if (_session.OpenConnection())
                {
                    Usuario user = _session._connection.QueryFirstOrDefault<Usuario>(query, param: new
                    {
                        request.Email,
                        Password = Criptografia.GetHash(request.Password)

                    }, commandTimeout: 20);

                    if (user != null)
                    {
                        response.Response = user;
                        response.BaseResponse.ErrorCode = 0;
                        response.BaseResponse.Message = "Sucesso";


                    }
                    else
                    {
                        response.BaseResponse.ErrorCode = 400;
                        response.BaseResponse.Message = "Usuário e/ou senha inválidos";
                    }
                }
            }
            catch (Exception ex)
            {
                response.BaseResponse.ErrorCode = 500;
                response.BaseResponse.Message = "Usuário e/ ou senha inválidos";
            }
            finally
            {
                _session.CloseConnection();
            }
            return response;

        }
    }
   
}
