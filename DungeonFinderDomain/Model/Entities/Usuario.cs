

using System.Text.Json.Serialization;

namespace DungeonFinderDomain.Model.Entities
{
    public class Usuario
    {
        [JsonIgnore] 
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
