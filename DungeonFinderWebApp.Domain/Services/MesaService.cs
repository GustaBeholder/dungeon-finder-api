

using DungeonFinderWebApp.Domain.Extensions;
using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;
using DungeonFinderWebApp.Domain.Utils;

namespace DungeonFinderWebApp.Domain.Services
{
    public class MesaService : ServicesBase, IMesaService
    {
        private readonly HttpClient _httpClient;

        public MesaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MesaResponse>> getMesas(MesaRequest request)
        {
            var mesaContent = JsonUtils.ObterStringContent(request);

            var response = await _httpClient.PostAsync($"{ApiUrl}Mesas/GetMesa", mesaContent);

            return await JsonUtils.Deserializar<IEnumerable<MesaResponse>>(response);
        }

        public async Task<GenericResponse<MesaResponse>> getMesaDetail(int idMesa)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}Mesas/GetMesa/{idMesa}");

            return await JsonUtils.Deserializar<GenericResponse<MesaResponse>>(response);
        }
    }
}
