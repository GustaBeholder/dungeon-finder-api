using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;
using System.Text;
using System.Text.Json;

namespace DungeonFinderWebApp.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GenericResponse<LoginResponse>> Login(LoginRequest request)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44351/api/Usuarios/GetUsuario", loginContent);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<GenericResponse<LoginResponse>>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<BaseResponse> Register(RegisterRequest request)
        {
            var registroContent = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44351/api/Usuarios/CreateUsuario", registroContent);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<BaseResponse>(await response.Content.ReadAsStringAsync(), options);
        }


    }
}
