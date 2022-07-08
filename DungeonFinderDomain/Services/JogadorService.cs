using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Services
{
    public class JogadorService : IJogadorService
    {
        private readonly IJogadorRepository _jogadorRepository;
        public JogadorService(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }

        public GenericResponse<Jogador> getJogador(int idUsuario)
        {
            return _jogadorRepository.getJogador(idUsuario);
        }

        public GenericResponse<Jogador> getJogadorById(int idJogador)
        {
            return _jogadorRepository.getJogadorById(idJogador);
        }

        public ListResponse<Jogador> getJogadorList()
        {
            return _jogadorRepository.getJogadorList();
        }
    }
}
