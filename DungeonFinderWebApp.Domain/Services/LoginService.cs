using DungeonFinderWebApp.Domain.Extensions;
using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;
using DungeonFinderWebApp.Domain.Utils;


namespace DungeonFinderWebApp.Domain.Services
{
    public class LoginService : ServicesBase, ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GenericResponse<LoginResponse>> Login(LoginRequest request)
        {
            var loginContent = JsonUtils.ObterStringContent(request);

            var response = await _httpClient.PostAsync($"{ApiUrl}Usuarios/GetUsuario", loginContent);

            return await JsonUtils.Deserializar<GenericResponse<LoginResponse>>(response);
        }

        public async Task<BaseResponse> Register(RegisterRequest request)
        {
            var registroContent = JsonUtils.ObterStringContent(request);

            var response = await _httpClient.PostAsync($"{ApiUrl}Usuarios/CreateUsuario", registroContent);

            return await JsonUtils.Deserializar<BaseResponse>(response);
        }


    }
}
