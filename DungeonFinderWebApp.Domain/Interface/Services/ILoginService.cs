using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonFinderWebApp.Domain.Interface.Services
{
    public interface ILoginService
    {
        Task<GenericResponse<LoginResponse>>Login(LoginRequest request);
        Task<string> Register(RegisterRequest request);
    }
}
