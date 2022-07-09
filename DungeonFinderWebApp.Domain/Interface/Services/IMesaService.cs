using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;

namespace DungeonFinderWebApp.Domain.Interface.Services
{
    public interface IMesaService
    {
        Task<ListResponse<MesaResponse>> getMesas(MesaRequest request);
    }
}
