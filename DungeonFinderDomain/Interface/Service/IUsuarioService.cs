
using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Service
{
    public interface IUsuarioService
    {
        BaseResponse createUsuario(CreateUserRequest request);
        GenericResponse<Usuario> getUsuario(UserLoginRequest request);

    }
}
