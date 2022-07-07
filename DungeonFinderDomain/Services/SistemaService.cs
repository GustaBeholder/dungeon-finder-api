using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Services
{
    public class SistemaService : ISistemaService
    {
        private readonly ISistemaRepository _sistemaRepository;
        public SistemaService(ISistemaRepository sistemaRepository)
        {
            _sistemaRepository = sistemaRepository; 
        }

        public ListResponse<Sistema> getListSistemas()
        {
            return _sistemaRepository.getListSistemas();    
        }

        public GenericResponse<Sistema> getSistema(int id)
        {
            return _sistemaRepository.getSistema(id);
        }
    }
}
