using DungeonFinderWebApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonFinderWebApp.Domain.Interface.Service
{
    public interface ILoginService
    {
        Task<string> Login(LoginModel loginModel);
        Task<string> Register(UsuarioRegistro usuarioRegistro);
    }
}
