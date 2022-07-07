using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;
using DungeonFinderInfra.DbConnect;
using Dapper;

namespace DungeonFinderInfra.Repository
{
    public class SistemaRepository : BaseRepository, ISistemaRepository
    {
        public SistemaRepository(DbSession session) : base(session)
        {
        }

        public ListResponse<Sistema> getListSistemas()
        {
            ListResponse<Sistema> response = new ListResponse<Sistema>();


            string query = @"SELECT * FROM SISTEMA";

            try
            {
                if (_session.OpenConnection())
                {
                    List<Sistema> itens = _session._connection.Query<Sistema>(query, commandTimeout: 20).ToList();

                    if (itens != null && itens.Count > 0)
                    {
                        response.ErrorCode = 0;
                        response.Items = itens;

                    }
                    else
                    {
                        response.ErrorCode = 404;
                        response.Message = "Nenhum Sistema encontrado";
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

        public GenericResponse<Sistema> getSistema(int id)
        {
            GenericResponse<Sistema> response = new GenericResponse<Sistema>();


            string query = @"SELECT * FROM SISTEMA 
                             WHERE idSistema = @id";

            try
            {
                if (_session.OpenConnection())
                {
                    Sistema sistema = _session._connection.QueryFirstOrDefault<Sistema>(query, 
                        param: new { id },commandTimeout: 20);

                    if (sistema != null)
                    {
                        response.Response = sistema;
                        response.BaseResponse.ErrorCode = 0;
                        response.BaseResponse.Message = "Sucesso";

                    }
                    else
                    {
                        response.BaseResponse.ErrorCode = 404;
                        response.BaseResponse.Message = "Nenhum Sistema encontrado";
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
    }
}
