using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Repository
{
    public interface IMesaRepository
    {
        GenericResponse<MesaResponse> getMesaDetails(int mesaId);
        BaseResponse createMesa(MesaCreateRequest request);
        ListResponse<MesaResponse> getMesas(MesaRequest request);
        ListResponse<JogadorNaMesaResponse> getJogadoresNaMesa(int idMesa);
    }
}
