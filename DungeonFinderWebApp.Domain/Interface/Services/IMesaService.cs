using DungeonFinderWebApp.Domain.Models.Entities;
using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;

namespace DungeonFinderWebApp.Domain.Interface.Services
{
    public interface IMesaService
    {
        Task <IEnumerable<MesaResponse>> getMesas(MesaRequest request);
        Task <GenericResponse<MesaResponse>> getMesaDetail(int idMesa);
        Task<BaseResponse> createMesa(CreateMesaRequest request);
        Task<IEnumerable<Jogador>> getJogadoresNaMesa(int idMesa);
        Task<BaseResponse> addJogadorNaMesa(AddJogadorNaMesa request);
       
    }
}
