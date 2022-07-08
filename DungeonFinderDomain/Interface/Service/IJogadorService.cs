
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Service
{
    public interface IJogadorService
    {
        GenericResponse<Jogador> getJogador(int idUsuario);
        GenericResponse<Jogador> getJogadorById(int idJogador);
        ListResponse<Jogador> getJogadorList();

    }
}
