using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Interface.Repository
{
    public interface ISistemaRepository
    {
        ListResponse<Sistema> getListSistemas();
        GenericResponse<Sistema> getSistema(int id);    
    }
}
