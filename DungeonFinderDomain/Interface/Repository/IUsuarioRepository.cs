using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Repository
{
    public interface IUsuarioRepository
    {
        BaseResponse createUsuario(Usuario request);
        int getIdUsuarioEmail(string email);
        GenericResponse<Usuario> getusuario(Usuario request);
    }
}
