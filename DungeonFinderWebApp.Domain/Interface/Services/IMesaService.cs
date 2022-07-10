using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;

namespace DungeonFinderWebApp.Domain.Interface.Services
{
    public interface IMesaService
    {
        Task <IEnumerable<MesaResponse>> getMesas(MesaRequest request);
    }
}
