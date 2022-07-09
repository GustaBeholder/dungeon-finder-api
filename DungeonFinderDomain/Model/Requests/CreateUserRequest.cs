

namespace DungeonFinderDomain.Model.Requests
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
    }
}
