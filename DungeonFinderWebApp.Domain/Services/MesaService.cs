

using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;
using DungeonFinderWebApp.Domain.Utils;

namespace DungeonFinderWebApp.Domain.Services
{
    public class MesaService : IMesaService
    {
        private readonly HttpClient _httpClient;

        public MesaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ListResponse<MesaResponse>> getMesas(MesaRequest request)
        {
            throw new NotImplementedException();
        }

        //public async Task<ListResponse<MesaResponse>> getMesas(MesaRequest request)
        //{
        //    var mesaContent = JsonUtils.ObterStringContent(request);

        //    var response = await _httpClient.PostAsync("", mesaContent);
        //}
    }
}
