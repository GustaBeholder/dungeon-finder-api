using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IJogadorRepository _jogadorRepository;
        private readonly IUsuarioRepository _usuairoRepository;
        public UsuarioService(IJogadorRepository jogadorRepository, IUsuarioRepository usuairoRepository)
        {
            _jogadorRepository = jogadorRepository;
            _usuairoRepository = usuairoRepository; 
        }

        public BaseResponse createUsuario(Usuario request)
        {
            BaseResponse response = VerificaUser(request.Email);

            if (response.ErrorCode != 0) return response;
            
            response =_usuairoRepository.createUsuario(request);

            int idUsuario = _usuairoRepository.getIdUsuarioEmail(request.Email);

            Jogador jogador = new Jogador
            {
                IdUsuario = request.IdUsuario,
                Nome = request.Nome,
                IdJogador = 0

            };
            response = _jogadorRepository.createJogador(jogador);
            return response;
        }

        private bool VerificaUsuarioExiste(string email)
        {
            int idUsuario = _usuairoRepository.getIdUsuarioEmail(email);

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

        public GenericResponse<Usuario> getusuario(Usuario request)
        {
            return _usuairoRepository.getusuario(request);  
        }
    }
}
