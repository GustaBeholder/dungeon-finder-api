
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Repository
{
    public interface IJogadorRepository
    {
        GenericResponse<Jogador> getJogador(int idUsuario);
        GenericResponse<Jogador> getJogadorById(int idJogador);
        ListResponse<Jogador> getJogadorList();

    }
}
