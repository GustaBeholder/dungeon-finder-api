

using System.Text.Json.Serialization;

namespace DungeonFinderDomain.Model.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
