using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Service
{
    public interface ISistemaService
    {
        ListResponse<Sistema> getListSistemas();
        GenericResponse<Sistema> getSistema(int id);
    }
}
