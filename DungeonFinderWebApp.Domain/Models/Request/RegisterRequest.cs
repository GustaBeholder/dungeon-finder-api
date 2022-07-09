using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonFinderWebApp.Domain.Models.Request
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
    }
}
