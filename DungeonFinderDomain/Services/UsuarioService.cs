using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IJogadorRepository _jogadorRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IJogadorRepository jogadorRepository, IUsuarioRepository usuairoRepository)
        {
            _jogadorRepository = jogadorRepository;
            _usuarioRepository = usuairoRepository; 
        }

        public BaseResponse createUsuario(CreateUserRequest request)
        {
            BaseResponse response = VerificaUser(request.Email);

            if (response.ErrorCode != 0) return response;
            
            response = _usuarioRepository.createUsuario(request);

            int idUsuario = _usuarioRepository.getIdUsuarioEmail(request.Email);

            Jogador jogador = new Jogador
            {
                IdUsuario = idUsuario,
                Nome = request.Nome,
                IdJogador = 0

            };
            response = _jogadorRepository.createJogador(jogador);
            return response;
        }

        public GenericResponse<Usuario> getUsuario(UserLoginRequest request)
        {
            return _usuarioRepository.getUsuario(request);  
        }


        private bool VerificaUsuarioExiste(string email)
        {
            int idUsuario = _usuarioRepository.getIdUsuarioEmail(email);

            return idUsuario > 0;
        }

        private BaseResponse VerificaUser(string email)
        {
            BaseResponse response = new BaseResponse
            {
                ErrorCode = 0
            };
            if (VerificaUsuarioExiste(email))
            {
                response.ErrorCode = 400;
                response.Message = "Usuário já existe";
            }
            return response;

        }

        
    }
}
