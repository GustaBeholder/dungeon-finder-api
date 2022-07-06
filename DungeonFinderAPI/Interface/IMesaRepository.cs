using DungeonFinderAPI.Model.Requests;
using DungeonFinderAPI.Model.Response;

namespace DungeonFinderAPI.Interface
{
    public interface IMesaRepository
    {
        MesaResponse getMesaDetails(int mesaId);
        BaseResponse createMesa(MesaCreateRequest request);
        ListResponse<MesaResponse> getMesas(MesaRequest request);
        ListResponse<JogadorNaMesaResponse> getJogadoresNaMesa(int idMesa); 
    }
}
