using DungeonFinderWebApp.Domain.Interface.Service;
using DungeonFinderWebApp.Domain.Models.Entities;
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

        public async Task<string> Login(LoginModel loginModel)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(loginModel),
                Encoding.UTF8,
                "application/json");


            var response = await _httpClient.PostAsync("https://localhost:44351/api/Usuarios/GetUsuario", loginContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Register(UsuarioRegistro usuarioRegistro)
        {
            var registerContent = new StringContent(    
                JsonSerializer.Serialize(usuarioRegistro),
                Encoding.UTF8,
                "applicaton/json");

            var response = await _httpClient.PostAsync("https://localhost:44351/api/Usuarios/CreateUsuario", registerContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
