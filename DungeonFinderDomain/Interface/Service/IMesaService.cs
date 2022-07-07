
using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Service
{
    public interface IMesaService
    {
        GenericResponse<MesaResponse> getMesaDetails(int mesaId);
        BaseResponse createMesa(MesaCreateRequest request);
        ListResponse<MesaResponse> getMesas(MesaRequest request);
        ListResponse<JogadorNaMesaResponse> getJogadoresNaMesa(int idMesa);
        BaseResponse createJogadorNaMesa(JogadorNaMesaRequest request);
        BaseResponse RemoveJogadorDaMesa(JogadorNaMesaRequest request);
        BaseResponse updateMesa(UpdateMesa request);
    }
}
