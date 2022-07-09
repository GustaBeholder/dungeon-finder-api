using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Repository
{
    public interface IUsuarioRepository
    {
        BaseResponse createUsuario(CreateUserRequest request);
        int getIdUsuarioEmail(string email);
        GenericResponse<Usuario> getUsuario(UserLoginRequest request);
    }
}
