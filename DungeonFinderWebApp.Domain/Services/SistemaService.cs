using DungeonFinderWebApp.Domain.Extensions;
using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Models.Entities;
using DungeonFinderWebApp.Domain.Utils;

namespace DungeonFinderWebApp.Domain.Services
{
    public class SistemaService: ServicesBase, ISistemaService
    {
        private readonly HttpClient _httpClient;

        public SistemaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Sistema>> getSistemas()
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}Sistemas/GetSistema");

            return await JsonUtils.Deserializar<IEnumerable<Sistema>>(response);
        }
    }
}
