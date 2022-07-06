using DungeonFinderAPI.Model.Requests;
using DungeonFinderAPI.Model.Response;

namespace DungeonFinderAPI.Interface
{
    public interface IMesaRepository
    {
        MesaResponse getMesaDetails(int mesaId);
        IEnumerable<MesaResponse> getMesas(MesaRequest request);
    }
}
