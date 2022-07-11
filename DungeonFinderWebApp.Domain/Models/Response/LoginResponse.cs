
namespace DungeonFinderWebApp.Domain.Models.Response
{
    public class LoginResponse
    {
        public int IdUsuario { get; set; }
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
