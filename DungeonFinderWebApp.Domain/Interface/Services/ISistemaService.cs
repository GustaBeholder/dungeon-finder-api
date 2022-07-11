using DungeonFinderWebApp.Domain.Models.Entities;

namespace DungeonFinderWebApp.Domain.Interface.Services
{
    public interface ISistemaService
    {
        Task<IEnumerable<Sistema>> getSistemas();
    }
}
